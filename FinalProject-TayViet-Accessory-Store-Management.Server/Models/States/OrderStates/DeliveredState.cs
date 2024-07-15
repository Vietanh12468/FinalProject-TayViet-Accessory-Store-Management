using FinalProject_TayViet_Accessory_Store_Management.Server.States;

namespace FinalProject_TayViet_Accessory_Store_Management.Server.Models.States.OrderStates
{
    public class DeliveredState : IOrderState
    {
        private static readonly string[] ALLOW_TO_UPDATE_STATE = { "Complete Order", "Complete Payment" };

        public void HandleOrder(OrderHistory order)
        {
            bool hasPaid = false;
            OrderHistoryMomento tempOrderHistoryMomento = new OrderHistoryMomento("Complete Payment");
            foreach (var i in order.history)
            {
                if (i == tempOrderHistoryMomento)
                {
                    hasPaid = true;
                    break;
                }
            }
            if (hasPaid)
            {
                OrderHistoryMomento newOrderHistoryMomento = new OrderHistoryMomento("Compelete Order");
                order.history.Push(newOrderHistoryMomento);
            }
            else
            {
                //Logic if payment haven't done
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
