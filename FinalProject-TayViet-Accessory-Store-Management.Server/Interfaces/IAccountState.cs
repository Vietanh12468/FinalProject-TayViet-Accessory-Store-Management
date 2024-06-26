using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
namespace FinalProject_TayViet_Accessory_Store_Management.Server.States {

    public interface IAccountState
    {
        void Login(Account account);
        void Logout(Account account);
    }

}