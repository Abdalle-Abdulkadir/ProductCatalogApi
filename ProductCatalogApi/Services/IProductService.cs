using ProductCatalogApi.DTOs;

namespace ProductCatalogApi.Services
{
    public interface IProductService
    {
        IEnumerable<ProductResponseDto> GetAll(decimal? minPrice, int? categoryId);
    }
}

