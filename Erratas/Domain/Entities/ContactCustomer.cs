using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Erratas.Domain.Entities
{
    public class ContactCustomer
    {
        public ContactCustomer()
        {
            DateAdded = DateTime.UtcNow;
            Id = Guid.NewGuid();
        }

        [Required]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Please, specify your name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please, specify your email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please, specify the description of the issue or the contact reason.")]
        public string Text { get; set; }

        [DataType(DataType.Time)]
        public DateTime DateAdded { get; set; }
    }
}
