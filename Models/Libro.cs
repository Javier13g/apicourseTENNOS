using System.ComponentModel.DataAnnotations;

namespace WebAPIcourse.Models
{
    public class Libro
    {
        [Key]
        public int Id_Libro { get; set; }
        public string Titulo { get; set; }
        public int AutorId { get; set; }
        public Autor Autor { get; set; }
    }
}