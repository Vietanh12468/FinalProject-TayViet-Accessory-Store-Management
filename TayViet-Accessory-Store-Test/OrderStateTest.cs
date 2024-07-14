using Xunit;
using System.Collections.Generic;
using FinalProject_TayViet_Accessory_Store_Management.Server.Models.States.OrderStates;
using FinalProject_TayViet_Accessory_Store_Management.Server.States;
using FinalProject_TayViet_Accessory_Store_Management.Server.Models;

public class OrderStateTests
{

    private OrderHistory CreateSampleOrder()
    {
        var subProductList = new List<SubProductInCart>
        {
            new SubProductInCart("SubProduct1", 100, 10, 2),
            new SubProductInCart("SubProduct2", 200, 20, 1)
        };
        var cart = new List<ProductInCart>
        {
            new ProductInCart("Product1", subProductList)
        };
        var orderHistory = new OrderHistory("Customer1", "Location1", cart);
        return orderHistory;
    }
    [Fact]
    public void DeliveredState_RequestRefund_ShouldThrowNotImplementedException()
    {
        // Arrange
        var deliveredState = new DeliveredState();
        var orderHistory = CreateSampleOrder();

        // Act & Assert
        Assert.Throws<NotImplementedException>(() => deliveredState.RequestRefund(orderHistory));
    }

    [Fact]
    public void OrderPlacedState_RequestRefund_ShouldThrowException()
    {
        // Arrange
        var orderPlacedState = new OrderPlacedState();
        var orderHistory = CreateSampleOrder();

        // Act & Assert
        Assert.Throws<Exception>(() => orderPlacedState.RequestRefund(orderHistory));
    }
    [Fact]
    public void DeliveredState_HandleOrder_ShouldAddCompleteOrderIfPaid()
    {
        // Arrange
        var deliveredState = new DeliveredState();
        var orderHistory = CreateSampleOrder();
        orderHistory.history.Push(new OrderHistoryMomento("Complete Payment"));

        // Act
        deliveredState.HandleOrder(orderHistory);

        // Assert
        Assert.Contains(orderHistory.history, x => x.state == "Complete Order");
    }

    [Fact]
    public void OrderPlacedState_HandleOrder_ShouldAddProcessingState()
    {
        // Arrange
        var orderPlacedState = new OrderPlacedState();
        var orderHistory = CreateSampleOrder();

        // Act
        orderPlacedState.HandleOrder(orderHistory);

        // Assert
        Assert.Contains(orderHistory.history, x => x.state == "Processing");
    }
    [Fact]
    public void DeliveredState_UpdateOrderState_InvalidState_ShouldThrowException()
    {
        // Arrange
        var deliveredState = new DeliveredState();
        var orderHistory = CreateSampleOrder();

        // Act & Assert
        Assert.Throws<Exception>(() => deliveredState.UpdateOrderState(orderHistory, "Invalid State"));
    }

    [Fact]
    public void DeliveredState_UpdateOrderState_ValidState_ShouldUpdateState()
    {
        // Arrange
        var deliveredState = new DeliveredState();
        var orderHistory = CreateSampleOrder();

        // Act
        deliveredState.UpdateOrderState(orderHistory, "Complete Payment");

        // Assert
        Assert.Contains(orderHistory.history, x => x.state == "Complete Payment");
    }

    [Fact]
    public void OrderPlacedState_UpdateOrderState_InvalidState_ShouldThrowException()
    {
        // Arrange
        var orderPlacedState = new OrderPlacedState();
        var orderHistory = CreateSampleOrder();

        // Act & Assert
        Assert.Throws<Exception>(() => orderPlacedState.UpdateOrderState(orderHistory, "Invalid State"));
    }

    [Fact]
    public void OrderPlacedState_UpdateOrderState_ValidState_ShouldUpdateState()
    {
        // Arrange
        var orderPlacedState = new OrderPlacedState();
        var orderHistory = CreateSampleOrder();

        // Act
        orderPlacedState.UpdateOrderState(orderHistory, "Processing");

        // Assert
        Assert.Contains(orderHistory.history, x => x.state == "Processing");
    }
    [Fact]
    public void OrderHistory_GetTotalCost_ShouldReturnCorrectTotal()
    {
        // Arrange
        var orderHistory = CreateSampleOrder();

        // Act
        double totalCost = orderHistory.GetTotalCost();

        // Assert
        double expectedTotal = (100 * 2 - 10) + (200 - 20);
        Assert.Equal(expectedTotal, totalCost);
    }

}
