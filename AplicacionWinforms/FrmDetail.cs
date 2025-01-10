namespace DatagridView
{
    partial class FrmDetail
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
            // Libera los componentes si es necesario antes de liberar otros recursos
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            // Creación y configuración del TextBox para el campo
            txtNombre = new TextBox();
            txtEmail = new TextBox();
            txtTelefono = new TextBox();
            lblCrearModificar = new Label();
            btnGuardar = new Button();
           
            SuspendLayout();
            // 
            // txtNombre
            // 
            // Configuración del campo de texto para ingresar el nombre
            txtNombre.Location = new Point(110, 112);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(262, 23);
            txtNombre.TabIndex = 0;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(110, 166);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(262, 23);
            txtEmail.TabIndex = 1;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(110, 224);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(262, 23);
            txtTelefono.TabIndex = 2;


            // 
            // lblCrearModificar
            // 
            // Etiqueta que muestra el propósito del formulario (Crear/Modificar)
            lblCrearModificar.AutoSize = true;
            lblCrearModificar.Font = new Font("Segoe UI", 19F);
            lblCrearModificar.Location = new Point(122, 36);
            lblCrearModificar.Name = "lblCrearModificar";
            lblCrearModificar.Size = new Size(240, 36);
            lblCrearModificar.TabIndex = 7;
            lblCrearModificar.Text = "CREAR/MODIFICAR";
            // 
            // btnGuardar
            // 
            // Botón para guardar los datos ingresados
            btnGuardar.Location = new Point(110, 272);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.TabIndex = 6;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // FrmDetail
            // 
            // Configuración general del formulario
            ClientSize = new Size(546, 358);
            Controls.Add(txtNombre);
            Controls.Add(txtEmail);
            Controls.Add(txtTelefono);
            Controls.Add(lblCrearModificar);
            Controls.Add(btnGuardar);
            Name = "FrmDetail";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        // Declaración de los controles utilizados en el formulario
        private TextBox txtNombre;
        private TextBox txtEmail;
        private TextBox txtTelefono;
        private Label lblCrearModificar;
        private Button btnGuardar;
    }
}

