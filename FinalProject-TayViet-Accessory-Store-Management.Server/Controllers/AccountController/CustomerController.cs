using Microsoft.AspNetCore.Mvc;
using FinalProject_TayViet_Accessory_Store_Management.Utility.DatabaseUtility;
using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
using FinalProject_TayViet_Accessory_Store_Management.Server.Utility.DatabaseUtility.AccountDatabaseUtility;

namespace FinalProject_TayViet_Accessory_Store_Management.Server.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : AccountControllerTemplate<Customer>
    {
        private readonly CustomerDatabaseServices accountDatabaseServices;
        private readonly ProductDatabaseService productDatabaseServices;
        public CustomerController(CustomerDatabaseServices accountDatabaseServices, ProductDatabaseService productDatabaseServices) : base(accountDatabaseServices) {
            this.accountDatabaseServices = accountDatabaseServices;
            this.productDatabaseServices = productDatabaseServices;
        }

        [HttpPut("{customerId}/addProductInCart/productId={productId}&subProductName={subProductName}&quantity={quantity}")]
        public async Task<IActionResult> AddProductInCart(string customerId, string productId, string subProductName, int quantity)
        {
            try
            {
                Customer customer = await accountDatabaseServices.ReadAsync("id", customerId);
                SubProduct subProduct = await productDatabaseServices.GetSubProduct(productId, subProductName);

                if (subProduct == null || customer == null)
                {
                    return BadRequest();
                }
                SubProductInCart newSubProductInCart = new SubProductInCart(subProduct, quantity);
                /*                await accountDatabaseServices.AddSubProductInCart(newSubProductInCart, customerId);*/

                if (customer.cartList.Any(product => product.productID == productId && product.subProductList.Any(subProduct => subProduct.subProductName == subProductName)))
                {
                    return BadRequest();
                }
                else if (customer.cartList.Any(product => product.productID == productId))
                {

                    await accountDatabaseServices.InsertSubProductInCart(customerId, productId, newSubProductInCart);
                }
                else
                {
                    ProductInCart newProductInCart = new ProductInCart(productId, new List<SubProductInCart>() { newSubProductInCart });
                    await accountDatabaseServices.InsertProductInCart(customerId, productId, newProductInCart);
                }
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
