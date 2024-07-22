using FinalProject_TayViet_Accessory_Store_Management.Server.States;
namespace FinalProject_TayViet_Accessory_Store_Management.Server.Models
{
    public class UnavailableState : IProductState
    {
        public void Buy(SubProduct subProduct, int quantity)
        {
            throw new InvalidOperationException("Product is unavailable.");
        }

        public void Restock(SubProduct subProduct, int quantity)
        {
            subProduct.inStock += quantity;
            if (subProduct.inStock > 0)
            {
                subProduct.SetState("Available");
            }
        }
    }

}