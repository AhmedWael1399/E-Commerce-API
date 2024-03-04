using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Categories
    {
        [Key]
        public int Id { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; } 
        public ICollection<ProductCategory>? ProductCategory { get; set; }
    }
}
