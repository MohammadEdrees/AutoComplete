using AutoComplete.Services;
using Business.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoComplete.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
       public IProduct Product { get; set; }
        public async Task<IActionResult> Search(string text, int num = 0)
        {
            IEnumerable<ProductDto> results = await  Product.SearchProducts(text, num);  
            return Ok(results);
        }

    }
}
