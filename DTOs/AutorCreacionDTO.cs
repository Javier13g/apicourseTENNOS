using System.ComponentModel.DataAnnotations;
using WebAPIcourse.Validations;

namespace WebAPIcourse.DTOs
{
    public class AutorCreacionDTO
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 25, ErrorMessage = "El campo {0} no debe tener mas de {1} caracteres")]
        [AttributeBloqMayus]
        public string Nombre_Autor { get; set; }
    }
}

