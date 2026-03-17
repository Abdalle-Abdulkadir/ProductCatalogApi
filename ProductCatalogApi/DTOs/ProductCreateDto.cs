using System.ComponentModel.DataAnnotations;

namespace ProductCatalogApi.DTOs
{
    public class ProductCreateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Range(1, 100000)]
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
    }
}

