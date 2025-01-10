using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

internal class Program
{
    static readonly HttpClient client = new HttpClient();
    static string jwtToken = ""; // Almacena el token JWT

    static async Task Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Elige una acción:");
            Console.WriteLine("1. Iniciar sesión (Login)");
            Console.WriteLine("2. Obtener todos los libros");
            Console.WriteLine("3. Obtener un libro por ID");
            Console.WriteLine("4. Crear un libro");
            Console.WriteLine("5. Actualizar un libro");
            Console.WriteLine("6. Eliminar un libro");
            Console.WriteLine("7. TestException");
            Console.WriteLine("8. Salir");
            Console.Write("Ingresa tu elección: ");

            var opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    await IniciarSesion();
                    break;
                case "2":
                    await ObtenerLibros();
                    break;
                case "3":
                    Console.Write("Ingresa el ID del libro: ");
                    var id = Console.ReadLine();
                    await ObtenerLibroPorId(id);
                    break;
                case "4":
                    await CrearLibro();
                    break;
                case "5":
                    await ActualizarLibro();
                    break;
                case "6":
                    await EliminarLibro();
                    break;
                case "7":
                    await TestExcepcion();
                    break;
                case "8":
                    return;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }

    private async static Task TestExcepcion()
    {
        HttpResponseMessage response = await client.GetAsync("https://localhost:7202/api/libros/testexception");
        if (response.IsSuccessStatusCode)
        {
            var responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine(responseBody);
        }
    }
    static async Task IniciarSesion()
    {
        Console.Write("Nombre de usuario: ");
        var username = Console.ReadLine();
        Console.Write("Contraseña: ");
        var password = Console.ReadLine();

        var credenciales = new { Username = username, Password = password };
        var json = JsonConvert.SerializeObject(credenciales);
        var data = new StringContent(json , Encoding.UTF8 , "application/json");

        var response = await client.PostAsync("https://localhost:7202/api/auth/authenticate", data);
        if (response.IsSuccessStatusCode)
        {
           var result =  await response.Content.ReadAsStringAsync();
           var tokenResponse = JsonConvert.DeserializeObject<dynamic>(result);
           jwtToken = tokenResponse.token;
            Console.WriteLine("Autenticacion existosa: ");

        }
        else
        {
            Console.WriteLine("Error de autenticacion: ");
        }
        //me quede por aqui
    }
    static async Task ObtenerLibros()
    {
        if (string.IsNullOrEmpty(jwtToken))
        {
            Console.WriteLine("Por favor, inicie sesión primero.");
            return;
        }
        HttpResponseMessage response = await client.GetAsync("https://localhost:7202/api/libros");
        if (response.IsSuccessStatusCode)
        {
            var responseBody = await response.Content.ReadAsStringAsync();
            var libros = JsonConvert.DeserializeObject<List<Libro>>(responseBody);
            Console.WriteLine(responseBody);
            Console.WriteLine();
            foreach (var libro in libros)
            {
                Console.WriteLine($"ID: {libro.Id}, Título: {libro.Titulo}, Autor: {libro.Autor}");
            }
        }
        else
        {
            Console.WriteLine("Error al obtener los libros.");
        }
    }

    static async Task ObtenerLibroPorId(string id)
    {
        Console.WriteLine("Autenticando...");
        var autenticado = await AutenticarYObtenerToken();

        if (!autenticado)
        {
            Console.WriteLine("Autenticación fallida, cerrando la aplicación.");
            return;
        }

        if (string.IsNullOrEmpty(jwtToken))
        {
            Console.WriteLine("No se ha autenticado. Por favor, obtenga un token primero.");
            return;
        }

        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", jwtToken);

        HttpResponseMessage response = await client.GetAsync($"https://localhost:7202/api/libros/{id}");
        if (response.IsSuccessStatusCode)
        {
            var responseBody = await response.Content.ReadAsStringAsync();
            var libro = JsonConvert.DeserializeObject<Libro>(responseBody);

            Console.WriteLine($"ID: {libro.Id}, Título: {libro.Titulo}, Autor: {libro.Autor}");
        }
        else
        {
            Console.WriteLine($"Error al obtener el libro con ID {id}. Código de estado: {response.StatusCode}");
        }
    }

    static async Task CrearLibro()
    {
        if (string.IsNullOrEmpty(jwtToken))
        {
            Console.WriteLine("Por favor, inicie sesión primero.");
            return;
        }
        Console.WriteLine("Ingresa los detalles del libro a crear:");
        Console.Write("Título: ");
        var titulo = Console.ReadLine();
        Console.Write("Autor: ");
        var autor = Console.ReadLine();

        var nuevoLibro = new { Titulo = titulo, Autor = autor };
        var json = JsonConvert.SerializeObject(nuevoLibro);
        var data = new StringContent(json, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await client.PostAsync("https://localhost:7202/api/libros", data);
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Libro creado con éxito.");
        }
        else
        {
            Console.WriteLine("Error al crear el libro.");
        }
    }

    static async Task ActualizarLibro()
    {
        if (string.IsNullOrEmpty(jwtToken))
        {
            Console.WriteLine("Por favor, inicie sesión primero.");
            return;
        }
        Console.Write("Ingresa el ID del libro a actualizar: ");
        var id = Console.ReadLine();
        Console.WriteLine("Ingresa los detalles del libro a actualizar:");
        Console.Write("Título: ");
        var titulo = Console.ReadLine();
        Console.Write("Autor: ");
        var autor = Console.ReadLine();

        var libroActualizado = new { Titulo = titulo, Autor = autor };
        var json = JsonConvert.SerializeObject(libroActualizado);
        var data = new StringContent(json, Encoding.UTF8, "application/json");

        HttpResponseMessage response = await client.PutAsync($"https://localhost:7202/api/libros/{id}", data);
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Libro actualizado con éxito.");
        }
        else
        {
            Console.WriteLine($"Error al actualizar el libro con ID {id}.");
        }
    }

    static async Task EliminarLibro()
    {
        if (string.IsNullOrEmpty(jwtToken))
        {
            Console.WriteLine("Por favor, inicie sesión primero.");
            return;
        }
        Console.Write("Ingresa el ID del libro a eliminar: ");
        var id = Console.ReadLine();

        HttpResponseMessage response = await client.DeleteAsync($"https://localhost:7202/api/libros/{id}");
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("Libro eliminado con éxito.");
        }
        else
        {
            Console.WriteLine($"Error al eliminar el libro con ID {id}.");
        }
    }


    static async Task<bool> AutenticarYObtenerToken()
    {
        Console.Write("Nombre de usuario: ");
        var username = Console.ReadLine();
        Console.Write("Contraseña: ");
        var password = Console.ReadLine();

        var credenciales = new { UserName = username, Password = password };
        var json = JsonConvert.SerializeObject(credenciales);
        var data = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await client.PostAsync("https://localhost:7202/api/auth/authenticate", data);
        if (response.IsSuccessStatusCode)
        {
            var result = await response.Content.ReadAsStringAsync();
            var tokenResponse = JsonConvert.DeserializeObject<dynamic>(result);
            jwtToken = tokenResponse.token;
            return true;
        }

        Console.WriteLine("Error de autenticación.");
        return false;
    }
}