using FinalProject_TayViet_Accessory_Store_Management.Server.States;

namespace FinalProject_TayViet_Accessory_Store_Management.Server.Models.States.OrderStates
{
    public class RefundProcessingState : IOrderState
    {
        private static readonly string[] ALLOW_TO_UPDATE_STATE = { "Refunded", "Refund Rejected" };

        public void RequestRefund(OrderHistory order)
        {

            throw new Exception("Refund request is processing");
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
            OrderHistoryMomento newOrderHistoryMomento = new OrderHistoryMomento("Refunded");
            order.history.Push(newOrderHistoryMomento);
        }
    }
}
