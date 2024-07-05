using FinalProject_TayViet_Accessory_Store_Management.Models.ExceptionModels;
using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
using FinalProject_TayViet_Accessory_Store_Management.Server.Utility.ValidateState;
using FinalProject_TayViet_Accessory_Store_Management.Utility.DatabaseUtility;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject_TayViet_Accessory_Store_Management.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerTemplate<Product>
    {
        public ProductController(ProductDatabaseService productDatabaseService) : base(databaseServices: productDatabaseService) => _databaseServices = productDatabaseService;
        private new readonly ProductDatabaseService _databaseServices;

        [HttpPut("SetState/{id}, {subProductName}, {newState}")]
        public async Task<IActionResult> UpdateProductState(string id, string subProductName, string newState)
        {
            if (ProductValidateState.PRODUCT_STATE_DICTIONARY.ContainsKey(newState) == false)
            {
                return BadRequest("Invalid state");
            }

            Product product;
            try
            {
                product = await _databaseServices.ReadAsync("id", id);
            }
            catch (FormatException) { return BadRequest("Invalid Id"); }
            catch (NotFoundException) { return NotFound("Item Not Found Or Deleted"); }
            catch (Exception) { throw new UnknownException(); }

            SubProduct? subProduct = product.subProductList.Find(x => x.name == subProductName);
            if (subProduct == null)
            {
                return NotFound("Item Not Found Or Deleted");
            }

            await _databaseServices.ChangeSubProductState(id, subProductName, newState);
            return Ok();
        }
    }
}
