namespace SistemaInventario
{
    partial class FormPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            menuStrip1 = new MenuStrip();
            MenuCategorias = new ToolStripMenuItem();
            menuSuplidores = new ToolStripMenuItem();
            menuProductos = new ToolStripMenuItem();
            menuPapelera = new ToolStripMenuItem();
            menuReportes = new ToolStripMenuItem();
            MenuSalir = new ToolStripMenuItem();
            pictureBox1 = new PictureBox();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.ActiveCaption;
            menuStrip1.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { MenuCategorias, menuSuplidores, menuProductos, menuPapelera, menuReportes, MenuSalir });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 38);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // MenuCategorias
            // 
            MenuCategorias.Name = "MenuCategorias";
            MenuCategorias.Size = new Size(140, 34);
            MenuCategorias.Text = "Categorias";
            // 
            // menuSuplidores
            // 
            menuSuplidores.Name = "menuSuplidores";
            menuSuplidores.Size = new Size(138, 34);
            menuSuplidores.Text = "Suplidores";
            // 
            // menuProductos
            // 
            menuProductos.Name = "menuProductos";
            menuProductos.Size = new Size(135, 34);
            menuProductos.Text = "Productos";
            // 
            // menuPapelera
            // 
            menuPapelera.Name = "menuPapelera";
            menuPapelera.Size = new Size(119, 34);
            menuPapelera.Text = "Papelera";
            // 
            // menuReportes
            // 
            menuReportes.Name = "menuReportes";
            menuReportes.Size = new Size(122, 34);
            menuReportes.Text = "Reportes";
            // 
            // MenuSalir
            // 
            MenuSalir.Name = "MenuSalir";
            MenuSalir.Size = new Size(74, 34);
            MenuSalir.Text = "Salir";
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 38);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(800, 412);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // FormPrincipal
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FormPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema Invetario";
            WindowState = FormWindowState.Maximized;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem MenuCategorias;
        private ToolStripMenuItem menuSuplidores;
        private ToolStripMenuItem menuProductos;
        private ToolStripMenuItem menuPapelera;
        private ToolStripMenuItem menuReportes;
        private ToolStripMenuItem MenuSalir;
        private PictureBox pictureBox1;
    }
}
