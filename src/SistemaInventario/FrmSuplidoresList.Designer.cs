namespace SistemaInventario
{
    partial class FrmSuplidoresList
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
            btnCerrar = new Button();
            btnEliminar = new Button();
            btnEditar = new Button();
            btnNuevo = new Button();
            dgvSuplidores = new DataGridView();
            txtBuscar = new TextBox();
            lblBuscar = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvSuplidores).BeginInit();
            SuspendLayout();
            // 
            // btnCerrar
            // 
            btnCerrar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCerrar.Location = new Point(864, 50);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(112, 42);
            btnCerrar.TabIndex = 13;
            btnCerrar.Text = "Cerrar";
            btnCerrar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnEliminar.Location = new Point(723, 50);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(112, 42);
            btnEliminar.TabIndex = 12;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnEditar
            // 
            btnEditar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnEditar.Location = new Point(575, 50);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(112, 42);
            btnEditar.TabIndex = 11;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            // 
            // btnNuevo
            // 
            btnNuevo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnNuevo.Location = new Point(438, 50);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(112, 42);
            btnNuevo.TabIndex = 10;
            btnNuevo.Text = "Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            // 
            // dgvSuplidores
            // 
            dgvSuplidores.AllowUserToAddRows = false;
            dgvSuplidores.AllowUserToDeleteRows = false;
            dgvSuplidores.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvSuplidores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSuplidores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSuplidores.Location = new Point(12, 125);
            dgvSuplidores.MultiSelect = false;
            dgvSuplidores.Name = "dgvSuplidores";
            dgvSuplidores.ReadOnly = true;
            dgvSuplidores.RowHeadersWidth = 62;
            dgvSuplidores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSuplidores.Size = new Size(1133, 456);
            dgvSuplidores.TabIndex = 9;
            // 
            // txtBuscar
            // 
            txtBuscar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscar.Location = new Point(123, 45);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(263, 39);
            txtBuscar.TabIndex = 8;
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBuscar.Location = new Point(19, 50);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(98, 32);
            lblBuscar.TabIndex = 7;
            lblBuscar.Text = "Buscar:";
            // 
            // FrmSuplidoresList
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1157, 608);
            Controls.Add(btnCerrar);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(btnNuevo);
            Controls.Add(dgvSuplidores);
            Controls.Add(txtBuscar);
            Controls.Add(lblBuscar);
            Name = "FrmSuplidoresList";
            Text = "Suplidores";
            ((System.ComponentModel.ISupportInitialize)dgvSuplidores).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCerrar;
        private Button btnEliminar;
        private Button btnEditar;
        private Button btnNuevo;
        private DataGridView dgvSuplidores;
        private TextBox txtBuscar;
        private Label lblBuscar;
    }
}