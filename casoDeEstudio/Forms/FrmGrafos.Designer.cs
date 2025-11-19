namespace casoDeEstudio.Forms
{
    partial class FrmGrafos
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
            this.cardLienzo = new MaterialSkin.Controls.MaterialCard();
            this.pbLienzo = new System.Windows.Forms.PictureBox();
            this.cardControles = new MaterialSkin.Controls.MaterialCard();
            this.lblInstrucciones = new MaterialSkin.Controls.MaterialLabel();
            this.btnLimpiar = new MaterialSkin.Controls.MaterialButton();
            this.rdRuta = new MaterialSkin.Controls.MaterialRadioButton();
            this.rdArista = new MaterialSkin.Controls.MaterialRadioButton();
            this.rdNodo = new MaterialSkin.Controls.MaterialRadioButton();
            this.rdMover = new MaterialSkin.Controls.MaterialRadioButton();
            this.lblResultado = new MaterialSkin.Controls.MaterialLabel();
            this.cardLienzo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLienzo)).BeginInit();
            this.cardControles.SuspendLayout();
            this.SuspendLayout();
            // 
            // cardLienzo
            // 
            this.cardLienzo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cardLienzo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cardLienzo.Controls.Add(this.pbLienzo);
            this.cardLienzo.Depth = 0;
            this.cardLienzo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cardLienzo.Location = new System.Drawing.Point(17, 150);
            this.cardLienzo.Margin = new System.Windows.Forms.Padding(14);
            this.cardLienzo.MouseState = MaterialSkin.MouseState.HOVER;
            this.cardLienzo.Name = "cardLienzo";
            this.cardLienzo.Padding = new System.Windows.Forms.Padding(14);
            this.cardLienzo.Size = new System.Drawing.Size(950, 480);
            this.cardLienzo.TabIndex = 0;
            // 
            // pbLienzo
            // 
            this.pbLienzo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pbLienzo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbLienzo.Location = new System.Drawing.Point(14, 14);
            this.pbLienzo.Name = "pbLienzo";
            this.pbLienzo.Size = new System.Drawing.Size(922, 452);
            this.pbLienzo.TabIndex = 0;
            this.pbLienzo.TabStop = false;
            this.pbLienzo.Paint += new System.Windows.Forms.PaintEventHandler(this.pbLienzo_Paint);
            this.pbLienzo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbLienzo_MouseDown);
            this.pbLienzo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbLienzo_MouseMove);
            this.pbLienzo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbLienzo_MouseUp);
            // 
            // cardControles
            // 
            this.cardControles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cardControles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cardControles.Controls.Add(this.lblResultado);
            this.cardControles.Controls.Add(this.lblInstrucciones);
            this.cardControles.Controls.Add(this.btnLimpiar);
            this.cardControles.Controls.Add(this.rdRuta);
            this.cardControles.Controls.Add(this.rdArista);
            this.cardControles.Controls.Add(this.rdNodo);
            this.cardControles.Controls.Add(this.rdMover);
            this.cardControles.Depth = 0;
            this.cardControles.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.cardControles.Location = new System.Drawing.Point(17, 75);
            this.cardControles.Margin = new System.Windows.Forms.Padding(14);
            this.cardControles.MouseState = MaterialSkin.MouseState.HOVER;
            this.cardControles.Name = "cardControles";
            this.cardControles.Padding = new System.Windows.Forms.Padding(14);
            this.cardControles.Size = new System.Drawing.Size(950, 65);
            this.cardControles.TabIndex = 1;
            // 
            // lblInstrucciones
            // 
            this.lblInstrucciones.AutoSize = true;
            this.lblInstrucciones.Depth = 0;
            this.lblInstrucciones.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblInstrucciones.FontType = MaterialSkin.MaterialSkinManager.fontType.Caption;
            this.lblInstrucciones.Location = new System.Drawing.Point(580, 14);
            this.lblInstrucciones.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblInstrucciones.Name = "lblInstrucciones";
            this.lblInstrucciones.Size = new System.Drawing.Size(248, 14);
            this.lblInstrucciones.TabIndex = 5;
            this.lblInstrucciones.Text = "Selecciona un modo para interactuar con el mapa";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.AutoSize = false;
            this.btnLimpiar.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnLimpiar.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.btnLimpiar.Depth = 0;
            this.btnLimpiar.HighEmphasis = true;
            this.btnLimpiar.Icon = null;
            this.btnLimpiar.Location = new System.Drawing.Point(840, 10);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnLimpiar.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.NoAccentTextColor = System.Drawing.Color.Empty;
            this.btnLimpiar.Size = new System.Drawing.Size(92, 36);
            this.btnLimpiar.TabIndex = 4;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            this.btnLimpiar.UseAccentColor = false;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // rdRuta
            // 
            this.rdRuta.AutoSize = true;
            this.rdRuta.Depth = 0;
            this.rdRuta.Location = new System.Drawing.Point(410, 14);
            this.rdRuta.Margin = new System.Windows.Forms.Padding(0);
            this.rdRuta.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdRuta.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdRuta.Name = "rdRuta";
            this.rdRuta.Ripple = true;
            this.rdRuta.Size = new System.Drawing.Size(143, 37);
            this.rdRuta.TabIndex = 3;
            this.rdRuta.TabStop = true;
            this.rdRuta.Text = "Calcular Ruta";
            this.rdRuta.UseVisualStyleBackColor = true;
            this.rdRuta.CheckedChanged += new System.EventHandler(this.Modo_CheckedChanged);
            // 
            // rdArista
            // 
            this.rdArista.AutoSize = true;
            this.rdArista.Depth = 0;
            this.rdArista.Location = new System.Drawing.Point(270, 14);
            this.rdArista.Margin = new System.Windows.Forms.Padding(0);
            this.rdArista.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdArista.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdArista.Name = "rdArista";
            this.rdArista.Ripple = true;
            this.rdArista.Size = new System.Drawing.Size(127, 37);
            this.rdArista.TabIndex = 2;
            this.rdArista.TabStop = true;
            this.rdArista.Text = "Crear Ruta";
            this.rdArista.UseVisualStyleBackColor = true;
            this.rdArista.CheckedChanged += new System.EventHandler(this.Modo_CheckedChanged);
            // 
            // rdNodo
            // 
            this.rdNodo.AutoSize = true;
            this.rdNodo.Depth = 0;
            this.rdNodo.Location = new System.Drawing.Point(110, 14);
            this.rdNodo.Margin = new System.Windows.Forms.Padding(0);
            this.rdNodo.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdNodo.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdNodo.Name = "rdNodo";
            this.rdNodo.Ripple = true;
            this.rdNodo.Size = new System.Drawing.Size(144, 37);
            this.rdNodo.TabIndex = 1;
            this.rdNodo.TabStop = true;
            this.rdNodo.Text = "Nuevo Edificio";
            this.rdNodo.UseVisualStyleBackColor = true;
            this.rdNodo.CheckedChanged += new System.EventHandler(this.Modo_CheckedChanged);
            // 
            // rdMover
            // 
            this.rdMover.AutoSize = true;
            this.rdMover.Checked = true;
            this.rdMover.Depth = 0;
            this.rdMover.Location = new System.Drawing.Point(17, 14);
            this.rdMover.Margin = new System.Windows.Forms.Padding(0);
            this.rdMover.MouseLocation = new System.Drawing.Point(-1, -1);
            this.rdMover.MouseState = MaterialSkin.MouseState.HOVER;
            this.rdMover.Name = "rdMover";
            this.rdMover.Ripple = true;
            this.rdMover.Size = new System.Drawing.Size(81, 37);
            this.rdMover.TabIndex = 0;
            this.rdMover.TabStop = true;
            this.rdMover.Text = "Mover";
            this.rdMover.UseVisualStyleBackColor = true;
            this.rdMover.CheckedChanged += new System.EventHandler(this.Modo_CheckedChanged);
            // 
            // lblResultado
            // 
            this.lblResultado.AutoSize = true;
            this.lblResultado.Depth = 0;
            this.lblResultado.Font = new System.Drawing.Font("Roboto", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblResultado.Location = new System.Drawing.Point(580, 35);
            this.lblResultado.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(1, 0);
            this.lblResultado.TabIndex = 6;
            // 
            // FrmGrafos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 650);
            this.Controls.Add(this.cardControles);
            this.Controls.Add(this.cardLienzo);
            this.Name = "FrmGrafos";
            this.Text = "Sistema de Rutas (Grafos)";
            this.cardLienzo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbLienzo)).EndInit();
            this.cardControles.ResumeLayout(false);
            this.cardControles.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialCard cardLienzo;
        private System.Windows.Forms.PictureBox pbLienzo;
        private MaterialSkin.Controls.MaterialCard cardControles;
        private MaterialSkin.Controls.MaterialRadioButton rdMover;
        private MaterialSkin.Controls.MaterialRadioButton rdNodo;
        private MaterialSkin.Controls.MaterialRadioButton rdArista;
        private MaterialSkin.Controls.MaterialRadioButton rdRuta;
        private MaterialSkin.Controls.MaterialButton btnLimpiar;
        private MaterialSkin.Controls.MaterialLabel lblInstrucciones;
        private MaterialSkin.Controls.MaterialLabel lblResultado;
    }
}