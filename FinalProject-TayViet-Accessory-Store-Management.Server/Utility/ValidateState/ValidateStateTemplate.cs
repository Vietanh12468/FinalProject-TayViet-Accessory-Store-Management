using FinalProject_TayViet_Accessory_Store_Management.Server.States;

namespace FinalProject_TayViet_Accessory_Store_Management.Server.Utility.ValidateState
{
    public class ValidateStateTemplate<T> where T : IState
    {
        public static bool CheckState(string state, Dictionary<string, T> stateDictionary)
        {
            if (stateDictionary.ContainsKey(state))
                return true;
            return false;
        }
    }
}
