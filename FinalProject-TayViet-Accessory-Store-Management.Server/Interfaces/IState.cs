public interface IState
{
    // Method to represent the state as a string
    string ToString();

    // Method to handle buying a product
    void Buy(Product product, int quantity);

    // Method to handle restocking a product
    void Restock(Product product, int newStock);
}
