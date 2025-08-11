using System;
using System.ComponentModel.DataAnnotations;

namespace Portfolioo.Models
{
    public class ContactMessage
    {
        [Required]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Message { get; set; }

        // New property for storing the time message was sent
        public DateTime DateSent { get; set; }
    }
}
