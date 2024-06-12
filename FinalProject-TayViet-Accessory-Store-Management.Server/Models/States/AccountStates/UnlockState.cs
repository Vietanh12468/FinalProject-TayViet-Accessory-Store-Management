public class UnlockState : IAccountState
{
    public void Login(Account account)
    {
        Console.WriteLine("Account unlocked and logged in.");
    }

    public void Logout(Account account)
    {
        Console.WriteLine("Account unlocked and logged out.");
    }

    public override string ToString()
    {
        return "Unlocked";
    }
}