using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;

namespace casoDeEstudio
{
    public partial class FrmPrincipal : MaterialForm
    {
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

        }


        private void tvArbol_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }


        // BUTTONS & COMBOBOX:

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void agregarCargoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // agregar cargo
        }

        private void elimiarCargoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // eliminar cargo
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


    }
}
