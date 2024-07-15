using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
using FinalProject_TayViet_Accessory_Store_Management.Server.Models.States.OrderStates;
using FinalProject_TayViet_Accessory_Store_Management.Server.States;
using FinalProject_TayViet_Accessory_Store_Management.Server.Utility.ValidateState;

namespace FinalProject_TayViet_Accessory_Store_Management.Server.Utility
{
    public class OrderValidateState
    {
        public static new readonly Dictionary<string, IOrderState> STATE_DICTIONARY = new Dictionary<string, IOrderState>(){
            { "Ordered", new OrderPlacedState() },
            { "Processing", new ProcessingState() },
            { "Out For Delivery", new OutForDeliveryState() },
            { "Delivered", new DeliveredState() },
            { "Complete Payment", new CompletePaymentState() },
            { "Complete Order", new CompleteOrderState() },
            { "Cancelled", new CancelledState() },
            { "Refund Requested", new RefundRequestedState() },
            { "Refund Processing", new RefundProcessingState() },
            { "Refunded", new RefundedState() },
            { "Refund Rejected", new RefundRejectedState() }
        };
        public static bool CheckState(string state)
        {
            if (ValidateStateTemplate<IOrderState>.CheckState(state, STATE_DICTIONARY))
                return true;
            return false;
        }
    }
}
