using ProductCatalogApi.DTOs;

namespace ProductCatalogApi.Services
{
    public interface IProductService
    {
        List<ProductResponseDto> GetProducts();
    }
}
