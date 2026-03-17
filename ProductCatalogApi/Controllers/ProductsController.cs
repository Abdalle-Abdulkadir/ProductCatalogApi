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
        public IActionResult GetProducts( decimal? minPrice, int? categoryId)
        {
            return Ok(_productService.GetAll(minPrice, categoryId));
        }
    }
}



