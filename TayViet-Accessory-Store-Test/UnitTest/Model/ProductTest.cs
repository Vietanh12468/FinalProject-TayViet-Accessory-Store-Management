using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
using FinalProject_TayViet_Accessory_Store_Management.Server.States;
using Xunit;
using System;
using System.Collections.Generic;

namespace TayViet_Accessory_Store_Test.UnitTest.Model
{
    public class ProductTest
    {
        Product sampleObject = CONSTANT_TEST_VARIBLE.sampleProduct;

        public static IEnumerable<object[]> GetSubProducts()
        {
            yield return new object[] { new SubProduct("SubProduct 1", "This is product 1", new List<string> { "1238u4821748271duwweu123u8ua8ru8wq8ewq8euq9,1238u4821748271duwweu123u8ua8ru8wq8ewq8euq9" }, 10, "Unavailable", 5, 10, 2) };
            yield return new object[] { new SubProduct("SubProduct 2", "This is product 2", new List<string> { "9876i54329876i5432i3o2i3o2i3o2i3o2i3o2i3o2" }, 15, "Available", 3, 20, 4) };
        }

        [Theory]
        [MemberData(nameof(GetSubProducts))]
        public void AddAndRemove_SubProduct_Success(SubProduct subProduct)
        {
            sampleObject.AddSubProduct(subProduct);
            Assert.Contains(subProduct, sampleObject.subProductList);

            sampleObject.RemoveSubProduct(sampleObject.subProductList.IndexOf(subProduct));
            Assert.DoesNotContain(subProduct, sampleObject.subProductList);
        }

        public static IEnumerable<object[]> GetStateVaribleTest()
        {
            yield return new object[] { 0, typeof(UnavailableState) };
            yield return new object[] { 1, typeof(AvailableState) };
            yield return new object[] { 2, typeof(OutOfStockState) };
            yield return new object[] { 3, typeof(LimitState) };
        }

        [Theory]
        [MemberData(nameof(GetStateVaribleTest))]
        public void GetState_SubProduct_Success(int indexCheck, Type stateTypeCheck)
        {
            IProductState state = sampleObject.subProductList[indexCheck].GetState();
            Assert.IsType(stateTypeCheck, state);
        }

        public static IEnumerable<object[]> SetStateVaribleTest()
        {
            yield return new object[] { 0, typeof(UnavailableState), "Unavailable" };
            yield return new object[] { 0, typeof(AvailableState), "Available" };
            yield return new object[] { 0, typeof(OutOfStockState), "OutOfStock" }; // Corrected state name
            yield return new object[] { 0, typeof(LimitState), "Limit" }; // Corrected state name
        }

        [Theory]
        [MemberData(nameof(SetStateVaribleTest))]
        public void SetState_SubProduct_Success(int indexChange, Type stateTypeChange, string newStateName)
        {
            sampleObject.subProductList[indexChange].SetState(newStateName);
            IProductState state = sampleObject.subProductList[indexChange].GetState();
            Assert.IsType(stateTypeChange, state);
        }

        [Fact]
        public void Buy_SubProductAvailable_ShouldReduceQuantity()
        {
            var subProduct = new SubProduct("Test SubProduct", "Description", new List<string> { "image1.jpg" }, 10, "Available", 100, 150, 10);
            subProduct.Buy(3);
            Assert.Equal(7, subProduct.inStock);
            Assert.Equal("Available", subProduct.state);
        }

        [Fact]
        public void Buy_SubProductUnavailable_ShouldThrowException()
        {
            var subProduct = new SubProduct("Test SubProduct", "Description", new List<string> { "image1.jpg" }, 0, "Unavailable", 100, 150, 10);
            Assert.Throws<InvalidOperationException>(() => subProduct.Buy(1));
        }

        [Fact]
        public void Restock_SubProductUnavailable_ShouldChangeStateToAvailable()
        {
            var subProduct = new SubProduct("Test SubProduct", "Description", new List<string> { "image1.jpg" }, 0, "Unavailable", 100, 150, 10);
            subProduct.Restock(5);
            Assert.Equal(5, subProduct.inStock);
            Assert.Equal("Available", subProduct.state);
        }

        [Fact]
        public void Restock_SubProductAvailable_ShouldIncreaseQuantity()
        {
            var subProduct = new SubProduct("Test SubProduct", "Description", new List<string> { "image1.jpg" }, 10, "Available", 100, 150, 10);
            subProduct.Restock(5);
            Assert.Equal(15, subProduct.inStock);
        }

        [Fact]
        public void Buy_SubProductOutOfStock_ShouldThrowException()
        {
            var subProduct = new SubProduct("Test SubProduct", "Description", new List<string> { "image1.jpg" }, 0, "OutOfStock", 100, 150, 10);
            Assert.Throws<InvalidOperationException>(() => subProduct.Buy(1));
        }

        [Fact]
        public void Restock_SubProductOutOfStock_ShouldChangeStateToAvailable()
        {
            var subProduct = new SubProduct("Test SubProduct", "Description", new List<string> { "image1.jpg" }, 0, "OutOfStock", 100, 150, 10);
            subProduct.Restock(5);
            Assert.Equal(5, subProduct.inStock);
            Assert.Equal("Available", subProduct.state);
        }

        [Fact]
        public void Buy_SubProductLimit_ShouldChangeStateToOutOfStock()
        {
            var subProduct = new SubProduct("Test SubProduct", "Description", new List<string> { "image1.jpg" }, 3, "Limit", 100, 150, 10);
            subProduct.Buy(3);
            Assert.Equal(0, subProduct.inStock);
            Assert.Equal("OutOfStock", subProduct.state);
        }

        [Fact]
        public void Restock_SubProductLimit_ShouldChangeStateToAvailable()
        {
            var subProduct = new SubProduct("Test SubProduct", "Description", new List<string> { "image1.jpg" }, 3, "Limit", 100, 150, 10);
            subProduct.Restock(5);
            Assert.Equal(8, subProduct.inStock);
            Assert.Equal("Available", subProduct.state);
        }
    }
}
