using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using FinalProject_TayViet_Accessory_Store_Management.Server.Controllers;
using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
using FinalProject_TayViet_Accessory_Store_Management.Utility.DatabaseUtility;

public class OrderHistoryControllerTests
{
    private readonly InMemoryDatabaseService<OrderHistory> _orderHistoryService;
    private readonly InMemoryDatabaseService<Product> _productService;
    private readonly OrderHistoryController _controller;

    public OrderHistoryControllerTests()
    {
        var orderHistories = new List<OrderHistory>
        {
            new OrderHistory("customerId1", "location1", new List<ProductInCart>
            {
                new ProductInCart("productId1", new List<SubProductInCart>
                {
                    new SubProductInCart("subProductName1", 100, 20, 2)
                })
            })
        };

        var products = new List<Product>
        {
            new Product("productName1", "description", "image", new List<string> { "category1" }, new List<SubProduct>
            {
                new SubProduct("subProductName1", "description", new List<string> { "image" }, 10, "Available", 50, 100, 20)
            }, "brandId1")
        };

        _orderHistoryService = new InMemoryDatabaseService<OrderHistory>(orderHistories);
        _productService = new InMemoryDatabaseService<Product>(products);
        _controller = new OrderHistoryController(_orderHistoryService, _productService);
    }

    [Fact]
    public async Task GetRevenueAndCost_ReturnsExpectedResults()
    {
        // Arrange
        var orderHistory1 = new OrderHistory("customer1", "location1", new List<ProductInCart>
        {
            new ProductInCart("product1", new List<SubProductInCart>
            {
                new SubProductInCart("subProduct1", 100, 20, 1),
                new SubProductInCart("subProduct2", 200, 50, 2)
            })
        });

        var orderHistory2 = new OrderHistory("customer2", "location2", new List<ProductInCart>
        {
            new ProductInCart("product1", new List<SubProductInCart>
            {
                new SubProductInCart("subProduct1", 100, 20, 1)
            })
        });

        var product = new Product("product1", "desc", "img", new List<string> { "cat1" }, new List<SubProduct>
        {
            new SubProduct("subProduct1", "desc", new List<string>(), 10, "Available", 80, 100, 20),
            new SubProduct("subProduct2", "desc", new List<string>(), 10, "Available", 180, 200, 50)
        }, "brand1");

        _orderHistoryService.CreateAsync(orderHistory1).Wait();
        _orderHistoryService.CreateAsync(orderHistory2).Wait();
        _productService.CreateAsync(product).Wait();

        // Act
        var result = await _controller.GetRevenueAndCost();
        var okResult = result.Result as OkObjectResult;
        var productRevenueCostList = okResult.Value as List<ProductRevenueCost>;

        // Assert
        Assert.NotNull(productRevenueCostList);
        var productRevenueCost = productRevenueCostList.FirstOrDefault(p => p.ProductName == "product1");
        Assert.NotNull(productRevenueCost);
        Assert.Equal(400, productRevenueCost.TotalSpend); // (100*1) + (200*2)
        Assert.Equal(220, productRevenueCost.TotalRevenue); // (100-20)*1 + (200-50)*2

        var subProduct1 = productRevenueCost.Subproducts.FirstOrDefault(sp => sp.SubProductName == "subProduct1");
        var subProduct2 = productRevenueCost.Subproducts.FirstOrDefault(sp => sp.SubProductName == "subProduct2");
        Assert.NotNull(subProduct1);
        Assert.NotNull(subProduct2);
        Assert.Equal(200, subProduct1.TotalSpend); // 100*1 (orderHistory1) + 100*1 (orderHistory2)
        Assert.Equal(60, subProduct1.TotalRevenue); // (100-20)*1 (orderHistory1) + (100-20)*1 (orderHistory2)
        Assert.Equal(400, subProduct2.TotalSpend); // 200*2
        Assert.Equal(160, subProduct2.TotalRevenue); // (200-50)*2
    }

    [Fact]
    public async Task UpdateOrderHistory_ValidState_ReturnsOk()
    {
        // Arrange
        var orderHistory = new OrderHistory("customerId1", "location1", new List<ProductInCart>());
        orderHistory.UpdateState("Ordered");
        await _orderHistoryService.CreateAsync(orderHistory);

        // Act
        var result = await _controller.UpdateOrderHistory(orderHistory.id, "Shipped") as OkResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
    }

    [Fact]
    public async Task UpdateOrderHistory_InvalidState_ReturnsBadRequest()
    {
        // Act
        var result = await _controller.UpdateOrderHistory("1", "InvalidState") as BadRequestObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(400, result.StatusCode);
        Assert.Equal("Invalid state", result.Value);
    }

    [Fact]
    public async Task UpdateOrderHistory_InvalidId_ReturnsBadRequest()
    {
        // Arrange
        var invalidId = "invalidId";

        // Act
        var result = await _controller.UpdateOrderHistory(invalidId, "Shipped") as BadRequestObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(400, result.StatusCode);
        Assert.Equal("Invalid Id", result.Value);
    }

    [Fact]
    public async Task UpdateOrderHistory_NotFound_ReturnsNotFound()
    {
        // Act
        var result = await _controller.UpdateOrderHistory("nonexistentId", "Shipped") as NotFoundObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(404, result.StatusCode);
        Assert.Equal("Item Not Found Or Deleted", result.Value);
    }
}
