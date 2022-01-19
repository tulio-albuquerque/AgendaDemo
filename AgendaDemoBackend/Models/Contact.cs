using System.ComponentModel.DataAnnotations;

namespace AgendaDemoBackend.Models
{
    public class Contact
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        public string? Email { get; set; }
    }
}
