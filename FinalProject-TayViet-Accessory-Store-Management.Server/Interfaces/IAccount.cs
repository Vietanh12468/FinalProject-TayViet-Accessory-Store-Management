namespace FinalProject_TayViet_Accessory_Store_Management.Server.Interfaces
{
    public interface IAccount
    {
        string id { get; set; }
        string name { get; set; }
        string email { get; set; }
        string password { get; set; }
        string phoneNumber { get; set; }
        string username { get; set; }
        string? state { get; set; }
        string? role { get; set; }

        void Login();
        void Logout();
    }
}
