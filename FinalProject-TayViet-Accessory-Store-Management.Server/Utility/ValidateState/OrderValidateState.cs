namespace FinalProject_TayViet_Accessory_Store_Management.Server.Utility
{
    public class OrderValidateState
    {
        private static readonly string[] VALID_STATE = {"Ordered", "Processing", "Out For Delivery", "Delivered", "Complete Payment", "Complete Order", "Cancelled", "Refund Requested", "Refund Processing", "Refunded", "Refund Rejected"};

        public bool CheckState(string state)
        {
            if (VALID_STATE.Contains(state))
                return true;
            return false;
        }
    }
}
