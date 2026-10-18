namespace SistemaInventario
{
    partial class FrmPapelera
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
            lblEntidad = new Label();
            cmbEntidad = new ComboBox();
            dgvPapelera = new DataGridView();
            btnRestaurar = new Button();
            btnCerrar = new Button();
            lblInfo = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvPapelera).BeginInit();
            SuspendLayout();
            // 
            // lblEntidad
            // 
            lblEntidad.AutoSize = true;
            lblEntidad.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblEntidad.Location = new Point(28, 89);
            lblEntidad.Name = "lblEntidad";
            lblEntidad.Size = new Size(101, 32);
            lblEntidad.TabIndex = 0;
            lblEntidad.Text = "Entidad";
            // 
            // cmbEntidad
            // 
            cmbEntidad.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            cmbEntidad.FormattingEnabled = true;
            cmbEntidad.Items.AddRange(new object[] { "Categorias", "Suplidores", "Productos" });
            cmbEntidad.Location = new Point(135, 89);
            cmbEntidad.Name = "cmbEntidad";
            cmbEntidad.Size = new Size(314, 40);
            cmbEntidad.TabIndex = 1;
            // 
            // dgvPapelera
            // 
            dgvPapelera.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPapelera.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPapelera.Location = new Point(25, 153);
            dgvPapelera.Name = "dgvPapelera";
            dgvPapelera.ReadOnly = true;
            dgvPapelera.RowHeadersWidth = 62;
            dgvPapelera.Size = new Size(1177, 447);
            dgvPapelera.TabIndex = 2;
            // 
            // btnRestaurar
            // 
            btnRestaurar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnRestaurar.Location = new Point(507, 84);
            btnRestaurar.Name = "btnRestaurar";
            btnRestaurar.Size = new Size(162, 48);
            btnRestaurar.TabIndex = 3;
            btnRestaurar.Text = "Restaurar";
            btnRestaurar.UseVisualStyleBackColor = true;
            // 
            // btnCerrar
            // 
            btnCerrar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCerrar.Location = new Point(709, 81);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(162, 48);
            btnCerrar.TabIndex = 9;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblInfo.Location = new Point(27, 28);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(659, 32);
            lblInfo.TabIndex = 10;
            lblInfo.Text = "Seleccione una entidad para ver los registros eliminados";
            // 
            // FrmPapelera
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1244, 612);
            Controls.Add(lblInfo);
            Controls.Add(btnCerrar);
            Controls.Add(btnRestaurar);
            Controls.Add(dgvPapelera);
            Controls.Add(cmbEntidad);
            Controls.Add(lblEntidad);
            Name = "FrmPapelera";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Papelera";
            ((System.ComponentModel.ISupportInitialize)dgvPapelera).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblEntidad;
        private ComboBox cmbEntidad;
        private DataGridView dgvPapelera;
        private Button btnRestaurar;
        private Button btnCerrar;
        private Label lblInfo;
    }
}