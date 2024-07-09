using Microsoft.AspNetCore.Mvc;
using FinalProject_TayViet_Accessory_Store_Management.Utility.DatabaseUtility;
using FinalProject_TayViet_Accessory_Store_Management.Server.Models;

namespace FinalProject_TayViet_Accessory_Store_Management.Server.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : AccountControllerTemplate<Customer>
    {
        private readonly AccountDatabaseServices<Customer> accountdatabaseServices;
        private readonly ProductDatabaseService productDatabaseServices;
        public CustomerController(AccountDatabaseServices<Customer> accountDatabaseServices, ProductDatabaseService productDatabaseServices) : base(accountDatabaseServices) {
            this.accountdatabaseServices = accountDatabaseServices;
            this.productDatabaseServices = productDatabaseServices;
        }

        [HttpPut("{CustomerId}/addProductInCart/{productId}, {subProductName}, {quantity}")]
        public async Task<IActionResult> AddProductInCart(string customerId, string productId, string subProductName, int quantity)
        {
            try
            {
                Customer customer = await accountdatabaseServices.ReadAsync("id", customerId);
                SubProduct subProduct = await productDatabaseServices.GetSubProduct(productId, subProductName);

                if (subProduct == null || customer == null)
                {
                    return BadRequest();
                }

                SubProductInCart newSubProductInCart = new SubProductInCart(subProduct, quantity);
                customer.CartList.Add(newSubProductInCart);

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
