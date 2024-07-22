using Microsoft.AspNetCore.Mvc;
using FinalProject_TayViet_Accessory_Store_Management.Server.Interfaces;

namespace FinalProject_TayViet_Accessory_Store_Management.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPut("buy/{productId}/{subProductId}")]
        public IActionResult Buy(string productId, string subProductId, [FromBody] int quantity)
        {
            try
            {
                _productService.Buy(productId, subProductId, quantity);
                return Ok("Purchase successful.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("restock/{productId}/{subProductId}")]
        public IActionResult Restock(string productId, string subProductId, [FromBody] int quantity)
        {
            try
            {
                _productService.Restock(productId, subProductId, quantity);
                return Ok("Restock successful.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
