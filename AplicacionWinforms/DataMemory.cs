using DatagridView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionClase
{
    /// Clase estática que simula una base de datos en memoria para almacenar contactos.
    static class DataMemory
    {
        /// Lista que almacena los contactos en memoria.
        public static List<ContactModel> Data;
        // Constructor estático para inicializar la lista de contactos.
        static DataMemory()
        {
            // Verifica si la lista 'Data' está inicializada
            if (Data == null)
            {
                // Inicializa la lista con datos de ejemplo (dummy data)
                Data = new List<ContactModel>() {
                    new ContactModel() { Name = "Contacto 1", Email = "contacto1@gmail.com", PhoneNumber = "111"},
                    new ContactModel() { Name = "Contacto 2", Email = "contacto2@gmail.com", PhoneNumber = "222"},
                    new ContactModel() { Name = "Contacto 3", Email = "contacto3@gmail.com", PhoneNumber = "333"},
                    new ContactModel() { Name = "Contacto 4", Email = "contacto4@gmail.com", PhoneNumber = "444"},
                    new ContactModel() { Name = "Contacto 5", Email = "contacto5@gmail.com", PhoneNumber = "555"},
                    new ContactModel() { Name = "Contacto 6", Email = "contacto6@gmail.com", PhoneNumber = "666"},
                    new ContactModel() { Name = "Contacto 7", Email = "contacto7@gmail.com", PhoneNumber = "777"},
                    new ContactModel() { Name = "Contacto 8", Email = "contacto8@gmail.com", PhoneNumber = "888"}
                };
            }
        }
    }
}
