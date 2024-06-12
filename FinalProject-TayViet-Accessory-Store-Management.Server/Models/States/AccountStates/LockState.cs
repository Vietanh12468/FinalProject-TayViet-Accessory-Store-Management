public class LockState : IAccountState
{
    public void Login(Account account)
    {
        Console.WriteLine("Cannot login. Account is locked.");
    }

    public void Logout(Account account)
    {
        Console.WriteLine("Cannot logout. Account is locked.");
    }

    public override string ToString()
    {
        return "Locked";
    }
}