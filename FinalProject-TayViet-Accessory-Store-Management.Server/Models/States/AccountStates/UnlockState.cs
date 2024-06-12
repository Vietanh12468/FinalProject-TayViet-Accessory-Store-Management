using FinalProject_TayViet_Accessory_Store_Management.Server.States;
namespace FinalProject_TayViet_Accessory_Store_Management.Server.Models
{
    public class UnlockState : IAccountState
    {
        public void Login(Account account)
        {
            Console.WriteLine("Account unlocked and logged in.");
        }

        public void Logout(Account account)
        {
            Console.WriteLine("Account unlocked and logged out.");
        }

        public override string ToString()
        {
            return "Unlocked";
        }
    }
}