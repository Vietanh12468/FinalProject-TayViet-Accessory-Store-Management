using FinalProject_TayViet_Accessory_Store_Management.Server.Interfaces;
using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
using MongoDB.Driver;

public class AccountService : IAccountService
{
    private readonly IMongoCollection<Account> _accounts;

    public AccountService(IMongoDatabase database)
    {
        _accounts = database.GetCollection<Account>("Accounts");
    }

    public void Login(string username, string password)
    {
        var account = _accounts.Find(a => a.username == username && a.password == password).FirstOrDefault();
        if (account == null)
        {
            throw new UnauthorizedAccessException("Invalid username or password.");
        }

        account.Login();
        _accounts.ReplaceOne(a => a.id == account.id, account);
    }

    public void Logout(string username)
    {
        var account = _accounts.Find(a => a.username == username).FirstOrDefault();
        if (account == null)
        {
            throw new ArgumentException("Invalid username.");
        }

        account.Logout();
        _accounts.ReplaceOne(a => a.id == account.id, account);
    }
}