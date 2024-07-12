using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
using FinalProject_TayViet_Accessory_Store_Management.Server.States;

namespace FinalProject_TayViet_Accessory_Store_Management.Server.Utility.ValidateState
{
    public class AccountValidateState
    {
        public static new readonly Dictionary<string, IAccountState> STATE_DICTIONARY = new Dictionary<string, IAccountState>(){
            { "Active", new ActiveState() },
            { "Inactive", new InactiveState() },
            { "Locked", new LockState() },
            { "Unlocked", new UnlockState() }
        };

        public static bool CheckState(string state)
        {
            if (ValidateStateTemplate<IAccountState>.CheckState(state, STATE_DICTIONARY))
                return true;
            return false;
        }
    }
}
