using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using FinalProject_TayViet_Accessory_Store_Management.Server.States;
using FinalProject_TayViet_Accessory_Store_Management.Server.Models.States.OrderStates;
using FinalProject_TayViet_Accessory_Store_Management.Server.Utility;
namespace FinalProject_TayViet_Accessory_Store_Management.Server.Models
{
    public class OrderHistory
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? id { get; set; }

        public string customerID { get; set; } = null!;

        public string shipLocation { get; set; } = null!;

        public List<ProductInCart> cart { get; set; } = null!;

        public Stack<OrderHistoryMomento> history { get; set; } = null!;

        public OrderHistory(string customerID, string shipLocation, List<ProductInCart> cart)
        {
            this.customerID = customerID;
            this.shipLocation = shipLocation;
            this.cart = cart;
            OrderHistoryMomento orderHistoryMomento = new OrderHistoryMomento("Ordered");
            history = new Stack<OrderHistoryMomento>();
            history.Push(orderHistoryMomento);
        }

        // Return the latest state in the history above
        public IOrderState GetState()
        {
            string state = history.Peek().state;

            if (OrderValidateState.CheckState(state))
            {
                return OrderValidateState.STATE_DICTIONARY[state];
            }

            // Handle the case when the state is not found
            throw new ArgumentException($"Invalid state: {state}");
        }

        public void UpdateState(string state)
        {
            IOrderState currentState = GetState();
            currentState.UpdateOrderState(this, state);
        }

        public void RequestRefund()
        {
            IOrderState currentState = GetState();
            currentState.RequestRefund(this);
        }

        public void HandleOrder()
        {
            IOrderState currentState = GetState();
            currentState.HandleOrder(this);
        }

        public double GetTotalCost()
        {
            double totalCost = 0;

            foreach (var product in cart)
            {
                foreach (var subProduct in product.subProductList)
                {
                    totalCost += (subProduct.cost - subProduct.sale) * subProduct.quantity;
                }
            }

            return totalCost;
        }

    }
    public class OrderHistoryMomento
    {
        public string state { get; set; } = null!;
        public DateTime? orderTime { get; set; } = DateTime.Now;

        public OrderHistoryMomento(string state)
        {
            this.state = state;
        }
    }

    public class ProductInCart
    {
        public string productID { get; set; } = null!;
        public List<SubProductInCart>? subProductList { get; set; } = new List<SubProductInCart>();

        public ProductInCart(string productID, List<SubProductInCart> subProductList)
        {
            this.productID = productID;
            this.subProductList = subProductList;
        }
    }

    public class SubProductInCart
    {
        public string subProductName { get; set; } = null!;

        public int cost { get; set; }

        public int sale { get; set; }

        public int quantity { get; set; }

        public SubProductInCart(string subProductName, int cost, int sale, int quantity)
        {
            this.subProductName = subProductName;
            this.cost = cost;
            this.sale = sale;
            this.quantity = quantity;
        }

        public SubProductInCart(SubProduct subProduct, int? quantity) {
            subProductName = subProduct.name;
            cost = subProduct.sellCost;
            sale = subProduct.discount;
            this.quantity = quantity ?? 1;
        }
    }

    /*        // Get Sub-products
            public List<SubProduct> GetSubProductList()
            {
                return SubProductList;
            }

            // Get Order Time
            public DateTime GetOrderTime()
            {
                return OrderTime;
            }

            // Get State
            public IOrderState GetState()
            {
                return State;
            }

            // Set State and save to history
            public void SetState(IOrderState state)
            {
                State = state;
                SaveStateToHistory();
            }

            // Save state to history
            private void SaveStateToHistory()
            {
                history.Add(new OrderHistoryMomento(id, SubProductList, OrderTime, State));
            }
    */
    /*        // Restore state from history
            public void RestoreStateFromHistory(int index)
            {
                var momento = history[index];
                id = momento.OrderID;
                SubProductList = momento.SubProductList;
                OrderTime = momento.OrderTime;
                State = momento.State;
            }*/

    /*        // Request refund //This Code also bugs
            public void RequestRefund()
            {
                State.RequestRefund(this);
            }

            // Update order status
            public void UpdateOrderStatus()
            {
                State.UpdateOrderStatus(this);
            }

            // Handle order
            public void HandleOrder()
            {
                State.HandleOrder(this);
            }*/
}
