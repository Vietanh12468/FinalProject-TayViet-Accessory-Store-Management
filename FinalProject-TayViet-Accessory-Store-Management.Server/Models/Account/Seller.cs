using FinalProject_TayViet_Accessory_Store_Management.Server.States;
namespace FinalProject_TayViet_Accessory_Store_Management.Server.Models
{
    public class Seller : Account
    {
        public Seller(string name, string email, string password, string phoneNumber, string username) : base(name, email, password, phoneNumber, username)
        {
            role = "Seller";
        }
    }
 }