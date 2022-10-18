
using System.ComponentModel.DataAnnotations;
using WebAPIcourse.Validations;

namespace WebAPIcourse.Models
{
    public class Libro
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 25, ErrorMessage = "El campo {0} no debe tener mas de {1} caracteres")]
        [AttributeBloqMayus]
        public string Titulo { get; set; }

        public DateTime? FechaPublicacion { get; set;}
        public List<Comentario> Comentarios { get; set; }
        public List<AutoresLibro> AutoresLibros { get; set; }
    }
}