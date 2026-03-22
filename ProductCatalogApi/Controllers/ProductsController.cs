using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using ProductCatalogApi.DTOs;
using ProductCatalogApi.Services;
using System.Threading.Tasks;

namespace ProductCatalogApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [EnableRateLimiting("fixed")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts( decimal? minPrice, int? categoryId, int pageNumber = 1, int pageSize = 10)
        {
            var Results = await _productService.GetAll(minPrice, categoryId, pageNumber, pageSize);  
            return Ok(Results);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateDto dto)
        {
            var result = await _productService.Create(dto);

            if (!result)
                return BadRequest("Product could not be created");

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductUpdateDto dto)
        {
            var result = await _productService.Update(id, dto);

            if (!result)
                return NotFound("Prodcut not found");

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productService.Delete(id);

            if (!result)
                return NotFound("Prodcut not found");

            return Ok();
        }

    }
}



