using System;
using System.Windows.Forms;

namespace DatagridView
{
    public partial class FrmDetail : Form
    {
        private ContactModel _contact;

        // Constructor único con los parámetros correctos
        public FrmDetail(ContactModel contact = null, Form mdiParent = null)
        {
            InitializeComponent();  // Inicializa los controles
            this.MdiParent = mdiParent;  // Establece el formulario principal como MDI parent

            _contact = contact;// Asigna el modelo del contacto

            // Si se pasa un contacto, configura los campos con los datos existentes
            if (_contact != null)
            {

                txtNombre.Text = _contact.Name;
                txtEmail.Text = _contact.Email;
                txtTelefono.Text = _contact.PhoneNumber;
                lblCrearModificar.Text = "Modificar Contacto";// Cambia el texto del título
            }
            else
            {
                lblCrearModificar.Text = "Crear Nuevo Contacto";// Indica que se está creando un nuevo contacto
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validación de los campos: asegura que no estén vacíos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;// Detiene la ejecución si la validación falla
            }

            try
            {
                if (_contact == null)
                {
                    // Crear nuevo contacto si no existe
                    var newContact = new ContactModel
                    {
                        Name = txtNombre.Text,// Asigna el nombre ingresado al modelo
                        Email = txtEmail.Text,
                        PhoneNumber = txtTelefono.Text
                    };
                    await ApiClient.CreateContactAsync(newContact);// Llama a la API para guardar el nuevo contacto
                }
                else
                {
                    // Actualizar contacto existente
                    _contact.Name = txtNombre.Text;
                    _contact.Email = txtEmail.Text;
                    _contact.PhoneNumber = txtTelefono.Text;
                    await ApiClient.UpdateContactAsync(_contact);
                }
                // Muestra un mensaje de éxito y cierra el formulario
                MessageBox.Show("Operación realizada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                // Manejo de errores: muestra un mensaje con la información del error

                MessageBox.Show($"Error al guardar el contacto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
