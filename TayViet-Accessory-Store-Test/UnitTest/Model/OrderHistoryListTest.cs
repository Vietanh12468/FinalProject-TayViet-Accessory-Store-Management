using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
using FinalProject_TayViet_Accessory_Store_Management.Server.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalProject_TayViet_Accessory_Store_Management.Models.ExceptionModels;
using FinalProject_TayViet_Accessory_Store_Management.Server.Utility;

namespace FinalProject_TayViet_Accessory_Store_Management.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderHistoryController : ControllerBase
    {
        private readonly IDatabaseServices<OrderHistory> _orderHistoryService;
        private readonly IDatabaseServices<Product> _productService;

        public OrderHistoryController(IDatabaseServices<OrderHistory> orderHistoryService, IDatabaseServices<Product> productService)
        {
            _orderHistoryService = orderHistoryService;
            _productService = productService;
        }

        [HttpPut("{id}, {newState}")]
        public async Task<IActionResult> UpdateOrderHistory(string id, string newState)
        {
            if (!OrderValidateState.CheckState(newState))
            {
                return BadRequest("Invalid state");
            }

            OrderHistory orderHistory;
            try
            {
                orderHistory = await _orderHistoryService.ReadAsync("id", id);
            }
            catch (FormatException) { return BadRequest("Invalid Id"); }
            catch (NotFoundException) { return NotFound("Item Not Found Or Deleted"); }
            catch (Exception) { throw new UnknownException(); }

            orderHistory.UpdateState(newState);

            return Ok();
        }

        [HttpGet("revenueAndCost")]
        public async Task<ActionResult<IEnumerable<ProductRevenueCost>>> GetRevenueAndCost()
        {
            var orderHistories = await _orderHistoryService.ReadAsync();
            var products = await _productService.ReadAsync();

            var productRevenueCostList = products.Select(product => {
                var totalSpend = orderHistories
                    .SelectMany(order => order.cart)
                    .Where(cart => cart.productID == product.id)
                    .Sum(cart => cart.subProductList.Sum(sp => sp.cost * sp.quantity));

                var totalRevenue = orderHistories
                    .SelectMany(order => order.cart)
                    .Where(cart => cart.productID == product.id)
                    .Sum(cart => cart.subProductList.Sum(sp => (sp.cost - sp.sale) * sp.quantity));

                var subproducts = product.subProductList.Select(subProduct => {
                    var subProductTotalSpend = orderHistories
                        .SelectMany(order => order.cart)
                        .Where(cart => cart.productID == product.id)
                        .SelectMany(cart => cart.subProductList)
                        .Where(sp => sp.subProductName == subProduct.name)
                        .Sum(sp => sp.cost * sp.quantity);

                    var subProductTotalRevenue = orderHistories
                        .SelectMany(order => order.cart)
                        .Where(cart => cart.productID == product.id)
                        .SelectMany(cart => cart.subProductList)
                        .Where(sp => sp.subProductName == subProduct.name)
                        .Sum(sp => (sp.cost - sp.sale) * sp.quantity);

                    // Logging subproduct details
                    Console.WriteLine($"SubProduct: {subProduct.name}, TotalSpend: {subProductTotalSpend}, TotalRevenue: {subProductTotalRevenue}");

                    return new SubProductRevenueCost
                    {
                        SubProductName = subProduct.name,
                        TotalSpend = subProductTotalSpend,
                        TotalRevenue = subProductTotalRevenue
                    };
                }).ToList();

                // Logging product details
                Console.WriteLine($"Product: {product.name}, TotalSpend: {totalSpend}, TotalRevenue: {totalRevenue}");

                return new ProductRevenueCost
                {
                    ProductName = product.name,
                    TotalSpend = totalSpend,
                    TotalRevenue = totalRevenue,
                    Subproducts = subproducts
                };
            }).ToList();

            return Ok(productRevenueCostList);
        }


    }
}
