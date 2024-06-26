using FinalProject_TayViet_Accessory_Store_Management.Server.States;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using FinalProject_TayViet_Accessory_Store_Management.Server.Interfaces;
namespace FinalProject_TayViet_Accessory_Store_Management.Server.Models
{
    public class Account : IAccount
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? id { get; set; }
        public string name { get; set; } = null!;
        public string email { get; set; } = null!;
        public string password { get; set; } = null!;
        public string phoneNumber { get; set; } = null!;
        public string username { get; set; } = null!;
        public string state { get; set; } = null!;
        public string role { get; set; } = null!;

        // get State
        public IAccountState State()
        {
            switch (state)
            {
                case "Active":
                    return new ActiveState();
                case "Inactive":
                    return new InactiveState();
                case "Locked":
                    return new LockState();
                case "Unlocked":
                    return new UnlockState();
                default:
                    throw new Exception("Invalid State");
            }
        }

        // Login method
        public void Login()
        {
            State().Login(this);
        }

        // Logout method
        public void Logout()
        {
            State().Logout(this);
        }
    }
}