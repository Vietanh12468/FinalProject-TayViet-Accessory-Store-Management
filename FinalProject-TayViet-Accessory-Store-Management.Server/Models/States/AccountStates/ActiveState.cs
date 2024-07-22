using FinalProject_TayViet_Accessory_Store_Management.Server.States;
namespace FinalProject_TayViet_Accessory_Store_Management.Server.Models
{

    public class ActiveState : IAccountState
    {
        public void Login(Account account)
        {
            throw new InvalidOperationException("Account is already logged in.");
        }

        public void Logout(Account account)
        {
            account.SetState("Inactive");
        }
    }
}