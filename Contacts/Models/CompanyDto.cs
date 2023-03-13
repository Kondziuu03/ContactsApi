using System.Collections.Generic;

namespace Contacts.Models
{
    public class CompanyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public List<ContactDto> Contacts { get; set; }
    }
}
