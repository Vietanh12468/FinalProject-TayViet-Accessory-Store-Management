using FinalProject_TayViet_Accessory_Store_Management.Server.States;

namespace FinalProject_TayViet_Accessory_Store_Management.Server.Models.States.OrderStates
{
    public class RefundRequestedState : IOrderState
    {
        private static readonly string[] ALLOW_TO_UPDATE_STATE = { "Refund Processing", "Cancelled" };

        public void RequestRefund(OrderHistory order)
        {
            OrderHistoryMomento newOrderHistoryMomento = new OrderHistoryMomento("Refund Requested");
            order.history.Push(newOrderHistoryMomento);
            throw new Exception("Refund Request is being made");
        }

        public void UpdateOrderState(OrderHistory order, string newState)
        {
            // Check Valid newState
            if (!ALLOW_TO_UPDATE_STATE.Contains(newState))
            {
                throw new Exception("Invalid new state.");
            }
            OrderHistoryMomento newOrderHistoryMomento = new OrderHistoryMomento(newState);
            order.history.Push(newOrderHistoryMomento);
        }

        public void HandleOrder(OrderHistory order)
        {
            OrderHistoryMomento newOrderHistoryMomento = new OrderHistoryMomento("Refund Processing");
            order.history.Push(newOrderHistoryMomento);
        }
    }
}
