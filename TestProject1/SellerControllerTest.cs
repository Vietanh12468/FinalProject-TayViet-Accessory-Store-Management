using Xunit;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinalProject_TayViet_Accessory_Store_Management.Server.Controllers;
using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
using FinalProject_TayViet_Accessory_Store_Management.Utility.DatabaseUtility;

namespace FinalProject_TayViet_Accessory_Store_Management.Tests
{
    public class SellerControllerTests
    {
        private readonly Mock<AccountDatabaseServices<Seller>> _mockService;
        private readonly SellerController _controller;

        public SellerControllerTests()
        {
            _mockService = new Mock<AccountDatabaseServices<Seller>>();
            _controller = new SellerController(_mockService.Object);
        }

        [Fact]
        public async Task GetAll_ReturnsOkResult_WithListOfSellers()
        {
            // Arrange
            var testSellers = GetTestSellers();
            //_mockService.Setup(service => service.ReadAsync("role", "Seller")).ReturnsAsync(testSellers);
            _mockService.Setup(service => service.GetTotalRecord()).ReturnsAsync(testSellers.Count);

            // Act
            var result = await _controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnValue = Assert.IsType<dynamic>(okResult.Value);
            Assert.Equal(testSellers.Count, returnValue.TotalRecords);
            Assert.Equal(testSellers.Count, returnValue.Records.Count);
        }

        private List<Seller> GetTestSellers()
        {
            return new List<Seller>
            {
                new Seller { id = "1", Username = "seller1", Role = "Seller" },
                new Seller { id = "2", Username = "seller2", Role = "Seller" },
                new Seller { id = "3", Username = "seller3", Role = "Seller" }
            };
        }
    }
}
