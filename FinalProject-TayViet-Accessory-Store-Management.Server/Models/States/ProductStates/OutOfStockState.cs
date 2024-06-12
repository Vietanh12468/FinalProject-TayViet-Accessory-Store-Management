using FinalProject_TayViet_Accessory_Store_Management.Server.States;
namespace FinalProject_TayViet_Accessory_Store_Management.Server.Models
{
    public class OutOfStockState : IState
    {
        public string ToString()
        {
            return "Out of Stock";
        }

        public void Buy(Product product, int quantity)
        {
            // Cannot buy when out of stock
            Console.WriteLine("Product is out of stock.");
        }

        public void Restock(Product product, int newStock)
        {
            product.InStockList[0].SetInStock(product.InStockList[0].GetInStock() + newStock);
            product.SetState(new AvailableState());
            Console.WriteLine("Product restocked and is now available. Current stock: " + newStock);
        }
    }
}