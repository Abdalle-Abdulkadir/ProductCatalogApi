using System.ComponentModel.DataAnnotations;

namespace ProductCatalogApi.DTOs
{
    public class ProductCreateDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Range(1, 100000, ErrorMessage = "Price must be between 1 and 100000")]
        public decimal Price { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "CategoryId must be valid")]
        public int CategoryId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "SupplierId must be valid")]
        public int SupplierId { get; set; }

    }
}

