using FinalProject_TayViet_Accessory_Store_Management.Server.States;

namespace FinalProject_TayViet_Accessory_Store_Management.Server.Models.States.OrderStates
{
    public class RefundRejectedState : IOrderState
    {
        public void RequestRefund(OrderHistory order)
        {

            throw new Exception("Order is rejected to refund");
        }

        public void UpdateOrderState(OrderHistory order, string newState)
        {

            OrderHistoryMomento newOrderHistoryMomento = new OrderHistoryMomento(newState);
            order.history.Push(newOrderHistoryMomento);
        }

        public void HandleOrder(OrderHistory order)
        {
            OrderHistoryMomento newOrderHistoryMomento = new OrderHistoryMomento("Refund Rejected");
            order.history.Push(newOrderHistoryMomento);
        }
    }
}
