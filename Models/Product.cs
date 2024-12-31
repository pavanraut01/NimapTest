
using System.ComponentModel.DataAnnotations;
namespace NimapCrud.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
    }
}
