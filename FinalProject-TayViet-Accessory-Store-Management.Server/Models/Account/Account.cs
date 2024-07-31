using MongoDB.Bson.Serialization.Attributes;
using FinalProject_TayViet_Accessory_Store_Management.Server.Interfaces;
using FinalProject_TayViet_Accessory_Store_Management.Server.Utility.ValidateState;
using FinalProject_TayViet_Accessory_Store_Management.Server.States;
using MongoDB.Bson;

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
        public string? state { get; set; } = "Inactive";
        public string? role { get; set; } = "Customer";
        public string? image { get; set; } = "";

        public Account(string name, string email, string password, string phoneNumber, string username)
        {
            this.name = name;
            this.email = email;
            this.password = password;
            this.phoneNumber = phoneNumber;
            this.username = username;
        }

        public Account(IAccount account) { 
            id = account.id;
            name = account.name;
            email = account.email;
            password = account.password;
            phoneNumber = account.phoneNumber;
            username = account.username;
            role = account.role;
            image = account.image;
        }

        // get State
        public IAccountState GetState()
        {
            if (AccountValidateState.CheckState(state))
            {
                return AccountValidateState.STATE_DICTIONARY[state];
            }

            throw new ArgumentException($"Invalid state: {state}");
        }

        public void SetState(string state)
        {
            if (AccountValidateState.CheckState(state))
            {
                this.state = state;
                return;
            }

            throw new ArgumentException($"Invalid state: {state}");
        }

        public void Login()
        {
            GetState().Login(this);
        }

        public void Logout()
        {
            GetState().Logout(this);
        }

    }
}
