using System.ComponentModel.DataAnnotations;

namespace Contacts.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string PasswordHash { get; set; }
    }
}
