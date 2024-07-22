using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
using FinalProject_TayViet_Accessory_Store_Management.Server.States;

public class LimitState : IProductState
{
    public void Buy(SubProduct product, int quantity)
    {
        if (product.inStock < quantity)
        {
            throw new InvalidOperationException("Not enough stock to buy.");
        }
        product.inStock -= quantity;
        if (product.inStock == 0)
        {
            product.SetState("OutOfStock");
        }
    }

    public void Restock(SubProduct product, int newStock)
    {
        product.inStock += newStock;
        if (product.inStock > 0)
        {
            product.SetState("Available");
        }
    }
}
