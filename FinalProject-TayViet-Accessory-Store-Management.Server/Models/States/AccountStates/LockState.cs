using FinalProject_TayViet_Accessory_Store_Management.Server.States;
namespace FinalProject_TayViet_Accessory_Store_Management.Server.Models
{
    public class LockState : IAccountState
    {
        
        public void Login(Account account)
        {
            account.SetState(ToString());
            throw new InvalidOperationException("Account is locked, login request failed");
        }

        public void Logout(Account account)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "Locked";
        }
    }
}