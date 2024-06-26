using FinalProject_TayViet_Accessory_Store_Management.Server.States;
namespace FinalProject_TayViet_Accessory_Store_Management.Server.Models
{
    public class OutOfStockState : IProductState
    {
        public override string ToString()
        {
            return "Out of Stock";
        }
        public void Buy(SubProduct product, int quantity)
        {
            throw new NotImplementedException();
        }

        public void Restock(SubProduct product, int quantity)
        {
            throw new NotImplementedException();
        }
    }
}