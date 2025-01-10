using ApiREST.Model;
using ApiREST.Repositories;

namespace ApiREST.Services
{
    public class LibroService
    {
        // Inyección de dependencias: 'LibroRepository' se inyecta para poder acceder a los métodos de acceso a datos.
        private readonly LibroRepository _repository;
        // Constructor que recibe el repositorio y lo asigna a la variable '_repository'.
        public LibroService(LibroRepository repository)
        {
            _repository = repository;
        }

        // Obtener todos los libros
        public async Task<List<Libro>> GetAllLibrosAsync()
        {
            // Llama al repositorio para obtener todos los libros de la base de datos.
            return await _repository.GetAllAsync();
        }

        // Obtener un libro por ID
        public async Task<Libro?> GetLibroByIdAsync(int id)
        {
            // Llama al repositorio para buscar el libro por ID.
            return await _repository.GetByIdAsync(id);
        }

        // Crear un nuevo libro
        public async Task AddLibroAsync(Libro libro)
        {
            // Valida si el título o el autor están vacíos o son nulos. Si es así, lanza una excepción.
            if (string.IsNullOrWhiteSpace(libro.Titulo) || string.IsNullOrWhiteSpace(libro.Autor))
            {
                throw new ArgumentException("El título y el autor son obligatorios.");
            }
            // Llama al repositorio para agregar el nuevo libro a la base de datos.
            await _repository.AddAsync(libro);
        }

        // Actualizar un libro existente
        public async Task UpdateLibroAsync(Libro libro)
        {
            // Verifica si el libro existe en la base de datos.
            var existingLibro = await _repository.GetByIdAsync(libro.Id);
            if (existingLibro == null)
            {
                throw new KeyNotFoundException($"No se encontró un libro con el ID {libro.Id}.");
            }
            // Llama al repositorio para actualizar el libro en la base de datos.
            await _repository.UpdateAsync(libro);
        }

        // Eliminar un libro
        public async Task DeleteLibroAsync(int id)
        {
            // Verifica si el libro existe en la base de datos.
            var libro = await _repository.GetByIdAsync(id);
            if (libro == null)
            {
                throw new KeyNotFoundException($"No se encontró un libro con el ID {id}.");
            }
            // Llama al repositorio para eliminar el libro de la base de datos.
            await _repository.DeleteAsync(id);
        }
    }
}
