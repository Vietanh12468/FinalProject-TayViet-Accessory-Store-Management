using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using FinalProject_TayViet_Accessory_Store_Management.Server.States;
namespace FinalProject_TayViet_Accessory_Store_Management.Server.Models
{
    public class SubProduct
    {
        public string name { get; set; } = null!;
        public string description { get; set; } = null!;
        public List<string> listImage { get; set; } = null!;
        public int inStock { get; set; } = 0;
        public string? state { get; set; } = "Unavailable";
        public int buyCost { get; set; } = 0;
        public int sellCost { get; set; } = 0;
        public int discount { get; set; } = 0;

/*        public int TotalPurchase { get; set; }*/



        // Get Product ID
        public IProductState GetState()
        {
            switch(state){
                case "Available":
                    return new AvailableState();
                case "Unavailable":
                    return new UnavailableState();
                case "Out of Stock":
                    return new OutOfStockState();
                case "Limited":
                    return new LimitState();
                default:
                    throw new Exception("Invalid State");
            }
        }

/*        // Get Total Purchase
        public int GetTotalPurchase()
        {
            return TotalPurchase;
        }*/

        public void Restock(int newStock)
        {
            GetState().Restock(this, newStock);
        }

        // Set State
        public void Buy(int quantity)
        {
            GetState().Buy(this, quantity);
        }
    }
}