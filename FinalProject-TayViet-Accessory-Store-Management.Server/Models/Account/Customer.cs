using FinalProject_TayViet_Accessory_Store_Management.Server.States;
namespace FinalProject_TayViet_Accessory_Store_Management.Server.Models
{
    public class Customer : Account
    {
        // List of addresses
        public List<string>? addressList { get; set; } = new List<string>();

        // Current Cart list
        public List<ProductInCart>? cartList { get; set; } = new List<ProductInCart>();

        // List of bank cards
        public List<BankCard>? bankCardList { get; set; } = new List<BankCard>();

        public Customer(string name, string email, string password, string phoneNumber, string username)
            : base(name, email, password, phoneNumber, username)
        {
            role = "Customer";
        }
    }
}