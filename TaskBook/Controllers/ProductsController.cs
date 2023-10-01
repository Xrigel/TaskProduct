using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskBook.Core.Abstraction;
using TaskBook.DTOs;
using TaskBook.Services;

namespace TaskBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService ProductService)
        {
            _productService = ProductService;
        }

        [HttpPost("add-book-with-authors")]
        public async Task<IActionResult> AddProduct([FromBody]ProductDto product)
        {
            await _productService.AddAuthorWithBook(product);
            return Ok();
        }

        [HttpGet("Get-Filtered-Product")]
        public async Task<IActionResult> GetFilteredProduct([FromBody] string name,int page,int pagesize)
        {
            await _productService.GetFilterProduct(name, pagesize, page);
            return Ok();
        }
    }
}
