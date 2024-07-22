using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
using FinalProject_TayViet_Accessory_Store_Management.Server.States;

public class OutOfStockState : IProductState
{
    public void Buy(SubProduct product, int quantity)
    {
        throw new InvalidOperationException("Cannot buy product that is out of stock.");
    }

    public void Restock(SubProduct product, int newStock)
    {
        product.inStock += newStock;
        product.SetState("Available");
    }
}