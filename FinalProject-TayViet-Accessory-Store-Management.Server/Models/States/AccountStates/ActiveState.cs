public class ActiveState : IAccountState
{
    public void Login(Account account)
    {
        Console.WriteLine("Account logged in.");
    }

    public void Logout(Account account)
    {
        Console.WriteLine("Account logged out.");
    }

    public override string ToString()
    {
        return "Active";
    }
}
