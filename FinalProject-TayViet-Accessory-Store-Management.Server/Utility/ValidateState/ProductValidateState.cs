using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
using FinalProject_TayViet_Accessory_Store_Management.Server.States;

namespace FinalProject_TayViet_Accessory_Store_Management.Server.Utility.ValidateState
{
    public class ProductValidateState 
    {
        public static new readonly Dictionary<string, IProductState> STATE_DICTIONARY = new Dictionary<string, IProductState>(){
            { "Available", new AvailableState() },
            { "Unavailable", new UnavailableState() },
            { "Out of Stock", new OutOfStockState() },
            { "Limited", new LimitState() }
        };

        public static bool CheckState(string state)
        {
            if (ValidateStateTemplate<IProductState>.CheckState(state, STATE_DICTIONARY))
                return true;
            return false;
        }
    }
}
