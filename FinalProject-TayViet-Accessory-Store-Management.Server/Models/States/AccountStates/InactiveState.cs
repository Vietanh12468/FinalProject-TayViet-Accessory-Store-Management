using FinalProject_TayViet_Accessory_Store_Management.Server.States;
namespace FinalProject_TayViet_Accessory_Store_Management.Server.Models
{
    public class InactiveState : IAccountState
    {
        public void Login(Account account)
        {
            account.SetState("Active");
        }

        public void Logout(Account account)
        {
            throw new InvalidOperationException("Account is already logged out.");
        }
    }
}