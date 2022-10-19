using System.ComponentModel.DataAnnotations;

namespace WebAPIcourse.DTOs
{
    public class EditarAdminDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
