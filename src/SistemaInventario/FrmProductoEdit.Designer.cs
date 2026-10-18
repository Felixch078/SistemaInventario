namespace SistemaInventario
{
    partial class FrmProductoEdit
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
            groupBox1 = new GroupBox();
            btnCancelar = new Button();
            btnGuardar = new Button();
            cmbSuplidor = new ComboBox();
            label1 = new Label();
            cmbCategoria = new ComboBox();
            lblCategoria = new Label();
            nudPrecio = new NumericUpDown();
            lblPrecio = new Label();
            txtNombre = new TextBox();
            lblNombre = new Label();
            epProducto = new ErrorProvider(components);
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudPrecio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)epProducto).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnCancelar);
            groupBox1.Controls.Add(btnGuardar);
            groupBox1.Controls.Add(cmbSuplidor);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(cmbCategoria);
            groupBox1.Controls.Add(lblCategoria);
            groupBox1.Controls.Add(nudPrecio);
            groupBox1.Controls.Add(lblPrecio);
            groupBox1.Controls.Add(txtNombre);
            groupBox1.Controls.Add(lblNombre);
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(477, 401);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(197, 306);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(129, 51);
            btnCancelar.TabIndex = 9;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(31, 306);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(123, 51);
            btnGuardar.TabIndex = 8;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // cmbSuplidor
            // 
            cmbSuplidor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSuplidor.FormattingEnabled = true;
            cmbSuplidor.Location = new Point(167, 226);
            cmbSuplidor.Name = "cmbSuplidor";
            cmbSuplidor.Size = new Size(249, 40);
            cmbSuplidor.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 219);
            label1.Name = "label1";
            label1.Size = new Size(133, 32);
            label1.TabIndex = 6;
            label1.Text = "suplidores";
            // 
            // cmbCategoria
            // 
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(167, 154);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(249, 40);
            cmbCategoria.TabIndex = 5;
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Location = new Point(21, 157);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(124, 32);
            lblCategoria.TabIndex = 4;
            lblCategoria.Text = "Categoria";
            // 
            // nudPrecio
            // 
            nudPrecio.DecimalPlaces = 2;
            nudPrecio.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            nudPrecio.Location = new Point(167, 98);
            nudPrecio.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            nudPrecio.Minimum = new decimal(new int[] { 1, 0, 0, 131072 });
            nudPrecio.Name = "nudPrecio";
            nudPrecio.Size = new Size(249, 39);
            nudPrecio.TabIndex = 3;
            nudPrecio.ThousandsSeparator = true;
            nudPrecio.Value = new decimal(new int[] { 1, 0, 0, 131072 });
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(21, 103);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(86, 32);
            lblPrecio.TabIndex = 2;
            lblPrecio.Text = "Precio";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(167, 27);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(249, 39);
            txtNombre.TabIndex = 1;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(21, 27);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(108, 32);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre";
            // 
            // epProducto
            // 
            epProducto.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            epProducto.ContainerControl = this;
            // 
            // FrmProductoEdit
            // 
            AcceptButton = btnGuardar;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancelar;
            ClientSize = new Size(508, 441);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "FrmProductoEdit";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Editar Producto";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudPrecio).EndInit();
            ((System.ComponentModel.ISupportInitialize)epProducto).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private ComboBox cmbCategoria;
        private Label lblCategoria;
        private NumericUpDown nudPrecio;
        private Label lblPrecio;
        private TextBox txtNombre;
        private Label lblNombre;
        private Button btnCancelar;
        private Button btnGuardar;
        private ComboBox cmbSuplidor;
        private Label label1;
        private ErrorProvider epProducto;
    }
}