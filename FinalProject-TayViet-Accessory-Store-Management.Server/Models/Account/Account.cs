using FinalProject_TayViet_Accessory_Store_Management.Server.Models.Account;
using System;

public class Account : User
{

    public string Username { get; set; }

    // Current state of the account
    public IAccountState State { get; set; }

    // Constructor to initialize the account
    public Account(string username, string password, string fullName, string email, string phoneNumber, IAccountState state)
    {
        
        Username = username;
        this.password = password;
        this.name = fullName;
        this.email = email;
        this.phoneNumber = phoneNumber;
        State = state;
    }

    // Get User ID
    public string GetUserID()
    {
        return this.id;
    }

    // Get Username
    public string GetUsername()
    {
        return Username;
    }

    // Get Password
    public string GetPassword()
    {
        return this.password;
    }

    // Get Full Name
    public string GetFullName()
    {
        return this.name;
    }

    // Get Email
    public string GetEmail()
    {
        return this.email;
    }

    // Get Phone Number
    public string GetPhoneNumber()
    {
        return this.phoneNumber;
    }

    // Get State
    public IAccountState GetState()
    {
        return State;
    }

    // Set Username
    public void SetUsername(string username)
    {
        Username = username;
    }

    // Set Password
    public void SetPassword(string password)
    {
        this.password = password;
    }

    // Set Full Name
    public void SetFullName(string fullName)
    {
        this.name = fullName;
    }

    // Set Email
    public void SetEmail(string email)
    {
        this.email = email;
    }

    // Set Phone Number
    public void SetPhoneNumber(string phoneNumber)
    {
        this.phoneNumber = phoneNumber;
    }

    // Set State
    public void SetState(IAccountState state)
    {
        State = state;
    }

    // Login method
    public void Login()
    {
        State.Login(this);
    }

    // Logout method
    public void Logout()
    {
        State.Logout(this);
    }
}
