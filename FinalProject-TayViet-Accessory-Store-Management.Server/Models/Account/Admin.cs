using FinalProject_TayViet_Accessory_Store_Management.Server.States;
namespace FinalProject_TayViet_Accessory_Store_Management.Server.Models
{
    public class Admin : Account
    {
        // Constructor to initialize the admin
        public Admin(string name, string email, string password, string phoneNumber, string username)
            : base(name, email, password, phoneNumber, username)
        {
            role = "Admin";
        }

        // Method to lock a user account
        /*        public void LockUserAccount(Account account)
                {
                    account.SetState(new LockState());
                }

                // Method to unlock a user account
                public void UnlockUserAccount(Account account)
                {
                    account.SetState(new UnlockState());
                }*/
    }
}