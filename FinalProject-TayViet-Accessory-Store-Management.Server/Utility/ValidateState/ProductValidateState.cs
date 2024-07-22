using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
using FinalProject_TayViet_Accessory_Store_Management.Server.States;

public static class ProductValidateState
{
    public static readonly Dictionary<string, IProductState> STATE_DICTIONARY = new Dictionary<string, IProductState>
    {
        { "Available", new AvailableState() },
        { "Unavailable", new UnavailableState() },
        { "Limit", new LimitState() },
        { "OutOfStock", new OutOfStockState() }
    };

    public static bool CheckState(string? state)
    {
        return STATE_DICTIONARY.ContainsKey(state);
    }
}
