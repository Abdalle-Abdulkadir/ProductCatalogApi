using ProductCatalogApi.DTOs;
using ProductCatalogApi.Models;
using System.Threading.Tasks;

namespace ProductCatalogApi.Services
{
    public interface IProductService
    {
        Task<PagingResultDto<ProductResponseDto>> GetAll(decimal? minPrice, int? categoryId, int pageNumber, int pageSize);
        Task<bool> Create(ProductCreateDto dto);
        Task<bool> Update(int id, ProductUpdateDto dto);
        Task<bool> Delete(int id);
    }
}

