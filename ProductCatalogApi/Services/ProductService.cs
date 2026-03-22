using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using ProductCatalogApi.Data;
using ProductCatalogApi.DTOs;
using ProductCatalogApi.Models;
using System.Collections;

namespace ProductCatalogApi.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        private readonly IMemoryCache _cache;

        public ProductService(AppDbContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public async Task<PagingResultDto<ProductResponseDto>> GetAll(decimal? minPrice, int? categoryId, int pageNumber, int pageSize)
        {

            

            var cacheKey = $"products_{minPrice}_{categoryId}_{pageNumber}_{pageSize}";
            


            if (_cache.TryGetValue(cacheKey, out var cachedResult))
            {
                

                return (PagingResultDto<ProductResponseDto>)cachedResult;
            }



            var query = _context.Products.AsQueryable();

            if (minPrice.HasValue)
            {
                query = query.Where(p => p.Price >= minPrice.Value);
            }
            if (categoryId.HasValue)
            {
                query = query.Where(p => p.CategoryId == categoryId.Value);
            }

            var totalCount = await query.CountAsync();

            query = query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            var items = await query
                .Select(p => new ProductResponseDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    CategoryId = p.CategoryId,
                    SupplierId = p.SupplierId
                })
                .ToListAsync();

            var result = new PagingResultDto<ProductResponseDto>
            {
                Items = items,
                Page = pageNumber,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = (int)Math.Ceiling((double)totalCount / pageSize)
            };

            _cache.Set(cacheKey, result, TimeSpan.FromMinutes(1));

            

            return result;

        }

        public async Task<bool> Create(ProductCreateDto dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                CategoryId = dto.CategoryId,
                SupplierId = dto.SupplierId
            };
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Update(int id, ProductUpdateDto dto)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
                return false;

            product.Name = dto.Name;
            product.Description = dto.Description;
            product.Price = dto.Price;
            product.CategoryId = dto.CategoryId;
            product.SupplierId = dto.SupplierId;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
                return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}

