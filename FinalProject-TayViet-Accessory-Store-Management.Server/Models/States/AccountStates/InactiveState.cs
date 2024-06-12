public class InactiveState : IAccountState
{
    public void Login(Account account)
    {
        Console.WriteLine("Cannot login. Account is inactive.");
    }

    public void Logout(Account account)
    {
        Console.WriteLine("Cannot logout. Account is inactive.");
    }

    public override string ToString()
    {
        return "Inactive";
    }
}
