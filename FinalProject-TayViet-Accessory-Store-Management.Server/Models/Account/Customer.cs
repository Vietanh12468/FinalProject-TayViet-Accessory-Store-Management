using FinalProject_TayViet_Accessory_Store_Management.Server.States;
namespace FinalProject_TayViet_Accessory_Store_Management.Server.Models
{
    public class Customer : Account
    {
        // List of addresses
        public List<string>? AddressList { get; set; } = new List<string>();

        // Current Cart list
        public List<SubProductInCart>? CartList { get; set; } = new List<SubProductInCart>();

        // List of bank cards
        public List<BankCard>? BankCardList { get; set; } = new List<BankCard>();

        public Customer(string name, string email, string password, string phoneNumber, string username)
            : base(name, email, password, phoneNumber, username)
        {
            role = "Customer";
        }
    }
}