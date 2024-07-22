using FinalProject_TayViet_Accessory_Store_Management.Server.Models;

namespace FinalProject_TayViet_Accessory_Store_Management.Server.Interfaces
{
    public interface IProductService
    {
        void Buy(string productId, string subProductId, int quantity);
        void Restock(string productId, string subProductId, int quantity);
    }
}
