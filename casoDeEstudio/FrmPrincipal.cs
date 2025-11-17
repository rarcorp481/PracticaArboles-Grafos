using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace casoDeEstudio
{
    public partial class FrmPrincipal : MaterialForm
    {
        public object MessageBoxIcons { get; private set; }

        public FrmPrincipal()
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance; // Obtiene la instancia del administrador de MaterialSkin
            materialSkinManager.AddFormToManage(this); // Agrega el formulario al administrador de MaterialSkin
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT; // Tema del formulario

            // Esquema de colore del formulario
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.BlueGrey800,
                Primary.BlueGrey900,
                Primary.BlueGrey500,
                Accent.Teal700,
                TextShade.WHITE
                );
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            lbActualización.Text = "Sistema listo. Agregue el nodo raíz (Click derecho en el área vacía).";
            ActualizarEstadisticas();
        }


        private void tvArbol_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }


        // BUTTONS & COMBOBOX:

        private void BtnBuscarArbol_Click(object sender, EventArgs e)
        {
            // botón buscar cargo
            if (tvArbol.Nodes.Count == 0)
                MessageBox.Show("No existen nodos en el Árbol de Jerarquía Empresarial. Primero añade algunos para buscar", "Error: tvArbol.Nodes.Count == 0", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                string nombre = ShowInputDialog("Ingresa el nombre del cargo que deseas buscar:", "Buscar nodo");

                if (string.IsNullOrWhiteSpace(nombre)) return;
                string textoBusquedaLimpio = nombre.ToLower().Replace(" ", "");

                foreach (TreeNode nodo in tvArbol.Nodes)
                {
                    string textoNodoLimpio = nodo.Text.ToLower().Replace(" ", "");
                    if (textoNodoLimpio.Contains(textoBusquedaLimpio))
                    {
                        MessageBox.Show($"Se han encontrado coincidencias con tu búsqueda '{nombre}'", "Resultado de búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tvArbol.SelectedNode = nodo;
                        nodo.EnsureVisible();
                    }
                    else
                    {
                        MessageBox.Show($"No se han encontrado coincidencias. El cargo no está dentro del Esquema de Jerarquía", "Sin coincidencias", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }


        }
        private void agregarCargoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // agregar cargo
            string nombreCargo = ShowInputDialog("Ingerese el nombre del nuevo cargo:", "Nuevo nodo");

            // devolver si no ha escrito el nombre
            if (string.IsNullOrWhiteSpace(nombreCargo)) return;

            //si el árbol está vacío, crear la raíz
            if (tvArbol.Nodes.Count == 0)
            {
                TreeNode raiz = new TreeNode(nombreCargo);
                tvArbol.Nodes.Add(raiz);
                lbActualización.Text = $"Raíz '{nombreCargo}' creada exitosamente";
            }
            // por si tiene un nodo seleccionado, agregar como hijo de ese nodo
            else if (tvArbol.SelectedNode != null)
            {
                tvArbol.SelectedNode.Nodes.Add(nombreCargo);
                tvArbol.SelectedNode.Expand();
                lbActualización.Text = $"Nodo '{nombreCargo}' agregado exitosamente como hijo de '{tvArbol.SelectedNode.Text}'";

            }
        }
        private void elimiarCargoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // eliminar cargo
            // Muestra el mensaje de error por si no existen nodos que eliminar (Nodes.Count == 0)
            if (tvArbol.Nodes.Count == 0) MessageBox.Show("No existen nodos en el Árbol de Jerarquía Empresarial. Primero añade algunos para eliminar", "Error: tvArbol.Nodes.Count == 0", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //Verifica que el nodo seleccionado no sea null
            else if (tvArbol.SelectedNode != null)
            {
                string nombre = tvArbol.SelectedNode.Text; // Le asigna el texto del nodo a a variable nombre
                DialogResult = MessageBox.Show($"¿Estás seguro de querer eliminar el nodo '{nombre}' junto a todos sus subordinados?", "Confirmar elección", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (DialogResult == DialogResult.Yes)
                {
                    tvArbol.SelectedNode.Remove();
                    lbActualización.Text = $"El nodo '{nombre}' junto a todos sus subordinados ha sido eliminado exitosamente";
                    ActualizarEstadisticas();
                }
            }
            //En caso de que el usuario no seleccione ningún elemento, se muestra este mensaje de error
            else
            {
                MessageBox.Show("Selecciona un elemento para borrar", "Error: Nodos Seleccionados == null", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void renombrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // renombrar cargo
            //Verifica que el árbol tenga nodos, de lo contrario manda el mensaje de error
            if (tvArbol.Nodes.Count == 0)
                MessageBox.Show("No existen nodos en el Árbol de Jerarquía Empresarial. Primero añade algunos para renombrar", "Error: tvArbol.Nodes.Count == 0", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (tvArbol.SelectedNode != null)
            {
                string nodoSeleccionado = tvArbol.SelectedNode.Text;
                string nombre = ShowInputDialog("Ingrese el nuevo nombre para el nodo seleccionado", "Renombrar nodo");
                if (string.IsNullOrWhiteSpace(nombre)) return; //Devuelve si el user solo escribió espacios vacios o nada
                tvArbol.SelectedNode.Text = nombre; //Se pone abajo del verificador de espacios vacíos, para que al cancelar la acción no devuelva nada
                lbActualización.Text = $"El nodo '{nodoSeleccionado}' ha sido renombrado exitosamente como '{nombre}'";
            }
            else MessageBox.Show("Sin nodos seleccionados. Selecciona uno para cambiar su nombre", "Error: Nodos seleccionados == null", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cbOrdenamiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tvArbol.Nodes.Count == 0)
            {
                mltOrden.Text = "El árbol está vacío.";
                return;
            }

            string tipoOrden = cbOrdenamiento.Text;
            StringBuilder resultado = new StringBuilder();
            TreeNode raiz = tvArbol.Nodes[0];

            switch (tipoOrden)
            {
                case "Pre-orden":
                    RecorridoPreOrden(raiz, resultado);
                    break;
                case "Post-orden":
                    RecorridoPostOrden(raiz, resultado);
                    break;
                case "Por Niveles":
                    RecorridoPorNiveles(raiz, resultado);
                    break;
            }

            mltOrden.Text = resultado.ToString();
        }

        // --- Algoritmos Recursivos ---
        private void RecorridoPreOrden(TreeNode nodo, StringBuilder sb)
        {
            if (nodo == null) return;
            sb.Append(nodo.Text + " -> "); // Raíz
            foreach (TreeNode hijo in nodo.Nodes) RecorridoPreOrden(hijo, sb); // Hijos
        }

        private void RecorridoPostOrden(TreeNode nodo, StringBuilder sb)
        {
            if (nodo == null) return;
            foreach (TreeNode hijo in nodo.Nodes) RecorridoPostOrden(hijo, sb); // Hijos
            sb.Append(nodo.Text + " -> "); // Raíz al final
        }

        private void RecorridoPorNiveles(TreeNode raiz, StringBuilder sb)
        {
            Queue<TreeNode> cola = new Queue<TreeNode>();
            cola.Enqueue(raiz);

            while (cola.Count > 0)
            {
                TreeNode actual = cola.Dequeue();
                sb.Append(actual.Text + " | ");

                foreach (TreeNode hijo in actual.Nodes)
                {
                    cola.Enqueue(hijo);
                }
            }
        }

        // 6. ESTADÍSTICAS
        private void ActualizarEstadisticas()
        {
            if (tvArbol.Nodes.Count == 0)
            {
                // Actualiza el ListView o Label
                ActualizarListViewStats(0, 0);
                return;
            }

            // Contar nodos (TreeView tiene método nativo)
            int totalNodos = tvArbol.GetNodeCount(true);

            // Calcular Altura (Necesitamos recursividad manual)
            int altura = CalcularAltura(tvArbol.Nodes[0]);

            ActualizarListViewStats(totalNodos, altura);
        }

        private int CalcularAltura(TreeNode nodo)
        {
            if (nodo == null || nodo.Nodes.Count == 0) return 1;
            int max = 0;
            foreach (TreeNode hijo in nodo.Nodes)
            {
                max = Math.Max(max, CalcularAltura(hijo));
            }
            return max + 1;
        }

        private void ActualizarListViewStats(int total, int niveles)
        {
            // Opción A: Usar el Label (Más fácil)
            // lbEstadisticas.Text = $"Estadísticas: Total Cargos: {total} | Niveles: {niveles}";

            // Opción B: Usar el ListView que tienes en el diseño
            lvEstadisticas.Clear();
            lvEstadisticas.View = View.Details;
            lvEstadisticas.Columns.Add("Métrica", 150);
            lvEstadisticas.Columns.Add("Valor", 100);

            var item1 = new ListViewItem("Total Cargos");
            item1.SubItems.Add(total.ToString());

            var item2 = new ListViewItem("Niveles Jerarquía");
            item2.SubItems.Add(niveles.ToString());

            lvEstadisticas.Items.Add(item1);
            lvEstadisticas.Items.Add(item2);
        }

        // METODOS:

        public static string ShowInputDialog(string texto, string titulo)
        {
            Form prompt = new Form()
            {
                Width = 400,
                Height = 180,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = titulo,
                StartPosition = FormStartPosition.CenterScreen,
                MinimizeBox = false,
                MaximizeBox = false
            };

            Label textLabel = new Label() { Left = 20, Top = 20, Text = texto, AutoSize = true };
            TextBox textBox = new TextBox() { Left = 20, Top = 50, Width = 340 };
            Button confirmation = new Button() { Text = "Aceptar", Left = 240, Width = 100, Top = 90 };

            // resultado de dialogo none (para que no se cierre en el caso de que el usuario no escriba nada o solo espacios)
            confirmation.DialogResult = DialogResult.None;

            // Lógica para el click 
            confirmation.Click += (sender, e) =>
            {
                //Si el no escribe nada o solo espacios en blanco
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    MessageBox.Show("¡El nombre es obligatorio! Por favor ingrese un dato.", "Dato Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox.Focus();
                }
                else
                {
                    prompt.DialogResult = DialogResult.OK; // Autorizar el cierre solo si todo sale bien
                    prompt.Close();
                }
            };

            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);

            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : ""; //operador ternario. Devuelve el texto que el user escribió si cerró la ventana con el botón "Aceptar"

        }

        private TreeNode BuscarRecursivo(TreeNodeCollection nodos, string busqueda)
        {
            // Revisa cada nodo en la lista actual
            foreach (TreeNode nodo in nodos)
            {
                // 1. Prepara el texto del nodo actual igual que tu búsqueda
                string textoNodoLimpio = nodo.Text.ToLower().Replace(" ", "");

                // 2. ¿Es este?
                if (textoNodoLimpio.Contains(busqueda))
                {
                    return nodo; // ¡Lo encontré! Devuelvo el nodo y termino.
                }

                // 3. Si no es este, ¿tendrá hijos? ¡A buscar adentro! (Recursividad)
                if (nodo.Nodes.Count > 0)
                {
                    TreeNode encontradoEnHijos = BuscarRecursivo(nodo.Nodes, busqueda);
                    if (encontradoEnHijos != null)
                    {
                        return encontradoEnHijos; // ¡Lo encontró un hijo! Lo devuelvo hacia arriba.
                    }
                }
            }

            return null; // Si revisé todo y no estaba aquí.
        }

        // lABELS:

        private void materialLabel2_Click(object sender, EventArgs e) { }
        private void lbEstadisticas_Click(object sender, EventArgs e) { }
        private void lbActualización_Click(object sender, EventArgs e) { }
        private void mltOrden_Click(object sender, EventArgs e) { }
        private void lbActualización_Click_1(object sender, EventArgs e) { }
        private void mltOrden_Click_1(object sender, EventArgs e) { }


        // TABLELAYOUTS:

        private void TL1_Paint(object sender, PaintEventArgs e) { }
        private void TL2_Paint(object sender, PaintEventArgs e) { }
        private void TL3_Paint(object sender, PaintEventArgs e) { }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }

    }
}
