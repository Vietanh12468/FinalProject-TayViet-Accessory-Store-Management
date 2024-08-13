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
            { "OutForDelivery", new OutForDeliveryState() },
            { "Delivered", new DeliveredState() },
            { "CompletePayment", new CompletePaymentState() },
            { "CompleteOrder", new CompleteOrderState() },
            { "Cancelled", new CancelledState() },
            { "RefundRequested", new RefundRequestedState() },
            { "RefundProcessing", new RefundProcessingState() },
            { "Refunded", new RefundedState() },
            { "RefundRejected", new RefundRejectedState() }
        };
        public static bool CheckState(string state)
        {
            if (ValidateStateTemplate<IOrderState>.CheckState(state, STATE_DICTIONARY))
                return true;
            return false;
        }
    }
}
