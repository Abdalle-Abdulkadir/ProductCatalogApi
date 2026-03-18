using Microsoft.AspNetCore.Mvc;
using ProductCatalogApi.Services;

namespace ProductCatalogApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetProducts( decimal? minPrice, int? categoryId, int pageNumber = 1, int pageSize = 10)
        {
            return Ok(_productService.GetAll(minPrice, categoryId, pageNumber, pageSize));
        }
    }
}



