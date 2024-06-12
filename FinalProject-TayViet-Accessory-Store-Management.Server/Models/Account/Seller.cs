using System.Collections.Generic;

public class Seller : Account
{
    // List of products sold by the seller
    public List<Product> ProductList { get; set; }

    // Constructor to initialize the seller
    public Seller(string userID, string username, string password, string fullName, string email, string phoneNumber, IAccountState state, List<Product> productList)
        : base(username, password, fullName, email, phoneNumber, state)
    {
        ProductList = productList;
    }

    // Get Product List
    public List<Product> GetProductList()
    {
        return ProductList;
    }

    // Add new product
    public void AddProduct(Product product)
    {
        ProductList.Add(product);
    }

    // Remove product
    public void RemoveProduct(Product product)
    {
        ProductList.Remove(product);
    }
}
