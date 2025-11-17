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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // botón buscar cargo
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
            if (tvArbol.Nodes.Count == 0) MessageBox.Show("No existen nodos en el Árbol de Jerarquía Empresarial. Primero añade algunos para eliminar", "Error: Árbol sin nodos", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        }

        private void cbOrdenamiento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // lABELS:

        private void materialLabel2_Click(object sender, EventArgs e)
        {
            // label de título 
        }

        private void lbEstadisticas_Click(object sender, EventArgs e)
        {

        }

        private void lbActualización_Click(object sender, EventArgs e)
        {

        }

        private void mltOrden_Click(object sender, EventArgs e)
        {

        }

        // TABLELAYOUTS:

        private void TL1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TL2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TL3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

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
        public static void ActualizarEstadisticas()
        {

        }

        private void lbActualización_Click_1(object sender, EventArgs e)
        {
            
        }
    }
}
