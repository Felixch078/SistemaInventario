namespace SistemaInventario
{
    partial class FrmProductosList
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
            groupBox1 = new GroupBox();
            nudPrecioHasta = new NumericUpDown();
            lblPrecioHasta = new Label();
            btnCerrar = new Button();
            btnEliminar = new Button();
            btnEditar = new Button();
            btnNuevo = new Button();
            dgvProductos = new DataGridView();
            nudPrecioDesde = new NumericUpDown();
            lblPrecioDesde = new Label();
            cmbSuplidor = new ComboBox();
            lblSuplidor = new Label();
            cmbCategoria = new ComboBox();
            lblCategoria = new Label();
            txtBuscar = new TextBox();
            lblBuscar = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudPrecioHasta).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudPrecioDesde).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(nudPrecioHasta);
            groupBox1.Controls.Add(lblPrecioHasta);
            groupBox1.Controls.Add(btnCerrar);
            groupBox1.Controls.Add(btnEliminar);
            groupBox1.Controls.Add(btnEditar);
            groupBox1.Controls.Add(btnNuevo);
            groupBox1.Controls.Add(dgvProductos);
            groupBox1.Controls.Add(nudPrecioDesde);
            groupBox1.Controls.Add(lblPrecioDesde);
            groupBox1.Controls.Add(cmbSuplidor);
            groupBox1.Controls.Add(lblSuplidor);
            groupBox1.Controls.Add(cmbCategoria);
            groupBox1.Controls.Add(lblCategoria);
            groupBox1.Controls.Add(txtBuscar);
            groupBox1.Controls.Add(lblBuscar);
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(18, 22);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1359, 612);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // nudPrecioHasta
            // 
            nudPrecioHasta.DecimalPlaces = 2;
            nudPrecioHasta.Location = new Point(187, 301);
            nudPrecioHasta.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            nudPrecioHasta.Name = "nudPrecioHasta";
            nudPrecioHasta.Size = new Size(256, 39);
            nudPrecioHasta.TabIndex = 14;
            // 
            // lblPrecioHasta
            // 
            lblPrecioHasta.AutoSize = true;
            lblPrecioHasta.Location = new Point(17, 300);
            lblPrecioHasta.Name = "lblPrecioHasta";
            lblPrecioHasta.Size = new Size(153, 32);
            lblPrecioHasta.TabIndex = 13;
            lblPrecioHasta.Text = "Precio hasta";
            // 
            // btnCerrar
            // 
            btnCerrar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCerrar.Location = new Point(218, 456);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(112, 42);
            btnCerrar.TabIndex = 12;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnEliminar.Location = new Point(74, 456);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(112, 42);
            btnEliminar.TabIndex = 11;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            btnEditar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnEditar.Location = new Point(218, 389);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(112, 42);
            btnEditar.TabIndex = 10;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnNuevo
            // 
            btnNuevo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnNuevo.Location = new Point(74, 389);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(112, 42);
            btnNuevo.TabIndex = 9;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Location = new Point(486, 27);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.RowHeadersWidth = 62;
            dgvProductos.Size = new Size(855, 566);
            dgvProductos.TabIndex = 8;
            // 
            // nudPrecioDesde
            // 
            nudPrecioDesde.DecimalPlaces = 2;
            nudPrecioDesde.Location = new Point(187, 248);
            nudPrecioDesde.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            nudPrecioDesde.Name = "nudPrecioDesde";
            nudPrecioDesde.Size = new Size(256, 39);
            nudPrecioDesde.TabIndex = 7;
            // 
            // lblPrecioDesde
            // 
            lblPrecioDesde.AutoSize = true;
            lblPrecioDesde.Location = new Point(17, 247);
            lblPrecioDesde.Name = "lblPrecioDesde";
            lblPrecioDesde.Size = new Size(160, 32);
            lblPrecioDesde.TabIndex = 6;
            lblPrecioDesde.Text = "Precio desde";
            // 
            // cmbSuplidor
            // 
            cmbSuplidor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSuplidor.FormattingEnabled = true;
            cmbSuplidor.Location = new Point(177, 179);
            cmbSuplidor.Name = "cmbSuplidor";
            cmbSuplidor.Size = new Size(266, 40);
            cmbSuplidor.TabIndex = 5;
            // 
            // lblSuplidor
            // 
            lblSuplidor.AutoSize = true;
            lblSuplidor.Location = new Point(17, 178);
            lblSuplidor.Name = "lblSuplidor";
            lblSuplidor.Size = new Size(111, 32);
            lblSuplidor.TabIndex = 4;
            lblSuplidor.Text = "Suplidor";
            // 
            // cmbCategoria
            // 
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(177, 109);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(266, 40);
            cmbCategoria.TabIndex = 3;
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Location = new Point(17, 108);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(124, 32);
            lblCategoria.TabIndex = 2;
            lblCategoria.Text = "Categoria";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(177, 38);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.PlaceholderText = "nombre del producto";
            txtBuscar.Size = new Size(266, 39);
            txtBuscar.TabIndex = 1;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(17, 37);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(90, 32);
            lblBuscar.TabIndex = 0;
            lblBuscar.Text = "Buscar";
            // 
            // FrmProductosList
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1398, 646);
            Controls.Add(groupBox1);
            Name = "FrmProductosList";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Productos";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudPrecioHasta).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudPrecioDesde).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label lblPrecioDesde;
        private ComboBox cmbSuplidor;
        private Label lblSuplidor;
        private ComboBox cmbCategoria;
        private Label lblCategoria;
        private TextBox txtBuscar;
        private Label lblBuscar;
        private DataGridView dgvProductos;
        private NumericUpDown nudPrecioDesde;
        private Button btnCerrar;
        private Button btnEliminar;
        private Button btnEditar;
        private Button btnNuevo;
        private NumericUpDown nudPrecioHasta;
        private Label lblPrecioHasta;
    }
}