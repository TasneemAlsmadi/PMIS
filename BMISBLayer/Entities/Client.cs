using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BMISBLayer.Entities
{
    public class Client
    {
        
        public int ClientId { get; set; }
        [Required]
        public String ClientName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
