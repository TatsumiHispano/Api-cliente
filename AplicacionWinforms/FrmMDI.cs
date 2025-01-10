using System;
using System.Windows.Forms;

namespace DatagridView
{
    public partial class FrmMDI : Form
    {
        // Referencias a los formularios secundarios
        public FrmMaster frmMaster; // Formulario de listado de contactos
        public FrmDetail frmDetail; // Formulario de detalles para crear/modificar contactos

        public FrmMDI()
        {
            InitializeComponent(); // Inicializa los controles definidos en FrmMDI.Designer.cs
        }

        // Evento que se ejecuta al cargar el formulario principal (MDI)
        private void FrmMDI_Load(object sender, EventArgs e)
        {
            OpenMasterForm(); // Abre el formulario de listado de contactos por defecto
        }

        // Evento asociado al menú "Listado" para abrir el formulario de listado
        private void listadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenMasterForm(); // Abre o enfoca el formulario FrmMaster
        }

        // Método para abrir o enfocar el formulario de listado de contactos (FrmMaster)
        public void OpenMasterForm()
        {
            // Si el formulario FrmMaster no existe o ha sido cerrado, crea una nueva instancia
            if (frmMaster == null || frmMaster.IsDisposed)
            {
                frmMaster = new FrmMaster(); // Crea una instancia del formulario de listado
                frmMaster.MdiParent = this; // Establece este formulario MDI como padre
                frmMaster.WindowState = FormWindowState.Maximized; // Maximiza el formulario
                frmMaster.Show(); // Muestra el formulario
            }

            // Oculta el formulario FrmDetail si está abierto
            if (frmDetail != null && !frmDetail.IsDisposed)
            {
                frmDetail.Hide();
            }
        }

        // Evento asociado al menú "Crear Nuevo Contacto"
        private void crearNuevoContactoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenDetailForm(); // Abre el formulario de creación/modificación de contactos
        }

        // Método para abrir o enfocar el formulario de detalles (FrmDetail)
        public void OpenDetailForm()
        {
            // Si el formulario FrmDetail no existe o ha sido cerrado, crea una nueva instancia
            if (frmDetail == null || frmDetail.IsDisposed)
            {
                frmDetail = new FrmDetail(); // Crea una instancia del formulario de detalles
                frmDetail.MdiParent = this; // Establece este formulario MDI como padre
                frmDetail.WindowState = FormWindowState.Maximized; // Maximiza el formulario
                frmDetail.Show(); // Muestra el formulario
            }

            // Oculta el formulario FrmMaster si está abierto
            if (frmMaster != null && !frmMaster.IsDisposed)
            {
                frmMaster.Hide();
            }
        }

        // Evento asociado al menú "Eliminar Contacto"
        private void eliminarContactoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Si el formulario FrmMaster está abierto, llama a su método para eliminar el contacto seleccionado
            if (frmMaster != null && !frmMaster.IsDisposed)
            {
                frmMaster.EliminarContactoSeleccionado();
            }
        }
    }
}