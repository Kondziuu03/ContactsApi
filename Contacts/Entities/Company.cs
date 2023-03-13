using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Contacts.Entities
{
    public class Company
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public ICollection<Contact> Contacts { get; set; } = new HashSet<Contact>();
    }
}
