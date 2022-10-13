using System.ComponentModel.DataAnnotations;
using WebAPIcourse.Validations;

namespace WebAPIcourse.Models
{
    public class Autor
    {
        [Key]
        public int IdAutor { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 5, ErrorMessage = "El campo {0} no debe tener mas de {1} caracteres")]
        [AttributeBloqMayus]
        public string Nombre_Autor { get; set; }
        public List<Libro> Libros { get; set; }
    }
}