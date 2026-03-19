using System.ComponentModel.DataAnnotations;

namespace ProductCatalogApi.DTOs
{
    public class ProductUpdateDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Range(1, 100000, ErrorMessage = "Price must be between 1 and 100000")]
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
    }
}

