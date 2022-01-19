using System.ComponentModel.DataAnnotations;

namespace AgendaDemoBackend.Models
{
    public class ContactDTO
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        public string? Email { get; set; }
    }
}
