
public interface IProductState : IState
{
    new string ToString();
    new void Buy(int quantity);
    new void Restock(int newStock);
}
