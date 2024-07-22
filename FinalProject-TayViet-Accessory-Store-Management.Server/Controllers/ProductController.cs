using Microsoft.AspNetCore.Mvc;
using FinalProject_TayViet_Accessory_Store_Management.Server.Interfaces;
using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
using FinalProject_TayViet_Accessory_Store_Management.Utility.DatabaseUtility;

namespace FinalProject_TayViet_Accessory_Store_Management.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerTemplate<Product>
    {
        private new readonly ProductDatabaseService _databaseServices;
        public ProductController(ProductDatabaseService productDatabaseService) : base(databaseServices: productDatabaseService) { 
            _databaseServices = productDatabaseService;
        }

        [HttpGet("Buy/{productId}, {subProductIndex}, {quantity}")]
        public async Task<IActionResult> Buy(string productId, int subProductIndex, int quantity)
        {
            try
            {
                Product product = await _databaseServices.ReadAsync("id", productId);
                product.subProductList[subProductIndex].Buy(quantity);
                await _databaseServices.UpdateAsync(product, "subProductList", product.subProductList);
                return Ok("Purchase successful.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("restock/{productId}/{subProductId}/{quantity}")]
        public async Task<IActionResult> Restock(string productId, int subProductIndex, int quantity)
        {
            try
            {
                Product product = await _databaseServices.ReadAsync("id", productId);
                product.subProductList[subProductIndex].Restock(quantity);
                return Ok("Restock successful.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
