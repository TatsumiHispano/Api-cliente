using System;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace DatagridView
{
    public partial class FrmMaster : Form
    {
        public FrmMaster()
        {
            InitializeComponent();  // Inicializa los controles del formulario
        }
        /// Evento que se ejecuta al cargar el formulario.
        private async void FrmMaster_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();// Carga los datos de la API al iniciar el formulario
        }
        /// Carga los contactos desde la API y los muestra en el DataGridView.
        private async Task LoadDataAsync()
        {
            try
            {
                // Obtiene la lista de contactos desde la API
                var contacts = await ApiClient.GetContactsAsync();
                // Mapea los contactos a un formato más simple y los asigna como fuente de datos
                dgvContactos.DataSource = contacts.Select(c => new { c.Id, c.Name, c.Email, c.PhoneNumber }).ToList();
            }
            catch (Exception ex)
            {
                // Muestra un mensaje si ocurre un error al cargar los datos
                MessageBox.Show($"Error al cargar los contactos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// Elimina el contacto seleccionado en el DataGridView.
        public async void EliminarContactoSeleccionado()
        {
            // Verifica si hay filas seleccionadas en el DataGridView
            if (dgvContactos.SelectedRows.Count > 0)
            {
                // Solicita confirmación al usuario antes de eliminar
                var confirmResult = MessageBox.Show(
                    "¿Estás seguro de eliminar este contacto?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo
                );

                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        // Obtiene el ID del contacto seleccionado
                        var contactId = (int)dgvContactos.SelectedRows[0].Cells["Id"].Value;
                        // Llama a la API para eliminar el contacto
                        await ApiClient.DeleteContactAsync(contactId);
                        // Muestra un mensaje de éxito y recarga los datos
                        MessageBox.Show("Contacto eliminado correctamente.");
                        await LoadDataAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar el contacto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona un contacto para eliminar.");
            }
        }
        /// Maneja el doble clic en una celda del DataGridView para editar el contacto.
        private async void dgvContactos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica que la fila seleccionada sea válida
            if (e.RowIndex >= 0)
            {
                // Obtiene el ID del contacto seleccionado
                var contactId = (int)dgvContactos.Rows[e.RowIndex].Cells["Id"].Value;

                try
                {
                    // Obtiene la lista de contactos y busca el contacto seleccionado
                    var contacts = await ApiClient.GetContactsAsync();
                    var selectedContact = contacts.FirstOrDefault(c => c.Id == contactId);

                    if (selectedContact != null)
                    {
                        // Abre el formulario de detalle para editar el contacto
                        FrmDetail frmDetail = new FrmDetail(selectedContact, this);  // Pasa 'this' como mdiParent
                        frmDetail.ShowDialog();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar el contacto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
