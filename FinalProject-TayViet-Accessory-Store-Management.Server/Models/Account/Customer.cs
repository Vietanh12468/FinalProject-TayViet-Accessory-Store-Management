using System.Collections.Generic;

public class Customer : Account
{
    // List of addresses
    public List<string> AddressList { get; set; }

    // Current Cart list
    public List<CartItem> CartList { get; set; }

    // List of bank cards
    public List<BankCard> BankCardList { get; set; }

    // Constructor to initialize the customer
    public Customer(string userID, string username, string password, string fullName, string email, string phoneNumber, IAccountState state, List<string> addressList, List<CartItem> cartList, List<BankCard> bankCardList)
        : base(username, password, fullName, email, phoneNumber, state)
    {
        AddressList = addressList;
        CartList = cartList;
        BankCardList = bankCardList;
    }

    // Get Address List
    public List<string> GetAddressList()
    {
        return AddressList;
    }

    // Get Cart List
    public List<CartItem> GetCartList()
    {
        return CartList;
    }

    // Get Bank Card List
    public List<BankCard> GetBankCardList()
    {
        return BankCardList;
    }

    // Add new address
    public void AddAddress(string address)
    {
        AddressList.Add(address);
    }

    // Add item to cart
    public void AddToCart(CartItem cartItem)
    {
        CartList.Add(cartItem);
    }

    // Add new bank card
    public void AddBankCard(BankCard bankCard)
    {
        BankCardList.Add(bankCard);
    }
}
