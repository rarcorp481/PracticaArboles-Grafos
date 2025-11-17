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

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

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

        // FIX: Ahora este evento dispara la actualización de estadísticas al tocar un nodo
        private void tvArbol_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ActualizarEstadisticas(); //added
        }

        // BUTTONS & COMBOBOX:

        private void BtnBuscarArbol_Click(object sender, EventArgs e)
        {
            if (tvArbol.Nodes.Count == 0)
                MessageBox.Show("No existen nodos en el Árbol de Jerarquía Empresarial. Primero añade algunos para buscar", "Error: tvArbol.Nodes.Count == 0", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                string nombre = ShowInputDialog("Ingresa el nombre del cargo que deseas buscar:", "Buscar nodo");

                if (string.IsNullOrWhiteSpace(nombre)) return;
                string textoBusquedaLimpio = nombre.ToLower().Replace(" ", "");

                TreeNode nodoEncontrado = BuscarRecursivo(tvArbol.Nodes, textoBusquedaLimpio); //added

                if (nodoEncontrado != null) //added
                {
                    MessageBox.Show($"Se han encontrado coincidencias con tu búsqueda '{nombre}'", "Resultado de búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tvArbol.SelectedNode = nodoEncontrado; //added
                    tvArbol.Focus(); //added
                    nodoEncontrado.EnsureVisible(); //added
                }
                else //added
                {
                    MessageBox.Show($"No se han encontrado coincidencias. El cargo no está dentro del Esquema de Jerarquía", "Sin coincidencias", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private TreeNode BuscarRecursivo(TreeNodeCollection nodos, string busqueda) //added
        {
            foreach (TreeNode nodo in nodos) //added
            {
                string textoNodoLimpio = nodo.Text.ToLower().Replace(" ", ""); //added
                if (textoNodoLimpio.Contains(busqueda)) return nodo; //added

                if (nodo.Nodes.Count > 0) //added
                {
                    TreeNode encontrado = BuscarRecursivo(nodo.Nodes, busqueda); //added
                    if (encontrado != null) return encontrado; //added
                }
            }
            return null; //added
        }

        private void agregarCargoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nombreCargo = ShowInputDialog("Ingerese el nombre del nuevo cargo:", "Nuevo nodo");

            if (string.IsNullOrWhiteSpace(nombreCargo)) return;

            if (tvArbol.Nodes.Count == 0)
            {
                TreeNode raiz = new TreeNode(nombreCargo);
                tvArbol.Nodes.Add(raiz);
                lbActualización.Text = $"Raíz '{nombreCargo}' creada exitosamente";
            }
            else if (tvArbol.SelectedNode != null)
            {
                tvArbol.SelectedNode.Nodes.Add(nombreCargo);
                tvArbol.SelectedNode.Expand();
                lbActualización.Text = $"Nodo '{nombreCargo}' agregado exitosamente como hijo de '{tvArbol.SelectedNode.Text}'";
            }
            ActualizarEstadisticas(); //added
        }

        private void elimiarCargoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tvArbol.Nodes.Count == 0) MessageBox.Show("No existen nodos en el Árbol de Jerarquía Empresarial. Primero añade algunos para eliminar", "Error: tvArbol.Nodes.Count == 0", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (tvArbol.SelectedNode != null)
            {
                string nombre = tvArbol.SelectedNode.Text;
                DialogResult resultado = MessageBox.Show($"¿Estás seguro de querer eliminar el nodo '{nombre}' junto a todos sus subordinados?", "Confirmar elección", MessageBoxButtons.YesNo, MessageBoxIcon.Warning); //added

                if (resultado == DialogResult.Yes) //added
                {
                    tvArbol.SelectedNode.Remove();
                    lbActualización.Text = $"El nodo '{nombre}' junto a todos sus subordinados ha sido eliminado exitosamente";
                    ActualizarEstadisticas();
                }
            }
            else
            {
                MessageBox.Show("Selecciona un elemento para borrar", "Error: Nodos Seleccionados == null", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void renombrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tvArbol.Nodes.Count == 0)
                MessageBox.Show("No existen nodos en el Árbol de Jerarquía Empresarial. Primero añade algunos para renombrar", "Error: tvArbol.Nodes.Count == 0", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (tvArbol.SelectedNode != null)
            {
                string nodoSeleccionado = tvArbol.SelectedNode.Text;
                string nombre = ShowInputDialog($"Ingrese el nuevo nombre para el nodo {nodoSeleccionado}", "Renombrar nodo"); //added

                if (string.IsNullOrWhiteSpace(nombre)) return;

                tvArbol.SelectedNode.Text = nombre; //added
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
            mltOrden.Refresh(); //added
        }

        private void RecorridoPreOrden(TreeNode nodo, StringBuilder sb)
        {
            if (nodo == null) return;
            sb.Append(nodo.Text + " -> ");
            foreach (TreeNode hijo in nodo.Nodes) RecorridoPreOrden(hijo, sb);
        }

        private void RecorridoPostOrden(TreeNode nodo, StringBuilder sb)
        {
            if (nodo == null) return;
            foreach (TreeNode hijo in nodo.Nodes) RecorridoPostOrden(hijo, sb);
            sb.Append(nodo.Text + " -> ");
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
                ActualizarListViewStats(0, 0, 0); //added (Argumentos extra)
                return;
            }

            int totalNodos = tvArbol.GetNodeCount(true);
            int altura = CalcularAltura(tvArbol.Nodes[0]);
            int totalHojasArbol = ContarHojasRecursivo(tvArbol.Nodes[0]); //added

            ActualizarListViewStats(totalNodos, altura, totalHojasArbol); //added

            // FIX: Forzar actualización del texto de ordenamiento si hay algo seleccionado en el combo
            if (cbOrdenamiento.SelectedIndex > -1) cbOrdenamiento_SelectedIndexChanged(null, null); //added
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

        // Método nuevo para contar hojas (Nodos sin hijos)
        private int ContarHojasRecursivo(TreeNode nodo) //added
        {
            if (nodo.Nodes.Count == 0) return 1; //added
            int suma = 0; //added
            foreach (TreeNode hijo in nodo.Nodes) suma += ContarHojasRecursivo(hijo); //added
            return suma; //added
        }

        private void ActualizarListViewStats(int total, int niveles, int totalHojas) //added
        {
            lvEstadisticas.Clear();
            lvEstadisticas.View = View.Details;
            lvEstadisticas.Columns.Add("Métrica", 160); //added (Ancho ajustado)
            lvEstadisticas.Columns.Add("Valor", 80);   //added

            // 1. ESTADÍSTICAS GENERALES DEL ÁRBOL
            lvEstadisticas.Items.Add(new ListViewItem(new[] { "--- ÁRBOL GENERAL ---", "" })); //added
            lvEstadisticas.Items.Add(new ListViewItem(new[] { "Total Cargos", total.ToString() }));
            lvEstadisticas.Items.Add(new ListViewItem(new[] { "Total Hojas (Sin cargo a cargo)", totalHojas.ToString() })); //added
            lvEstadisticas.Items.Add(new ListViewItem(new[] { "Altura Máxima", niveles.ToString() }));

            // 2. ESTADÍSTICAS DEL NODO SELECCIONADO
            if (tvArbol.SelectedNode != null) //added
            {
                TreeNode sel = tvArbol.SelectedNode; //added
                int hojasRama = ContarHojasRecursivo(sel); //added

                lvEstadisticas.Items.Add(new ListViewItem(new[] { "", "" })); //added (Separador)
                lvEstadisticas.Items.Add(new ListViewItem(new[] { "--- SELECCIONADO ---", "" })); //added
                lvEstadisticas.Items.Add(new ListViewItem(new[] { "Cargo", sel.Text })); //added
                lvEstadisticas.Items.Add(new ListViewItem(new[] { "Nivel Jerárquico", sel.Level.ToString() })); //added
                lvEstadisticas.Items.Add(new ListViewItem(new[] { "Subordinados Directos", sel.Nodes.Count.ToString() })); //added
                lvEstadisticas.Items.Add(new ListViewItem(new[] { "Hojas en esta rama", hojasRama.ToString() })); //added
            }
        }

        public static string ShowInputDialog(string texto, string titulo)
        {
            int anchoForm = 400; //added
            int margen = 20; //added
            int anchoUtil = anchoForm - (margen * 2); //added

            Form prompt = new Form()
            {
                Width = anchoForm, //added
                Height = 200, //added
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = titulo,
                StartPosition = FormStartPosition.CenterScreen,
                MinimizeBox = false,
                MaximizeBox = false
            };

            Label textLabel = new Label()
            {
                Left = margen, //added
                Top = 20,
                Text = texto,
                AutoSize = true,
                MaximumSize = new Size(anchoUtil, 0) //added
            };

            prompt.Controls.Add(textLabel); //added

            int espacioY = textLabel.Bottom + 15; //added

            TextBox textBox = new TextBox() { Left = margen, Top = espacioY, Width = anchoUtil }; //added
            Button confirmation = new Button() { Text = "Aceptar", Left = 240, Width = 100, Top = espacioY + 35 }; //added

            prompt.Height = confirmation.Bottom + 50; //added

            confirmation.DialogResult = DialogResult.None;

            confirmation.Click += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    MessageBox.Show("¡El nombre es obligatorio!", "Dato Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox.Focus();
                }
                else
                {
                    prompt.DialogResult = DialogResult.OK;
                    prompt.Close();
                }
            };

            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";

        }

        private void materialLabel2_Click(object sender, EventArgs e) { }
        private void lbEstadisticas_Click(object sender, EventArgs e) { }
        private void lbActualización_Click(object sender, EventArgs e) { }
        private void mltOrden_Click(object sender, EventArgs e) { }
        private void lbActualización_Click_1(object sender, EventArgs e) { }
        private void mltOrden_Click_1(object sender, EventArgs e) { }
        private void TL1_Paint(object sender, PaintEventArgs e) { }
        private void TL2_Paint(object sender, PaintEventArgs e) { }
        private void TL3_Paint(object sender, PaintEventArgs e) { }
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) { }
    }
}