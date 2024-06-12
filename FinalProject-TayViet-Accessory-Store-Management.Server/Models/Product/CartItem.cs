using FinalProject_TayViet_Accessory_Store_Management.Server.States;
namespace FinalProject_TayViet_Accessory_Store_Management.Server.Models
{
    public class CartItem : Product
    {
        public CartItem(string name, List<Category> listCategory, string description, string image, List<SubProduct> inStockList, Brand brand, IState state) : base(name, listCategory, description, image, inStockList, brand, state)
        {
        }
    }
}