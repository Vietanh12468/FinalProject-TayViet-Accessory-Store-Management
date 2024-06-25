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
        public string Username { get; set; } = null!;
        public string state { get; set; } = null!;
        public string role { get; set; } = null!;

        /*        // Current state of the account
                *//*        public IAccountState? State { get; set; }*//*

                // Constructor to initialize the account*/



        // Get State
        /*        public IAccountState GetState()
                {
        *//*            return State;*//*
                }*/


        // Set State
        public void SetState(IAccountState state)
        {
/*            State = state;*/
        }

        // Login method
        public void Login()
        {
/*            State.Login(this);*/
        }

        // Logout method
        public void Logout()
        {
/*            State.Logout(this);*/
        }
    }
}