namespace SistemaInventario
{
    partial class FrmCategoriaEdit
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
            btnQuitarFoto = new Button();
            btnAgregarFoto = new Button();
            lstFotos = new ListBox();
            lblFotos = new Label();
            txtDescripcion = new TextBox();
            lblDescripcion = new Label();
            txtNombre = new TextBox();
            lblNombre = new Label();
            epCategoria = new ErrorProvider(components);
            ofdFoto = new OpenFileDialog();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)epCategoria).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnCancelar);
            groupBox1.Controls.Add(btnGuardar);
            groupBox1.Controls.Add(btnQuitarFoto);
            groupBox1.Controls.Add(btnAgregarFoto);
            groupBox1.Controls.Add(lstFotos);
            groupBox1.Controls.Add(lblFotos);
            groupBox1.Controls.Add(txtDescripcion);
            groupBox1.Controls.Add(lblDescripcion);
            groupBox1.Controls.Add(txtNombre);
            groupBox1.Controls.Add(lblNombre);
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(569, 462);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Location = new Point(424, 118);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(121, 48);
            btnCancelar.TabIndex = 10;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(424, 45);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(121, 46);
            btnGuardar.TabIndex = 9;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btnQuitarFoto
            // 
            btnQuitarFoto.Location = new Point(196, 366);
            btnQuitarFoto.Name = "btnQuitarFoto";
            btnQuitarFoto.Size = new Size(142, 50);
            btnQuitarFoto.TabIndex = 8;
            btnQuitarFoto.Text = "Quitar";
            btnQuitarFoto.UseVisualStyleBackColor = true;
            // 
            // btnAgregarFoto
            // 
            btnAgregarFoto.Location = new Point(58, 366);
            btnAgregarFoto.Name = "btnAgregarFoto";
            btnAgregarFoto.Size = new Size(121, 50);
            btnAgregarFoto.TabIndex = 7;
            btnAgregarFoto.Text = "Agregar";
            btnAgregarFoto.UseVisualStyleBackColor = true;
            // 
            // lstFotos
            // 
            lstFotos.FormattingEnabled = true;
            lstFotos.HorizontalScrollbar = true;
            lstFotos.Location = new Point(158, 222);
            lstFotos.Name = "lstFotos";
            lstFotos.Size = new Size(180, 100);
            lstFotos.TabIndex = 6;
            // 
            // lblFotos
            // 
            lblFotos.AutoSize = true;
            lblFotos.Location = new Point(31, 222);
            lblFotos.Name = "lblFotos";
            lblFotos.Size = new Size(76, 32);
            lblFotos.TabIndex = 5;
            lblFotos.Text = "Fotos";
            // 
            // txtDescripcion
            // 
            txtDescripcion.HideSelection = false;
            txtDescripcion.Location = new Point(193, 123);
            txtDescripcion.MaxLength = 500;
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.ScrollBars = ScrollBars.Vertical;
            txtDescripcion.Size = new Size(195, 80);
            txtDescripcion.TabIndex = 4;
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(31, 123);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(156, 32);
            lblDescripcion.TabIndex = 3;
            lblDescripcion.Text = "Descripcion:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(188, 45);
            txtNombre.MaxLength = 100;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(200, 39);
            txtNombre.TabIndex = 1;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(31, 45);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(115, 32);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre:";
            // 
            // epCategoria
            // 
            epCategoria.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            epCategoria.ContainerControl = this;
            // 
            // ofdFoto
            // 
            ofdFoto.FileName = "openFileDialog1";
            ofdFoto.Filter = "\"Imágenes|*.jpg;*.jpeg;*.png\"";
            // 
            // FrmCategoriaEdit
            // 
            AcceptButton = btnGuardar;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancelar;
            ClientSize = new Size(593, 492);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmCategoriaEdit";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Editar Categoria";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)epCategoria).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label lblDescripcion;
        private TextBox txtNombre;
        private Label lblNombre;
        private Button btnCancelar;
        private Button btnGuardar;
        private Button btnQuitarFoto;
        private Button btnAgregarFoto;
        private ListBox lstFotos;
        private Label lblFotos;
        private TextBox txtDescripcion;
        private ErrorProvider epCategoria;
        private OpenFileDialog ofdFoto;
    }
}