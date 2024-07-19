using Microsoft.AspNetCore.Mvc;

namespace FinalProject_TayViet_Accessory_Store_Management.Server.Interfaces
{
    public interface IAccountService
    {
        void Login(string username, string password);
        void Logout(string username);
    }
}
