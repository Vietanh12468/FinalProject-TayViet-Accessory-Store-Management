using System.Diagnostics;

public class UnAvailableState : IState
{
    public string ToString()
    {
        return "Unavailable";
    }

    public void Buy(Product product, int quantity)
    {
        // Cannot buy when product is unavailable
        Console.WriteLine("Product is currently unavailable.");
    }

    public void Restock(Product product, int newStock)
    {
        product.InStockList[0].SetInStock(product.InStockList[0].GetInStock() + newStock);
        product.SetState(new AvailableState());
        Console.WriteLine("Product restocked and is now available. Current stock: " + newStock);
    }
}
