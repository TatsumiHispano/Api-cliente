namespace ApiREST.Data;

using global::ApiREST.Model;
using Microsoft.EntityFrameworkCore;
// El DbContext representa una sesión con la base de datos, donde se definen las entidades y las operaciones que se pueden realizar sobre ellas.
// En este caso, se maneja la entidad "Libro" a través de la clase AppDbContext.
public class AppDbContext : DbContext
{
    // Constructor que recibe las opciones de configuración para el DbContext (como la cadena de conexión a la base de datos).
    // Este constructor se pasa al constructor base de DbContext, que inicializa el contexto.
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    // La propiedad "Libros" es una representación de la tabla de libros en la base de datos.
    // DbSet<T> representa una colección de todas las entidades de tipo "Libro" en la base de datos.
    public DbSet<Libro> Libros { get; set; }
}
