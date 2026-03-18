using ProductCatalogApi.Data;
using ProductCatalogApi.DTOs;

namespace ProductCatalogApi.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ProductResponseDto> GetAll(decimal? minPrice, int? categoryId, int pageNumber, int pageSize)
        {
            var query = _context.Products.AsQueryable();

            if (minPrice.HasValue)
            {
                query = query.Where(p => p.Price >= minPrice.Value);
            }
            if (categoryId.HasValue)
            {
                query = query.Where(p => p.CategoryId == categoryId.Value);
            }

            query = query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            return query

                .Select(p => new ProductResponseDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    CategoryId = p.CategoryId,
                    SupplierId = p.SupplierId
                })
                .ToList();
        }
    }
}

