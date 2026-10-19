namespace SistemaInventario
{
    partial class FrmReportes
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
            lblReporte = new Label();
            cmbReporte = new ComboBox();
            groupBox1 = new GroupBox();
            dgvReportes = new DataGridView();
            btnCerrar = new Button();
            btnEjecutar = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReportes).BeginInit();
            SuspendLayout();
            // 
            // lblReporte
            // 
            lblReporte.AutoSize = true;
            lblReporte.Location = new Point(21, 40);
            lblReporte.Name = "lblReporte";
            lblReporte.Size = new Size(105, 32);
            lblReporte.TabIndex = 0;
            lblReporte.Text = "Reporte";
            // 
            // cmbReporte
            // 
            cmbReporte.FormattingEnabled = true;
            cmbReporte.Location = new Point(138, 37);
            cmbReporte.Name = "cmbReporte";
            cmbReporte.Size = new Size(412, 40);
            cmbReporte.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgvReportes);
            groupBox1.Controls.Add(btnCerrar);
            groupBox1.Controls.Add(btnEjecutar);
            groupBox1.Controls.Add(cmbReporte);
            groupBox1.Controls.Add(lblReporte);
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(14, 15);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1029, 530);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            // 
            // dgvReportes
            // 
            dgvReportes.AllowUserToAddRows = false;
            dgvReportes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvReportes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReportes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReportes.Location = new Point(20, 93);
            dgvReportes.Name = "dgvReportes";
            dgvReportes.ReadOnly = true;
            dgvReportes.RowHeadersWidth = 62;
            dgvReportes.Size = new Size(991, 420);
            dgvReportes.TabIndex = 4;
            // 
            // btnCerrar
            // 
            btnCerrar.Location = new Point(714, 38);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(119, 47);
            btnCerrar.TabIndex = 3;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            // 
            // btnEjecutar
            // 
            btnEjecutar.Location = new Point(571, 37);
            btnEjecutar.Name = "btnEjecutar";
            btnEjecutar.Size = new Size(127, 47);
            btnEjecutar.TabIndex = 2;
            btnEjecutar.Text = "Ejecutar";
            btnEjecutar.UseVisualStyleBackColor = true;
            // 
            // FrmReportes
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1055, 556);
            Controls.Add(groupBox1);
            Name = "FrmReportes";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Reportes";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReportes).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblReporte;
        private ComboBox cmbReporte;
        private GroupBox groupBox1;
        private DataGridView dgvReportes;
        private Button btnCerrar;
        private Button btnEjecutar;
    }
}