namespace casoDeEstudio
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            tabGrafos = new TabControl();
            TabGestionEmpresarial = new TabPage();
            materialCard1 = new MaterialSkin.Controls.MaterialCard();
            TL1 = new TableLayoutPanel();
            TL2 = new TableLayoutPanel();
            TL4 = new TableLayoutPanel();
            lbTitulo = new MaterialSkin.Controls.MaterialLabel();
            tvArbol = new TreeView();
            cmsARbol = new ContextMenuStrip(components);
            agregarCargoToolStripMenuItem = new ToolStripMenuItem();
            elimiarCargoToolStripMenuItem = new ToolStripMenuItem();
            renombrarToolStripMenuItem = new ToolStripMenuItem();
            TL6 = new TableLayoutPanel();
            btnBuscar = new MaterialSkin.Controls.MaterialButton();
            lbActualización = new MaterialSkin.Controls.MaterialLabel();
            TL3 = new TableLayoutPanel();
            TL5 = new TableLayoutPanel();
            lbEstadisticas = new MaterialSkin.Controls.MaterialLabel();
            lvEstadisticas = new ListView();
            TL7 = new TableLayoutPanel();
            TL8 = new TableLayoutPanel();
            cbOrdenamiento = new MaterialSkin.Controls.MaterialComboBox();
            mltOrden = new MaterialSkin.Controls.MaterialMultiLineTextBox2();
            tabPage2 = new TabPage();
            TabL1 = new TableLayoutPanel();
            tabGrafos.SuspendLayout();
            TabGestionEmpresarial.SuspendLayout();
            materialCard1.SuspendLayout();
            TL1.SuspendLayout();
            TL2.SuspendLayout();
            TL4.SuspendLayout();
            cmsARbol.SuspendLayout();
            TL6.SuspendLayout();
            TL3.SuspendLayout();
            TL5.SuspendLayout();
            TL7.SuspendLayout();
            TL8.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // tabGrafos
            // 
            tabGrafos.Controls.Add(TabGestionEmpresarial);
            tabGrafos.Controls.Add(tabPage2);
            tabGrafos.Dock = DockStyle.Fill;
            tabGrafos.Location = new Point(3, 64);
            tabGrafos.Name = "tabGrafos";
            tabGrafos.SelectedIndex = 0;
            tabGrafos.Size = new Size(976, 539);
            tabGrafos.TabIndex = 0;
            // 
            // TabGestionEmpresarial
            // 
            TabGestionEmpresarial.Controls.Add(materialCard1);
            TabGestionEmpresarial.Location = new Point(4, 29);
            TabGestionEmpresarial.Name = "TabGestionEmpresarial";
            TabGestionEmpresarial.Padding = new Padding(3);
            TabGestionEmpresarial.Size = new Size(968, 506);
            TabGestionEmpresarial.TabIndex = 0;
            TabGestionEmpresarial.Text = "Gestión Empresarial";
            TabGestionEmpresarial.UseVisualStyleBackColor = true;
            // 
            // materialCard1
            // 
            materialCard1.BackColor = Color.FromArgb(255, 255, 255);
            materialCard1.Controls.Add(TL1);
            materialCard1.Depth = 0;
            materialCard1.Dock = DockStyle.Fill;
            materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
            materialCard1.Location = new Point(3, 3);
            materialCard1.Margin = new Padding(14);
            materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            materialCard1.Name = "materialCard1";
            materialCard1.Padding = new Padding(14);
            materialCard1.Size = new Size(962, 500);
            materialCard1.TabIndex = 0;
            // 
            // TL1
            // 
            TL1.ColumnCount = 2;
            TL1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.8905869F));
            TL1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 49.1094131F));
            TL1.Controls.Add(TL2, 0, 0);
            TL1.Controls.Add(TL3, 1, 0);
            TL1.Dock = DockStyle.Fill;
            TL1.Location = new Point(14, 14);
            TL1.Name = "TL1";
            TL1.RowCount = 1;
            TL1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            TL1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            TL1.Size = new Size(934, 472);
            TL1.TabIndex = 1;
            // 
            // TL2
            // 
            TL2.ColumnCount = 1;
            TL2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            TL2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            TL2.Controls.Add(TL4, 0, 0);
            TL2.Controls.Add(TL6, 0, 1);
            TL2.Dock = DockStyle.Fill;
            TL2.Location = new Point(3, 3);
            TL2.Name = "TL2";
            TL2.RowCount = 2;
            TL2.RowStyles.Add(new RowStyle(SizeType.Percent, 91.800354F));
            TL2.RowStyles.Add(new RowStyle(SizeType.Percent, 8.199643F));
            TL2.Size = new Size(469, 466);
            TL2.TabIndex = 0;
            // 
            // TL4
            // 
            TL4.ColumnCount = 1;
            TL4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            TL4.Controls.Add(lbTitulo, 0, 0);
            TL4.Controls.Add(tvArbol, 0, 1);
            TL4.Dock = DockStyle.Fill;
            TL4.Location = new Point(3, 3);
            TL4.Name = "TL4";
            TL4.RowCount = 2;
            TL4.RowStyles.Add(new RowStyle(SizeType.Percent, 6.67976427F));
            TL4.RowStyles.Add(new RowStyle(SizeType.Percent, 93.32024F));
            TL4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            TL4.Size = new Size(463, 421);
            TL4.TabIndex = 0;
            // 
            // lbTitulo
            // 
            lbTitulo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbTitulo.AutoSize = true;
            lbTitulo.BorderStyle = BorderStyle.FixedSingle;
            lbTitulo.Depth = 0;
            lbTitulo.Font = new Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            lbTitulo.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            lbTitulo.Location = new Point(3, 0);
            lbTitulo.MouseState = MaterialSkin.MouseState.HOVER;
            lbTitulo.Name = "lbTitulo";
            lbTitulo.Size = new Size(457, 28);
            lbTitulo.TabIndex = 2;
            lbTitulo.Text = "Esquema Jerárquico de la Empresa:";
            lbTitulo.TextAlign = ContentAlignment.MiddleCenter;
            lbTitulo.Click += materialLabel2_Click;
            // 
            // tvArbol
            // 
            tvArbol.ContextMenuStrip = cmsARbol;
            tvArbol.Dock = DockStyle.Fill;
            tvArbol.Location = new Point(3, 31);
            tvArbol.Name = "tvArbol";
            tvArbol.Size = new Size(457, 387);
            tvArbol.TabIndex = 1;
            tvArbol.AfterSelect += tvArbol_AfterSelect;
            // 
            // cmsARbol
            // 
            cmsARbol.ImageScalingSize = new Size(20, 20);
            cmsARbol.Items.AddRange(new ToolStripItem[] { agregarCargoToolStripMenuItem, elimiarCargoToolStripMenuItem, renombrarToolStripMenuItem });
            cmsARbol.Name = "cmsARbol";
            cmsARbol.Size = new Size(177, 76);
            // 
            // agregarCargoToolStripMenuItem
            // 
            agregarCargoToolStripMenuItem.Name = "agregarCargoToolStripMenuItem";
            agregarCargoToolStripMenuItem.Size = new Size(176, 24);
            agregarCargoToolStripMenuItem.Text = "Agregar Cargo";
            // 
            // elimiarCargoToolStripMenuItem
            // 
            elimiarCargoToolStripMenuItem.Name = "elimiarCargoToolStripMenuItem";
            elimiarCargoToolStripMenuItem.Size = new Size(176, 24);
            elimiarCargoToolStripMenuItem.Text = "Elimiar Cargo";
            // 
            // renombrarToolStripMenuItem
            // 
            renombrarToolStripMenuItem.Name = "renombrarToolStripMenuItem";
            renombrarToolStripMenuItem.Size = new Size(176, 24);
            renombrarToolStripMenuItem.Text = "Renombrar";
            // 
            // TL6
            // 
            TL6.ColumnCount = 2;
            TL6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 59.39525F));
            TL6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40.60475F));
            TL6.Controls.Add(btnBuscar, 1, 0);
            TL6.Controls.Add(lbActualización, 0, 0);
            TL6.Dock = DockStyle.Fill;
            TL6.Location = new Point(3, 430);
            TL6.Name = "TL6";
            TL6.RowCount = 1;
            TL6.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            TL6.Size = new Size(463, 33);
            TL6.TabIndex = 1;
            // 
            // btnBuscar
            // 
            btnBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnBuscar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnBuscar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            btnBuscar.Depth = 0;
            btnBuscar.HighEmphasis = true;
            btnBuscar.Icon = null;
            btnBuscar.Location = new Point(279, 6);
            btnBuscar.Margin = new Padding(4, 6, 4, 6);
            btnBuscar.MouseState = MaterialSkin.MouseState.HOVER;
            btnBuscar.Name = "btnBuscar";
            btnBuscar.NoAccentTextColor = Color.Empty;
            btnBuscar.Size = new Size(180, 21);
            btnBuscar.TabIndex = 0;
            btnBuscar.Text = "Buscar Cargo";
            btnBuscar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            btnBuscar.UseAccentColor = false;
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // lbActualización
            // 
            lbActualización.AutoSize = true;
            lbActualización.Depth = 0;
            lbActualización.Dock = DockStyle.Fill;
            lbActualización.Font = new Font("Roboto Medium", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            lbActualización.FontType = MaterialSkin.MaterialSkinManager.fontType.Subtitle2;
            lbActualización.Location = new Point(3, 0);
            lbActualización.MouseState = MaterialSkin.MouseState.HOVER;
            lbActualización.Name = "lbActualización";
            lbActualización.Size = new Size(269, 33);
            lbActualización.TabIndex = 1;
            lbActualización.Text = "Mensaje de actualización";
            lbActualización.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TL3
            // 
            TL3.ColumnCount = 1;
            TL3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            TL3.Controls.Add(TL5, 0, 0);
            TL3.Controls.Add(TL7, 0, 1);
            TL3.Dock = DockStyle.Fill;
            TL3.Location = new Point(478, 3);
            TL3.Name = "TL3";
            TL3.RowCount = 2;
            TL3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            TL3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            TL3.Size = new Size(453, 466);
            TL3.TabIndex = 1;
            // 
            // TL5
            // 
            TL5.ColumnCount = 1;
            TL5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            TL5.Controls.Add(lbEstadisticas, 0, 0);
            TL5.Controls.Add(lvEstadisticas, 0, 1);
            TL5.Dock = DockStyle.Fill;
            TL5.Location = new Point(3, 3);
            TL5.Name = "TL5";
            TL5.RowCount = 2;
            TL5.RowStyles.Add(new RowStyle(SizeType.Percent, 12.0437956F));
            TL5.RowStyles.Add(new RowStyle(SizeType.Percent, 87.95621F));
            TL5.Size = new Size(447, 227);
            TL5.TabIndex = 0;
            // 
            // lbEstadisticas
            // 
            lbEstadisticas.AutoEllipsis = true;
            lbEstadisticas.AutoSize = true;
            lbEstadisticas.BorderStyle = BorderStyle.FixedSingle;
            lbEstadisticas.Depth = 0;
            lbEstadisticas.Dock = DockStyle.Fill;
            lbEstadisticas.Font = new Font("Roboto Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            lbEstadisticas.FontType = MaterialSkin.MaterialSkinManager.fontType.H6;
            lbEstadisticas.Location = new Point(3, 0);
            lbEstadisticas.MouseState = MaterialSkin.MouseState.HOVER;
            lbEstadisticas.Name = "lbEstadisticas";
            lbEstadisticas.Size = new Size(441, 27);
            lbEstadisticas.TabIndex = 2;
            lbEstadisticas.Text = "Estadísticas:";
            lbEstadisticas.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lvEstadisticas
            // 
            lvEstadisticas.Dock = DockStyle.Fill;
            lvEstadisticas.Location = new Point(3, 30);
            lvEstadisticas.Name = "lvEstadisticas";
            lvEstadisticas.Size = new Size(441, 194);
            lvEstadisticas.TabIndex = 1;
            lvEstadisticas.UseCompatibleStateImageBehavior = false;
            // 
            // TL7
            // 
            TL7.ColumnCount = 1;
            TL7.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            TL7.Controls.Add(TL8, 0, 0);
            TL7.Controls.Add(mltOrden, 0, 1);
            TL7.Dock = DockStyle.Fill;
            TL7.Location = new Point(3, 236);
            TL7.Name = "TL7";
            TL7.RowCount = 2;
            TL7.RowStyles.Add(new RowStyle(SizeType.Percent, 22.46696F));
            TL7.RowStyles.Add(new RowStyle(SizeType.Percent, 77.53304F));
            TL7.Size = new Size(447, 227);
            TL7.TabIndex = 1;
            // 
            // TL8
            // 
            TL8.ColumnCount = 1;
            TL8.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            TL8.Controls.Add(cbOrdenamiento, 0, 0);
            TL8.Dock = DockStyle.Fill;
            TL8.Location = new Point(3, 3);
            TL8.Name = "TL8";
            TL8.RowCount = 1;
            TL8.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            TL8.Size = new Size(441, 45);
            TL8.TabIndex = 4;
            TL8.Paint += tableLayoutPanel1_Paint;
            // 
            // cbOrdenamiento
            // 
            cbOrdenamiento.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cbOrdenamiento.AutoResize = false;
            cbOrdenamiento.BackColor = Color.FromArgb(255, 255, 255);
            cbOrdenamiento.Depth = 0;
            cbOrdenamiento.DrawMode = DrawMode.OwnerDrawVariable;
            cbOrdenamiento.DropDownHeight = 174;
            cbOrdenamiento.DropDownStyle = ComboBoxStyle.DropDownList;
            cbOrdenamiento.DropDownWidth = 121;
            cbOrdenamiento.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            cbOrdenamiento.ForeColor = Color.FromArgb(222, 0, 0, 0);
            cbOrdenamiento.FormattingEnabled = true;
            cbOrdenamiento.Hint = "Selecciona el tipo de ordenamiento:";
            cbOrdenamiento.IntegralHeight = false;
            cbOrdenamiento.ItemHeight = 43;
            cbOrdenamiento.Items.AddRange(new object[] { "Pre-orden", "Post-orden", "Por Niveles" });
            cbOrdenamiento.Location = new Point(3, 3);
            cbOrdenamiento.MaxDropDownItems = 4;
            cbOrdenamiento.MouseState = MaterialSkin.MouseState.OUT;
            cbOrdenamiento.Name = "cbOrdenamiento";
            cbOrdenamiento.Size = new Size(435, 49);
            cbOrdenamiento.StartIndex = 0;
            cbOrdenamiento.TabIndex = 0;
            cbOrdenamiento.SelectedIndexChanged += cbOrdenamiento_SelectedIndexChanged;
            // 
            // mltOrden
            // 
            mltOrden.AnimateReadOnly = false;
            mltOrden.BackgroundImageLayout = ImageLayout.None;
            mltOrden.CharacterCasing = CharacterCasing.Normal;
            mltOrden.Depth = 0;
            mltOrden.Dock = DockStyle.Fill;
            mltOrden.HideSelection = true;
            mltOrden.Location = new Point(3, 54);
            mltOrden.MaxLength = 32767;
            mltOrden.MouseState = MaterialSkin.MouseState.OUT;
            mltOrden.Name = "mltOrden";
            mltOrden.PasswordChar = '\0';
            mltOrden.ReadOnly = true;
            mltOrden.ScrollBars = ScrollBars.Vertical;
            mltOrden.SelectedText = "";
            mltOrden.SelectionLength = 0;
            mltOrden.SelectionStart = 0;
            mltOrden.ShortcutsEnabled = true;
            mltOrden.Size = new Size(441, 170);
            mltOrden.TabIndex = 5;
            mltOrden.TabStop = false;
            mltOrden.TextAlign = HorizontalAlignment.Left;
            mltOrden.UseSystemPasswordChar = false;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(TabL1);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(968, 506);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Rutas con Grafos";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // TabL1
            // 
            TabL1.ColumnCount = 2;
            TabL1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            TabL1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            TabL1.Dock = DockStyle.Fill;
            TabL1.Location = new Point(3, 3);
            TabL1.Name = "TabL1";
            TabL1.RowCount = 2;
            TabL1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            TabL1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            TabL1.Size = new Size(962, 500);
            TabL1.TabIndex = 0;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 606);
            Controls.Add(tabGrafos);
            Name = "FrmPrincipal";
            Text = "Estructuras de Árboles y Grafos";
            Load += FrmPrincipal_Load;
            Resize += FrmPrincipal_Load;
            tabGrafos.ResumeLayout(false);
            TabGestionEmpresarial.ResumeLayout(false);
            materialCard1.ResumeLayout(false);
            TL1.ResumeLayout(false);
            TL2.ResumeLayout(false);
            TL4.ResumeLayout(false);
            TL4.PerformLayout();
            cmsARbol.ResumeLayout(false);
            TL6.ResumeLayout(false);
            TL6.PerformLayout();
            TL3.ResumeLayout(false);
            TL5.ResumeLayout(false);
            TL5.PerformLayout();
            TL7.ResumeLayout(false);
            TL8.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabGrafos;
        private TabPage TabGestionEmpresarial;
        private TabPage tabPage2;
        private TableLayoutPanel TabL1;
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private TableLayoutPanel TL1;
        private TableLayoutPanel TL2;
        private TableLayoutPanel TL4;
        private TreeView tvArbol;
        private TableLayoutPanel TL6;
        private TableLayoutPanel TL3;
        private TableLayoutPanel TL5;
        private ListView lvEstadisticas;
        private TableLayoutPanel TL7;
        private MaterialSkin.Controls.MaterialButton btnBuscar;
        private TableLayoutPanel TL8;
        private MaterialSkin.Controls.MaterialLabel lbActualización;
        private MaterialSkin.Controls.MaterialLabel lbTitulo;
        private MaterialSkin.Controls.MaterialLabel lbEstadisticas;
        public MaterialSkin.Controls.MaterialComboBox cbOrdenamiento;
        private MaterialSkin.Controls.MaterialMultiLineTextBox2 mltOrden;
        private ContextMenuStrip cmsARbol;
        private ToolStripMenuItem agregarCargoToolStripMenuItem;
        private ToolStripMenuItem elimiarCargoToolStripMenuItem;
        private ToolStripMenuItem renombrarToolStripMenuItem;
    }
}