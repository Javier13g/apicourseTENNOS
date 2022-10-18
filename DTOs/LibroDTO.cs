using System.ComponentModel.DataAnnotations;
using WebAPIcourse.Validations;

namespace WebAPIcourse.DTOs
{
    public class LibroDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime? FechaPublicacion { get; set;}
       
    }
}
