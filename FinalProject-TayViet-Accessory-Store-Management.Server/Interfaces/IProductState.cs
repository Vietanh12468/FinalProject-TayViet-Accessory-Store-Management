namespace FinalProject_TayViet_Accessory_Store_Management.Server.States
{
    public interface IProductState : IState
    {
        new string ToString();
        new void Buy(int quantity);
        new void Restock(int newStock);
    }
}