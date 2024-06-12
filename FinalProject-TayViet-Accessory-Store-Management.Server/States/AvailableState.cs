using System.Diagnostics;
using System;
public class AvailableState : IState
{
    public string ToString()
    {
        return "Available";
    }

    public void Buy(Product product, int quantity)
    {
        int totalStock = 0;
        foreach (var subProduct in product.InStockList)
        {
            totalStock += subProduct.InStock;
        }

        if (totalStock >= quantity)
        {
            // Implement logic to reduce the stock
            int remainingQuantity = quantity;
            foreach (var subProduct in product.InStockList)
            {
                if (subProduct.InStock >= remainingQuantity)
                {
                    subProduct.InStock -= remainingQuantity;
                    remainingQuantity = 0;
                    break;
                }
                else
                {
                    remainingQuantity -= subProduct.InStock;
                    subProduct.InStock = 0;
                }
            }

            if (remainingQuantity > 0)
            {
                product.SetState(new OutOfStockState());
            }
        }
        else
        {
            // Handle insufficient stock case
            Console.Write("Insufficient stock to complete the purchase.");
        }
    }

    public void Restock(Product product, int newStock)
    {
        // Assume restocking the first sub-product for simplicity
        product.InStockList[0].InStock += newStock;
        Console.Write("Product restocked. Current stock: " + newStock);
    }
}
