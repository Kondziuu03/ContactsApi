﻿using System.ComponentModel.DataAnnotations;

namespace Contacts.Entities
{
    public class Address
    {
        public int Id { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string PostalCode { get; set; }
        public Company Company { get; set; }
    }
}
