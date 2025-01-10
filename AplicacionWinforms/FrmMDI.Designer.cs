namespace DatagridView
{
    partial class FrmMDI
    {
        // Declaración de los componentes del formulario
        private System.ComponentModel.IContainer components = null; // Contenedor para recursos
        private System.Windows.Forms.MenuStrip menuStrip1; // Barra de menú principal
        private System.Windows.Forms.ToolStripMenuItem listadoToolStripMenuItem; // Opción de menú para el listado de contactos
        private System.Windows.Forms.ToolStripMenuItem crearNuevoContactoToolStripMenuItem; // Opción de menú para crear un nuevo contacto
        private System.Windows.Forms.ToolStripMenuItem eliminarContactoToolStripMenuItem; // Opción de menú para eliminar un contacto

        /// <summary>
        /// Limpia los recursos en uso.
        /// </summary>
        /// <param name="disposing">
        /// Indica si se deben liberar los recursos administrados.
        /// </param>
        protected override void Dispose(bool disposing)
        {
            // Liberar recursos si es necesario
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Método requerido para el soporte del diseñador.
        /// No modificar el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            // Inicializa la barra de menú
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.listadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem(); // Opción para mostrar el listado de contactos
            this.crearNuevoContactoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem(); // Opción para crear un nuevo contacto
            this.eliminarContactoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem(); // Opción para eliminar un contacto

            // Configuración de la barra de menú
            // Se añaden las opciones al menú
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.listadoToolStripMenuItem,
                this.crearNuevoContactoToolStripMenuItem,
                this.eliminarContactoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0); // Posición de la barra de menú
            this.menuStrip1.Name = "menuStrip1"; // Nombre de referencia de la barra de menú
            this.menuStrip1.Size = new System.Drawing.Size(800, 24); // Tamaño de la barra de menú
            this.menuStrip1.TabIndex = 0; // Índice de tabulación
            this.menuStrip1.Text = "menuStrip1"; // Texto por defecto para la barra de menú

            // Configuración de la opción "Listado de contactos"
            this.listadoToolStripMenuItem.Name = "listadoToolStripMenuItem";
            this.listadoToolStripMenuItem.Size = new System.Drawing.Size(128, 20); // Tamaño del elemento
            this.listadoToolStripMenuItem.Text = "Listado de contactos"; // Texto que se muestra en la opción
            this.listadoToolStripMenuItem.Click += new System.EventHandler(this.listadoToolStripMenuItem_Click); // Evento al hacer clic

            // Configuración de la opción "Crear nuevo contacto"
            this.crearNuevoContactoToolStripMenuItem.Name = "crearNuevoContactoToolStripMenuItem";
            this.crearNuevoContactoToolStripMenuItem.Size = new System.Drawing.Size(133, 20); // Tamaño del elemento
            this.crearNuevoContactoToolStripMenuItem.Text = "Crear nuevo contacto"; // Texto que se muestra en la opción
            this.crearNuevoContactoToolStripMenuItem.Click += new System.EventHandler(this.crearNuevoContactoToolStripMenuItem_Click); // Evento al hacer clic

            // Configuración de la opción "Eliminar contacto"
            this.eliminarContactoToolStripMenuItem.Name = "eliminarContactoToolStripMenuItem";
            this.eliminarContactoToolStripMenuItem.Size = new System.Drawing.Size(112, 20); // Tamaño del elemento
            this.eliminarContactoToolStripMenuItem.Text = "Eliminar contacto"; // Texto que se muestra en la opción
            this.eliminarContactoToolStripMenuItem.Click += new System.EventHandler(this.eliminarContactoToolStripMenuItem_Click); // Evento al hacer clic

            // Configuración del formulario principal (FrmMDI)
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F); // Escalado automático de dimensiones
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font; // Modo de escalado automático
            this.ClientSize = new System.Drawing.Size(800, 450); // Tamaño del formulario
            this.Controls.Add(this.menuStrip1); // Añade la barra de menú al formulario
            this.IsMdiContainer = true; // Configura el formulario como contenedor MDI
            this.MainMenuStrip = this.menuStrip1; // Establece la barra de menú como la principal
            this.Name = "FrmMDI"; // Nombre del formulario
            this.Text = "FrmMDI"; // Texto del título del formulario
            this.Load += new System.EventHandler(this.FrmMDI_Load); // Evento al cargar el formulario

            // Finaliza la configuración de la barra de menú
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
        }
    }
}