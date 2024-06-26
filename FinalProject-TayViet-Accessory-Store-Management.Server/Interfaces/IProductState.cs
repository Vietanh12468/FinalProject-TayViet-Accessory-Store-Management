using FinalProject_TayViet_Accessory_Store_Management.Server.Models;

namespace FinalProject_TayViet_Accessory_Store_Management.Server.States
{
    public interface IProductState : IState
    {
        new string ToString();
        void Buy(SubProduct product, int quantity);
        void Restock(SubProduct product, int quantity);
    }
}