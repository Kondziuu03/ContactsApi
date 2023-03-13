using System.ComponentModel.DataAnnotations;

namespace Contacts.Models
{
    public class CreateContactDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        public int CategoryId { get; set; }
    }
}
