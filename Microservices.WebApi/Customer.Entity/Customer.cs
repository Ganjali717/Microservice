using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace Customer.Entity
{
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }
        public int MobilePhone { get; set; }
        
    }
}