using ProductCatalogApi.DTOs;

namespace ProductCatalogApi.Services
{
    public class ProductService : IProductService
    {
        public List<ProductResponseDto> GetProducts()
        {
            return new List<ProductResponseDto>();  
        }
    }
}
