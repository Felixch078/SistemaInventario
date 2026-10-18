namespace SistemaInventario
{
    partial class FrmSuplidorEdit
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
            lblNombreEmpresa = new Label();
            txtNombreEmpresa = new TextBox();
            lblTelefono = new Label();
            txtTelefono = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            groupBox1 = new GroupBox();
            txtSitioWeb = new TextBox();
            lblSitioWeb = new Label();
            txtNombreContacto = new TextBox();
            lblNombreContacto = new Label();
            epSuplidor = new ErrorProvider(components);
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)epSuplidor).BeginInit();
            SuspendLayout();
            // 
            // lblNombreEmpresa
            // 
            lblNombreEmpresa.AutoSize = true;
            lblNombreEmpresa.Location = new Point(24, 37);
            lblNombreEmpresa.Name = "lblNombreEmpresa";
            lblNombreEmpresa.Size = new Size(108, 32);
            lblNombreEmpresa.TabIndex = 0;
            lblNombreEmpresa.Text = "Nombre";
            // 
            // txtNombreEmpresa
            // 
            txtNombreEmpresa.Location = new Point(152, 38);
            txtNombreEmpresa.MaxLength = 150;
            txtNombreEmpresa.Name = "txtNombreEmpresa";
            txtNombreEmpresa.Size = new Size(235, 39);
            txtNombreEmpresa.TabIndex = 1;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(24, 130);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(113, 32);
            lblTelefono.TabIndex = 2;
            lblTelefono.Text = "Telefono";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(152, 131);
            txtTelefono.MaxLength = 150;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(235, 39);
            txtTelefono.TabIndex = 3;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(24, 191);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(76, 32);
            lblEmail.TabIndex = 4;
            lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(152, 192);
            txtEmail.MaxLength = 150;
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(235, 39);
            txtEmail.TabIndex = 5;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(55, 310);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(114, 49);
            btnGuardar.TabIndex = 6;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(197, 310);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(121, 49);
            btnCancelar.TabIndex = 7;
            btnCancelar.Text = "cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtSitioWeb);
            groupBox1.Controls.Add(lblSitioWeb);
            groupBox1.Controls.Add(txtNombreContacto);
            groupBox1.Controls.Add(lblNombreContacto);
            groupBox1.Controls.Add(btnCancelar);
            groupBox1.Controls.Add(btnGuardar);
            groupBox1.Controls.Add(txtEmail);
            groupBox1.Controls.Add(lblEmail);
            groupBox1.Controls.Add(txtTelefono);
            groupBox1.Controls.Add(lblTelefono);
            groupBox1.Controls.Add(txtNombreEmpresa);
            groupBox1.Controls.Add(lblNombreEmpresa);
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(11, 8);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(450, 387);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            // 
            // txtSitioWeb
            // 
            txtSitioWeb.Location = new Point(152, 250);
            txtSitioWeb.MaxLength = 150;
            txtSitioWeb.Name = "txtSitioWeb";
            txtSitioWeb.Size = new Size(235, 39);
            txtSitioWeb.TabIndex = 11;
            // 
            // lblSitioWeb
            // 
            lblSitioWeb.AutoSize = true;
            lblSitioWeb.Location = new Point(24, 249);
            lblSitioWeb.Name = "lblSitioWeb";
            lblSitioWeb.Size = new Size(65, 32);
            lblSitioWeb.TabIndex = 10;
            lblSitioWeb.Text = "Web";
            // 
            // txtNombreContacto
            // 
            txtNombreContacto.Location = new Point(152, 85);
            txtNombreContacto.MaxLength = 150;
            txtNombreContacto.Name = "txtNombreContacto";
            txtNombreContacto.Size = new Size(235, 39);
            txtNombreContacto.TabIndex = 9;
            // 
            // lblNombreContacto
            // 
            lblNombreContacto.AutoSize = true;
            lblNombreContacto.Location = new Point(24, 84);
            lblNombreContacto.Name = "lblNombreContacto";
            lblNombreContacto.Size = new Size(117, 32);
            lblNombreContacto.TabIndex = 8;
            lblNombreContacto.Text = "Contacto";
            // 
            // epSuplidor
            // 
            epSuplidor.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            epSuplidor.ContainerControl = this;
            // 
            // FrmSuplidorEdit
            // 
            AcceptButton = btnGuardar;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancelar;
            ClientSize = new Size(487, 407);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmSuplidorEdit";
            StartPosition = FormStartPosition.CenterParent;
            Text = "EditarSuplidor";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)epSuplidor).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label lblNombreEmpresa;
        private TextBox txtNombreEmpresa;
        private Label lblTelefono;
        private TextBox txtTelefono;
        private Label lblEmail;
        private TextBox txtEmail;
        private Button btnGuardar;
        private Button btnCancelar;
        private GroupBox groupBox1;
        private TextBox txtNombreContacto;
        private Label lblNombreContacto;
        private ErrorProvider epSuplidor;
        private TextBox txtSitioWeb;
        private Label lblSitioWeb;
    }
}