﻿using System;
using System.Collections.Generic;

public class OrderHistory
{
    // Order ID
    public string OrderID { get; set; }

    // List of sub-products
    public List<SubProduct> SubProductList { get; set; }

    // Time of the order
    public DateTime OrderTime { get; set; }

    // Current state of the order
    public IOrderState State { get; set; }

    // List of OrderHistoryMomento for memento pattern
    private List<OrderHistoryMomento> history;

    // Constructor to initialize the order history
    public OrderHistory(string orderID, List<SubProduct> subProductList, DateTime orderTime, IOrderState state)
    {
        OrderID = orderID;
        SubProductList = subProductList;
        OrderTime = orderTime;
        State = state;
        history = new List<OrderHistoryMomento>();
    }

    // Get Order ID
    public string GetOrderID()
    {
        return OrderID;
    }

    // Get Sub-products
    public List<SubProduct> GetSubProductList()
    {
        return SubProductList;
    }

    // Get Order Time
    public DateTime GetOrderTime()
    {
        return OrderTime;
    }

    // Get State
    public IOrderState GetState()
    {
        return State;
    }

    // Set State and save to history
    public void SetState(IOrderState state)
    {
        State = state;
        SaveStateToHistory();
    }

    // Save state to history
    private void SaveStateToHistory()
    {
        history.Add(new OrderHistoryMomento(OrderID, SubProductList, OrderTime, State));
    }

    // Restore state from history
    public void RestoreStateFromHistory(int index)
    {
        var momento = history[index];
        OrderID = momento.OrderID;
        SubProductList = momento.SubProductList;
        OrderTime = momento.OrderTime;
        State = momento.State;
    }

    // Request refund
    public void RequestRefund()
    {
        State.RequestRefund(this);
    }

    // Update order status
    public void UpdateOrderStatus()
    {
        State.UpdateOrderStatus(this);
    }

    // Handle order
    public void HandleOrder()
    {
        State.HandleOrder(this);
    }
}

public class OrderHistoryMomento
{
    public string OrderID { get; set; }
    public List<SubProduct> SubProductList { get; set; }
    public DateTime OrderTime { get; set; }
    public IOrderState State { get; set; }

    public OrderHistoryMomento(string orderID, List<SubProduct> subProductList, DateTime orderTime, IOrderState state)
    {
        OrderID = orderID;
        SubProductList = subProductList;
        OrderTime = orderTime;
        State = state;
    }
}
