using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public double Price { get; set; } 
        public string? Description { get; set; } 
        public List<ProductCategory>? ProductCategory { get; set; }
    }
}
