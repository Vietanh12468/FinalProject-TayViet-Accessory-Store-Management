using FinalProject_TayViet_Accessory_Store_Management.Server.States;

namespace FinalProject_TayViet_Accessory_Store_Management.Server.Models.States.OrderStates
{
    public class DeliveredState : IOrderState
    {
        private static readonly string[] ALLOW_TO_UPDATE_STATE = { "CompleteOrder", "CompletePayment" };

        public void HandleOrder(OrderHistory order)
        {
            bool hasPaid = false;
            foreach (var i in order.history)
            {
                if (i.state == "Complete Payment")
                {
                    hasPaid = true;
                    break;
                }
            }
            if (hasPaid)
            {
                OrderHistoryMomento newOrderHistoryMomento = new OrderHistoryMomento("Complete Order");
                order.history.Push(newOrderHistoryMomento);
            }
            else
            {
                //Logic if payment hasn't been done
            }
        }

        public void RequestRefund(OrderHistory order)
        {
            throw new NotImplementedException();
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
    }
}