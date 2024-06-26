using FinalProject_TayViet_Accessory_Store_Management.Server.States;
namespace FinalProject_TayViet_Accessory_Store_Management.Server.Models
{
    public class LimitState : IProductState
    {
        public override string ToString()
        {
            return "Limited";
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