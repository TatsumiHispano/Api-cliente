using System.ComponentModel.DataAnnotations;

namespace ApiREST.Model
{
    public class Libro
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Titulo { get; set; }

        [Required]
        [StringLength(50)]
        public string Autor { get; set; }
    }
}
