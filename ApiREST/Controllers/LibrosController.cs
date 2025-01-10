using ApiREST.Model;
using ApiREST.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiREST.Controllers
{
    // Define el controlador para la gestión de libros en la API.
    // La ruta base para este controlador será "api/libros".
    [ApiController]
    [Route("api/[controller]")]
    public class LibrosController : ControllerBase
    {
        // Inyección de dependencias: el controlador depende del servicio que maneja la lógica de negocio de los libros.
        private readonly LibroService _service;
        // Constructor que recibe el servicio de libros para acceder a la lógica de negocio.
        public LibrosController(LibroService service)
        {
            _service = service;// Asigna el servicio recibido al campo privado.
        }
        // Endpoint para obtener todos los libros. Realiza una consulta asincrónica al servicio.
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var libros = await _service.GetAllLibrosAsync();// Obtiene todos los libros de forma asincrónica.
            return Ok(libros);// Devuelve los libros con una respuesta HTTP 200 (OK).
        }
        // Endpoint para obtener un libro por su ID. La ruta acepta un parámetro "id".
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var libro = await _service.GetLibroByIdAsync(id);// Obtiene un libro por su ID de forma asincrónica.
            if (libro == null)// Si el libro no se encuentra, responde con HTTP 404 (Not Found)
            {
                return NotFound();
            }
            // Si el libro existe, se devuelve con una respuesta HTTP 200 (OK).
            return Ok(libro);
        }
        // Endpoint para crear un nuevo libro. Recibe los datos en el cuerpo de la solicitud.
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Libro nuevoLibro)
        {
            // Verifica si el modelo recibido es válido. Si no lo es, devuelve un error HTTP 400 (Bad Request).
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // Llama al servicio para agregar el libro de forma asincrónica.
            await _service.AddLibroAsync(nuevoLibro);
            // Devuelve una respuesta HTTP 201 (Created) con la ubicación del nuevo recurso.
            return CreatedAtAction(nameof(GetById), new { id = nuevoLibro.Id }, nuevoLibro);
        }
        // Endpoint para actualizar un libro existente. Recibe el ID en la ruta y los nuevos datos en el cuerpo.
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Libro libroActualizado)
        {
            // Verifica si el modelo recibido es válido. Si no lo es, devuelve un error HTTP 400 (Bad Request).
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                libroActualizado.Id = id;// Asigna el ID del libro actualizado.
                await _service.UpdateLibroAsync(libroActualizado);// Llama al servicio para actualizar el libro de forma asincrónica.
                 // Devuelve una respuesta HTTP 204 (No Content) indicando que la actualización fue exitos
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                // Si no se encuentra el libro, responde con HTTP 404 (Not Found).
                return NotFound(ex.Message);
            }
        }
        // Endpoint para eliminar un libro. Recibe el ID del libro a eliminar.
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                // Llama al servicio para eliminar el libro de forma asincrónica.
                await _service.DeleteLibroAsync(id);
                // Devuelve una respuesta HTTP 204 (No Content) indicando que la eliminación fue exitosa.
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                // Si no se encuentra el libro, responde con HTTP 404 (Not Found).
                return NotFound(ex.Message);
            }
        }
    }
}

