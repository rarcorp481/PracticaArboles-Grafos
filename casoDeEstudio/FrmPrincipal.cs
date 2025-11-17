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

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }


        private void TL1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TL2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TL3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
