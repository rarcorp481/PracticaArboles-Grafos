using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
using casoDeEstudio.PopUpForms;

namespace casoDeEstudio.Forms
{
    public partial class FrmGrafos : MaterialForm
    {
        //Clases internas para Nodos y Aristas (Sé que no se deben dejar acá en parte de la UI, planeo hacerlas externas luego, las tengo acá por practicidad y pq son la 2 am xd)
        public class Nodo
        {
            public string Nombre { get; set; }
            public Point Posicion { get; set; }
            public const int Radio = 40; // Tamaño visual

            public Rectangle Area => new Rectangle(Posicion.X - Radio, Posicion.Y - Radio, Radio * 2, Radio * 2);
        }

        public class Arista
        {
            public Nodo Origen { get; set; }
            public Nodo Destino { get; set; }
            public int Peso { get; set; } // Distancia en cm
        }

        // VARIABLES DE ESTADO
        private List<Nodo> nodos = new List<Nodo>();
        private List<Arista> aristas = new List<Arista>();

        // Control del mouse
        private Nodo nodoSeleccionado = null; // Para mover o conectar
        private Nodo nodoOrigenRuta = null;   // Para Dijkstra
        private Point posicionMouseActual;
        private bool estaArrastrando = false;

        // Ruta calculada (Dijkstra)
        private List<Nodo> rutaMasCorta = new List<Nodo>();
        private List<Arista> aristasRuta = new List<Arista>();

        // Enum para modos
        private enum Modo { Mover, NuevoNodo, NuevaConexion, CalcularRuta }
        private Modo modoActual = Modo.Mover;

        public FrmGrafos()
        {
            InitializeComponent();
            ConfigurarMaterialSkin();
        }

        // Configuración del tema de MaterialSkin.2
        private void ConfigurarMaterialSkin()
        {
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.Teal700, TextShade.WHITE
            );
        }

