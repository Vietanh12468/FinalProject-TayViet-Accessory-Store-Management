using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
using FinalProject_TayViet_Accessory_Store_Management.Server.States;

namespace FinalProject_TayViet_Accessory_Store_Management.Server.Utility.ValidateState
{
    public class ProductValidateState
    {
        public static readonly Dictionary<string, IProductState> PRODUCT_STATE_DICTIONARY = new Dictionary<string, IProductState>(){
            { "Available", new AvailableState() },
            { "Unavailable", new UnavailableState() },
            { "Out of Stock", new OutOfStockState() },
            { "Limited", new LimitState() }
        };
    }
}
