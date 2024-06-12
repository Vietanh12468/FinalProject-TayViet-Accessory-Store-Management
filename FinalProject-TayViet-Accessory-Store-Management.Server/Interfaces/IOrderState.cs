using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
namespace FinalProject_TayViet_Accessory_Store_Management.Server.States
{

    public interface IOrderState
    {
        void RequestRefund(OrderHistory order);
        void UpdateOrderStatus(OrderHistory order);
        void HandleOrder(OrderHistory order);
    }
}
/*    public class OrderPlacedState : IOrderState
    {
        public void RequestRefund(OrderHistory order)
        {
            Console.WriteLine("Refund requested for order placed.");
            // Additional logic for requesting refund
        }

        public void UpdateOrderStatus(OrderHistory order)
        {
            Console.WriteLine("Updating order status from placed to processing.");
            order.SetState(new ProcessingState());
        }

        public void HandleOrder(OrderHistory order)
        {
            Console.WriteLine("Handling order placed.");
            // Additional logic for handling order placed
        }
    }

    public class ProcessingState : IOrderState
    {
        public void RequestRefund(OrderHistory order)
        {
            Console.WriteLine("Refund requested for processing order.");
            // Additional logic for requesting refund
        }

        public void UpdateOrderStatus(OrderHistory order)
        {
            Console.WriteLine("Updating order status from processing to out for delivery.");
            order.SetState(new OutForDeliveryState());
        }

        public void HandleOrder(OrderHistory order)
        {
            Console.WriteLine("Handling processing order.");
            // Additional logic for handling processing order
        }
    }

    public class OutForDeliveryState : IOrderState
    {
        public void RequestRefund(OrderHistory order)
        {
            Console.WriteLine("Refund requested for out for delivery order.");
            // Additional logic for requesting refund
        }

        public void UpdateOrderStatus(OrderHistory order)
        {
            Console.WriteLine("Updating order status from out for delivery to delivered.");
            order.SetState(new DeliveredState());
        }

        public void HandleOrder(OrderHistory order)
        {
            Console.WriteLine("Handling out for delivery order.");
            // Additional logic for handling out for delivery order
        }
    }

    public class DeliveredState : IOrderState
    {
        public void RequestRefund(OrderHistory order)
        {
            Console.WriteLine("Refund requested for delivered order.");
            // Additional logic for requesting refund
        }

        public void UpdateOrderStatus(OrderHistory order)
        {
            Console.WriteLine("Updating order status from delivered to complete payment.");
            order.SetState(new CompletePaymentState());
        }

        public void HandleOrder(OrderHistory order)
        {
            Console.WriteLine("Handling delivered order.");
            // Additional logic for handling delivered order
        }
    }

    public class CompletePaymentState : IOrderState
    {
        public void RequestRefund(OrderHistory order)
        {
            Console.WriteLine("Refund requested for complete payment order.");
            // Additional logic for requesting refund
        }

        public void UpdateOrderStatus(OrderHistory order)
        {
            Console.WriteLine("Order payment completed.");
            order.SetState(new CompleteOrderState());
        }

        public void HandleOrder(OrderHistory order)
        {
            Console.WriteLine("Handling complete payment order.");
            // Additional logic for handling complete payment order
        }
    }

    public class CompleteOrderState : IOrderState
    {
        public void RequestRefund(OrderHistory order)
        {
            Console.WriteLine("Refund requested for complete order.");
            // Additional logic for requesting refund
        }

        public void UpdateOrderStatus(OrderHistory order)
        {
            Console.WriteLine("Order already completed.");
        }

        public void HandleOrder(OrderHistory order)
        {
            Console.WriteLine("Handling complete order.");
            // Additional logic for handling complete order
        }
    }
}*/