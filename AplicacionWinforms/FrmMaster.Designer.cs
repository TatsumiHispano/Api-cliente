namespace DatagridView
{
    partial class FrmMaster
    {
        /// <summary>
        /// Variable requerida por el diseñador.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpia los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))// Libera los recursos gestionados
            {
                components.Dispose();// Libera los recursos no gestionados
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Método requerido para el soporte del Diseñador.
        /// No modificar el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvContactos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContactos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvContactos
            // 
            // Configuración del DataGridView
            this.dgvContactos.AllowUserToAddRows = false; // No permite agregar filas manualmente
            this.dgvContactos.AllowUserToDeleteRows = false; // No permite eliminar filas manualmente
            this.dgvContactos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill; // Ajusta el ancho de las columnas automáticamente
            this.dgvContactos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize; // Configura el tamaño automático de las cabeceras
            this.dgvContactos.Dock = System.Windows.Forms.DockStyle.Fill; // Hace que el DataGridView ocupe todo el espacio disponible en el formulario
            this.dgvContactos.Location = new System.Drawing.Point(0, 0); // Establece la posición inicial
            this.dgvContactos.Name = "dgvContactos"; // Nombre del control
            this.dgvContactos.ReadOnly = true; // Define el control como solo lectura
            this.dgvContactos.RowHeadersVisible = false; // Oculta las cabeceras de las filas
            this.dgvContactos.RowTemplate.Height = 25; // Altura de las filas
            this.dgvContactos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect; // Permite seleccionar filas completas
            this.dgvContactos.Size = new System.Drawing.Size(800, 450); // Dimensiones iniciales del control
            this.dgvContactos.TabIndex = 0; // Orden de tabulación
            // Evento para manejar el doble clic en una celda
            this.dgvContactos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvContactos_CellDoubleClick);

            // 
            // FrmMaster
            // 
            // Configuración del formulario principal
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F); // Escalado automático para fuentes
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font; // Escalado basado en la fuente
            this.ClientSize = new System.Drawing.Size(800, 450); // Tamaño del formulario
            this.Controls.Add(this.dgvContactos); // Agrega el DataGridView al formulario
            this.Name = "FrmMaster"; // Nombre del formulario
            this.Text = "Listado de Contactos"; // Título del formulario
            // Evento para manejar la carga del formulario
            this.Load += new System.EventHandler(this.FrmMaster_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvContactos)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        // Control DataGridView para mostrar la lista de contactos
        private System.Windows.Forms.DataGridView dgvContactos;
    }
}
