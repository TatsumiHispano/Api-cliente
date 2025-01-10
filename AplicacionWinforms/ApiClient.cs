using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DatagridView
{
    public static class ApiClient
    {
        // Define la URL base de la API
        private static readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7202/api/") 
        };

        // Método para obtener todos los contactos
        public static async Task<List<ContactModel>> GetContactsAsync()
        {
            try
            {
                // Realiza una petición GET para obtener los contactos
                var response = await client.GetAsync("libros");
                response.EnsureSuccessStatusCode();  // Lanza excepción si el código de estado no es exitoso

                // Lee la respuesta como un string
                var json = await response.Content.ReadAsStringAsync();

                // Deserializa el JSON a una lista de objetos ContactModel
                return JsonSerializer.Deserialize<List<ContactModel>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch (Exception ex)
            {
                // Si hay un error (conexión fallida, API no responde, etc.), lanzar la excepción
                throw new Exception("Error al obtener los contactos: " + ex.Message);
            }
        }

        // Método para crear un nuevo contacto
        public static async Task CreateContactAsync(ContactModel contact)
        {
            try
            {
                // Serializa el objeto contacto a JSON
                var json = JsonSerializer.Serialize(contact);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Realiza una petición POST para crear el contacto
                var response = await client.PostAsync("libros", content);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el contacto: " + ex.Message);
            }
        }

        // Método para actualizar un contacto existente
        public static async Task UpdateContactAsync(ContactModel contact)
        {
            try
            {
                // Serializa el objeto contacto a JSON
                var json = JsonSerializer.Serialize(contact);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                // Realiza una petición PUT para actualizar el contacto
                var response = await client.PutAsync($"libros/{contact.Id}", content);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el contacto: " + ex.Message);
            }
        }

        // Método para eliminar un contacto
        public static async Task DeleteContactAsync(int id)
        {
            try
            {
                // Realiza una petición DELETE para eliminar el contacto por su ID
                var response = await client.DeleteAsync($"libros/{id}");
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el contacto: " + ex.Message);
            }
        }
    }
}