        // EVENTOS DE LA UI (modos, limpiar)
        private void Modo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdMover.Checked) modoActual = Modo.Mover;
            else if (rdNodo.Checked) modoActual = Modo.NuevoNodo;
            else if (rdArista.Checked) modoActual = Modo.NuevaConexion;
            else if (rdRuta.Checked) modoActual = Modo.CalcularRuta;

            // Resetear selecciones temporales
            nodoSeleccionado = null;
            nodoOrigenRuta = null;
            rutaMasCorta.Clear();
            aristasRuta.Clear();
            ActualizarInstrucciones();
            pbLienzo.Invalidate();
        }

        private void ActualizarInstrucciones()
        {
            switch (modoActual)
            {
                case Modo.Mover: lblInstrucciones.Text = "Arrastra los edificios para acomodarlos."; break;
                case Modo.NuevoNodo: lblInstrucciones.Text = "Haz clic en un espacio vacío para crear un edificio."; break;
                case Modo.NuevaConexion: lblInstrucciones.Text = "Arrastra de un edificio a otro para conectar."; break;
                case Modo.CalcularRuta: lblInstrucciones.Text = "Selecciona el edificio de Origen y luego el de Destino."; break;
            }
            lblResultado.Text = "";
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Borrar todo el mapa?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                nodos.Clear();
                aristas.Clear();
                rutaMasCorta.Clear();
                aristasRuta.Clear();
                pbLienzo.Invalidate();
            }
        }

        //PARTE GRAFICA (teodioC#)
        private void pbLienzo_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // dibujar aristas
            foreach (var arista in aristas)
            {
                // Determinar color: Rojo si es parte de la ruta corta, Negro normal
                bool esRuta = aristasRuta.Contains(arista);
                Pen pen = new Pen(esRuta ? Color.Red : Color.Gray, esRuta ? 4 : 2);

                e.Graphics.DrawLine(pen, arista.Origen.Posicion, arista.Destino.Posicion);

                // Dibujar Peso (cm) en el centro
                Point medio = new Point((arista.Origen.Posicion.X + arista.Destino.Posicion.X) / 2,
                                        (arista.Origen.Posicion.Y + arista.Destino.Posicion.Y) / 2);

                // Fondo blanco para el texto
                e.Graphics.FillRectangle(Brushes.White, medio.X - 10, medio.Y - 10, 30, 15);
                e.Graphics.DrawString(arista.Peso + "cm", this.Font, esRuta ? Brushes.Red : Brushes.Black, medio.X - 10, medio.Y - 10);
            }

            // Línea elástica cuando se está creando una conexión
            if (modoActual == Modo.NuevaConexion && nodoSeleccionado != null)
            {
                e.Graphics.DrawLine(Pens.Blue, nodoSeleccionado.Posicion, posicionMouseActual);
            }

            // DIBUJO DE LOS NODOS
            foreach (var nodo in nodos)
            {
                // Color: Verde si es Origen Ruta, Rojo si es Destino, Azul normal
                Brush relleno = Brushes.White;
                Pen borde = Pens.Blue;

                if (rutaMasCorta.Contains(nodo)) { borde = Pens.Red; }
                if (nodo == nodoOrigenRuta) { relleno = Brushes.LightGreen; }

                e.Graphics.FillEllipse(relleno, nodo.Area);
                e.Graphics.DrawEllipse(borde, nodo.Area);

                // Texto centrado
                SizeF textSize = e.Graphics.MeasureString(nodo.Nombre, this.Font);
                e.Graphics.DrawString(nodo.Nombre, this.Font, Brushes.Black,
                    nodo.Posicion.X - (textSize.Width / 2),
                    nodo.Posicion.Y - (textSize.Height / 2));
            }
        }

        // Eventos del mouse para interacción conla picture box

        private void pbLienzo_MouseDown(object sender, MouseEventArgs e)
        {
            Nodo nodoClickeado = nodos.FirstOrDefault(n => n.Area.Contains(e.Location));

            switch (modoActual)
            {
                case Modo.Mover:
                    if (nodoClickeado != null)
                    {
                        nodoSeleccionado = nodoClickeado;
                        estaArrastrando = true;
                    }
                    break;

                case Modo.NuevoNodo:
                    if (nodoClickeado == null) // Solo en espacio vacío
                    {
                        string nombre = PopUpDialog.ShowInputDialog("Nombre del Edificio:", "Nuevo Nodo"); // Al menos reutilicé la clase PopUpDialog xd, prometo mover todas las clases y métodos a un directorio más adecuado luego
                        if (!string.IsNullOrWhiteSpace(nombre))
                        {
                            // Validar nombre único
                            if (nodos.Any(n => n.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase)))
                            {
                                MessageBox.Show("Ya existe un edificio con ese nombre.");
                                return;
                            }
                            nodos.Add(new Nodo { Nombre = nombre, Posicion = e.Location });
                            pbLienzo.Invalidate();
                        }
                    }
                    break;

                case Modo.NuevaConexion:
                    if (nodoClickeado != null)
                    {
                        nodoSeleccionado = nodoClickeado; // Inicio de la conexión
                    }
                    break;

                case Modo.CalcularRuta:
                    if (nodoClickeado != null)
                    {
                        if (nodoOrigenRuta == null)
                        {
                            nodoOrigenRuta = nodoClickeado;
                            lblResultado.Text = $"Origen: {nodoClickeado.Nombre}. Selecciona el destino.";
                        }
                        else
                        {
                            CalcularDijkstra(nodoOrigenRuta, nodoClickeado);
                            nodoOrigenRuta = null; // Reiniciar ciclo
                        }
                        pbLienzo.Invalidate();
                    }
                    break;
            }
        }

        private void pbLienzo_MouseMove(object sender, MouseEventArgs e)
        {
            posicionMouseActual = e.Location;

            if (modoActual == Modo.Mover && estaArrastrando && nodoSeleccionado != null)
            {
                // Arrastrar nodo (Drag and Drop)
                nodoSeleccionado.Posicion = e.Location;
                pbLienzo.Invalidate();
            }
            else if (modoActual == Modo.NuevaConexion && nodoSeleccionado != null)
            {
                // Redibujar la línea elástica
                pbLienzo.Invalidate();
            }
        }

        private void pbLienzo_MouseUp(object sender, MouseEventArgs e)
        {
            if (modoActual == Modo.Mover)
            {
                estaArrastrando = false;
                nodoSeleccionado = null;
            }
            else if (modoActual == Modo.NuevaConexion && nodoSeleccionado != null)
            {
                Nodo destino = nodos.FirstOrDefault(n => n.Area.Contains(e.Location));

                // Validar conexión válida (distinto nodo, no duplicada)
                if (destino != null && destino != nodoSeleccionado)
                {
                    if (!aristas.Any(a => (a.Origen == nodoSeleccionado && a.Destino == destino) ||
                                          (a.Origen == destino && a.Destino == nodoSeleccionado)))
                    {
                        string pesoStr = PopUpDialog.ShowInputDialog("Distancia en cm:", "Nueva Ruta");
                        if (int.TryParse(pesoStr, out int peso) && peso > 0)
                        {
                            aristas.Add(new Arista { Origen = nodoSeleccionado, Destino = destino, Peso = peso });
                        }
                        else if (!string.IsNullOrEmpty(pesoStr))
                        {
                            MessageBox.Show("La distancia debe ser un número entero positivo.");
                        }
                    }
                }
                nodoSeleccionado = null;
                pbLienzo.Invalidate();
            }
        }

        // ALGORITMO DIJKSTRA
        private void CalcularDijkstra(Nodo inicio, Nodo fin)
        {
            // iniciar estructuras (o vaariables)
            var distancias = new Dictionary<Nodo, int>();
            var previos = new Dictionary<Nodo, Nodo>();
            var nodosNoVisitados = new List<Nodo>();

            foreach (var nodo in nodos)
            {
                distancias[nodo] = int.MaxValue;
                previos[nodo] = null;
                nodosNoVisitados.Add(nodo);
            }

            distancias[inicio] = 0;

            // Bucle principal
            while (nodosNoVisitados.Count > 0)
            {
                // Ordenar por distancia para simular Cola de Prioridad
                nodosNoVisitados.Sort((a, b) => distancias[a].CompareTo(distancias[b]));
                Nodo actual = nodosNoVisitados[0];
                nodosNoVisitados.RemoveAt(0);

                if (actual == fin) break; // Llegamos al destino
                if (distancias[actual] == int.MaxValue) break; // No hay conexión

                // Buscar vecinos
                var aristasVecinas = aristas.Where(a => a.Origen == actual || a.Destino == actual);

                foreach (var arista in aristasVecinas)
                {
                    Nodo vecino = (arista.Origen == actual) ? arista.Destino : arista.Origen;
                    if (nodosNoVisitados.Contains(vecino))
                    {
                        int nuevaDist = distancias[actual] + arista.Peso;
                        if (nuevaDist < distancias[vecino])
                        {
                            distancias[vecino] = nuevaDist;
                            previos[vecino] = actual;
                        }
                    }
                }
            }

            // Reconstrucción de la ruta
            rutaMasCorta.Clear();
            aristasRuta.Clear();

            if (distancias[fin] == int.MaxValue)
            {
                lblResultado.Text = "No existe ruta entre estos edificios.";
                return;
            }

            Nodo paso = fin;
            while (paso != null)
            {
                rutaMasCorta.Add(paso);
                paso = previos[paso];
            }
            rutaMasCorta.Reverse();

            // Identificar las aristas en la ruta para lueeeego resaltarlas en rojo
            for (int i = 0; i < rutaMasCorta.Count - 1; i++)
            {
                Nodo a = rutaMasCorta[i];
                Nodo b = rutaMasCorta[i + 1];
                var arista = aristas.FirstOrDefault(x => (x.Origen == a && x.Destino == b) || (x.Origen == b && x.Destino == a));
                if (arista != null) aristasRuta.Add(arista);
            }

            lblResultado.Text = $"Ruta más corta: {distancias[fin]} cm. ({rutaMasCorta.Count} edificios)";
        }
    }
}