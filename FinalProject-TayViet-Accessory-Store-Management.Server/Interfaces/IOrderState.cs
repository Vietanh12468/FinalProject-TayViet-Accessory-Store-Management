using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
namespace FinalProject_TayViet_Accessory_Store_Management.Server.States
{

    public interface IOrderState
    {
        //use for customer want to refund
        void RequestRefund(OrderHistory order);

        //use for update specific state
        void UpdateOrderState(OrderHistory order, string newState);

        //use for update state normally
        void HandleOrder(OrderHistory order);
    } 

    
}