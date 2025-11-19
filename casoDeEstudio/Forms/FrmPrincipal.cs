
using System.Text;
using MaterialSkin;
using MaterialSkin.Controls;
using casoDeEstudio.TreeManager;
using casoDeEstudio.PopUpForms;


namespace casoDeEstudio
{
    public partial class FrmPrincipal : MaterialForm
    {

        public object MessageBoxIcons { get; private set; }

        public FrmPrincipal()
        {
            InitializeComponent();

            // Configuración de los colores de MaterialSkin.2
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

        // Este evento dispara la actualización de estadísticas al seleccionar un nodo
        private void tvArbol_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ActualizarEstadisticas(); 
        }

        // BUTTONS & COMBOBOX:

        private void BtnBuscarArbol_Click(object sender, EventArgs e)
        {
            CargoManager.BuscarCargo(tvArbol);
        }

        private void agregarCargoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CargoManager.AddCargo(tvArbol.Nodes, tvArbol.SelectedNode, lbActualización);
            ActualizarEstadisticas();
        }

        private void elimiarCargoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CargoManager.RemoveCargo(tvArbol.Nodes, tvArbol.SelectedNode, lbActualización);
            ActualizarEstadisticas();
        }

        private void renombrarToolStripMenuItem_Click(object sender, EventArgs e)
        { 
            CargoManager.RenameCargo(tvArbol.SelectedNode, lbActualización);
            mltOrden.Refresh(); // al final no supe como actualizar este textbox especial de MaterialSkin.2 
        }


        private void cbOrdenamiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tvArbol.Nodes.Count == 0)
            {
                mltOrden.Text = "El árbol está vacío.";
                mltOrden.Refresh();
                return;
            }

            string tipoOrden = cbOrdenamiento.Text;
            StringBuilder resultado = new StringBuilder();
            TreeNode raiz = tvArbol.Nodes[0];

            switch (tipoOrden)
            {
                case "Pre-orden":
                    RecorridoPreOrden(raiz, resultado);
                    mltOrden.Text = resultado.ToString();
                    mltOrden.Refresh();
                    break;
                case "Post-orden":
                    RecorridoPostOrden(raiz, resultado);
                    mltOrden.Text = resultado.ToString();
                    mltOrden.Refresh();
                    break;
                case "Por Niveles":
                    RecorridoPorNiveles(raiz, resultado);
                    mltOrden.Text = resultado.ToString();
                    mltOrden.Refresh();
                    break;
            }
        }

        //Métodos de recorrido para el switch de arriba
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
                ActualizarListViewStats(0, 0, 0);
                return;
            }

            int totalNodos = tvArbol.GetNodeCount(true);
            int altura = CalcularAltura(tvArbol.Nodes[0]);
            int totalHojasArbol = ContarHojasRecursivo(tvArbol.Nodes[0]); 

            ActualizarListViewStats(totalNodos, altura, totalHojasArbol); 

            if (cbOrdenamiento.SelectedIndex > -1) cbOrdenamiento_SelectedIndexChanged(null, null); 
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
        private int ContarHojasRecursivo(TreeNode nodo) 
        {
            if (nodo.Nodes.Count == 0) return 1; 
            int suma = 0; 
            foreach (TreeNode hijo in nodo.Nodes) suma += ContarHojasRecursivo(hijo); 
            return suma; 
        }

        private void ActualizarListViewStats(int total, int niveles, int totalHojas) 
        {
            lvEstadisticas.Clear();
            lvEstadisticas.View = View.Details;
            lvEstadisticas.Columns.Add("Métrica", 900); // Ancho ajustado para mejor visualización
            lvEstadisticas.Columns.Add("Valor", 300);   

            // 1. ESTADÍSTICAS GENERALES DEL ÁRBOL
            lvEstadisticas.Items.Add(new ListViewItem(new[] { "--- ÁRBOL GENERAL ---", "" })); 
            lvEstadisticas.Items.Add(new ListViewItem(new[] { "Total Cargos", total.ToString() }));
            lvEstadisticas.Items.Add(new ListViewItem(new[] { "Total Hojas (Sin cargo a cargo)", totalHojas.ToString() })); 
            lvEstadisticas.Items.Add(new ListViewItem(new[] { "Altura Máxima", niveles.ToString() }));

            // 2. ESTADÍSTICAS DEL NODO SELECCIONADO
            if (tvArbol.SelectedNode != null) 
            {
                TreeNode sel = tvArbol.SelectedNode; 
                int hojasRama = ContarHojasRecursivo(sel); 

                lvEstadisticas.Items.Add(new ListViewItem(new[] { "", "" }));
                lvEstadisticas.Items.Add(new ListViewItem(new[] { "--- SELECCIONADO ---", "" })); 
                lvEstadisticas.Items.Add(new ListViewItem(new[] { "Cargo", sel.Text })); 
                lvEstadisticas.Items.Add(new ListViewItem(new[] { "Nivel Jerárquico", sel.Level.ToString() })); 
                lvEstadisticas.Items.Add(new ListViewItem(new[] { "Subordinados Directos", sel.Nodes.Count.ToString() })); 
                lvEstadisticas.Items.Add(new ListViewItem(new[] { "Hojas en esta rama", hojasRama.ToString() })); 
            }
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