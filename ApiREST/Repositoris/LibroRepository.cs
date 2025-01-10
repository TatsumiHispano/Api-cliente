using ApiREST.Data; // Para AppDbContext
using ApiREST.Model; // Para el modelo Libro
using Microsoft.EntityFrameworkCore;

namespace ApiREST.Repositories
{
    public class LibroRepository
    {
        // Inyección de dependencias: AppDbContext es el contexto de la base de datos.
        private readonly AppDbContext _context;
        // Constructor que recibe el contexto de base de datos.
        public LibroRepository(AppDbContext context)
        {
            _context = context;
        }

        // Obtener todos los libros
        public async Task<List<Libro>> GetAllAsync()
        {
            // Utiliza el contexto para consultar todos los libros en la tabla 'Libros' de la base de datos.
            return await _context.Libros.ToListAsync();
        }

        // Obtener un libro por ID
        public async Task<Libro?> GetByIdAsync(int id)
        {
            // Utiliza el método 'FindAsync' para buscar un libro con el ID proporcionado.
            return await _context.Libros.FindAsync(id);
        }

        // Crear un nuevo libro
        public async Task AddAsync(Libro libro)
        {
            // Se agrega el nuevo libro a la base de datos.
            _context.Libros.Add(libro);
            // Se guardan los cambios en la base de datos.
            await _context.SaveChangesAsync();
        }

        // Actualizar un libro existente
        public async Task UpdateAsync(Libro libro)
        {
            // Buscar el libro existente con el ID proporcionado.
            var existingLibro = await GetByIdAsync(libro.Id);
            if (existingLibro == null)
            {
                // Si no se encuentra el libro, lanzar una excepción.
                throw new KeyNotFoundException($"No se encontró un libro con el ID {libro.Id}.");
            }
            // Si el libro existe, se actualizan los campos.
            existingLibro.Titulo = libro.Titulo;
            existingLibro.Autor = libro.Autor;
            // Se guardan los cambios en la base de datos.
            await _context.SaveChangesAsync();
        }

        // Eliminar un libro por ID
        public async Task DeleteAsync(int id)
        {
            // Buscar el libro con el ID proporcionado.
            var libro = await GetByIdAsync(id);
            if (libro != null)
            {
                // Si el libro existe, se elimina.
                _context.Libros.Remove(libro);
                // Se guardan los cambios en la base de datos.
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new KeyNotFoundException($"No se encontró un libro con el ID {id}.");
            }
        }
    }
}

