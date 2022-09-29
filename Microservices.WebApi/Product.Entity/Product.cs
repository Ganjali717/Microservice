using System.ComponentModel.DataAnnotations;

namespace Product.Entity
{
    public class Product
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
    }
}