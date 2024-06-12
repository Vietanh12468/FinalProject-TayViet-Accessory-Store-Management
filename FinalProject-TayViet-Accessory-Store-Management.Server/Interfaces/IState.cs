using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
namespace FinalProject_TayViet_Accessory_Store_Management.Server.States
{
    public interface IState
    {
        // Method to represent the state as a string
        string ToString();

        // Method to handle buying a product
        void Buy(Product product, int quantity);

        // Method to handle restocking a product
        void Restock(Product product, int newStock);
    }
}