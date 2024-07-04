using FinalProject_TayViet_Accessory_Store_Management.Server.States;
using FinalProject_TayViet_Accessory_Store_Management.Server.Utility.ValidateState;
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

        public SubProduct(string name, string description, List<string> listImage, int inStock, string state, int buyCost, int sellCost, int discount)
        {
            this.name = name;
            this.description = description;
            this.listImage = listImage;
            this.inStock = inStock;
            this.state = state;
            this.buyCost = buyCost;
            this.sellCost = sellCost;
            this.discount = discount;
        }

        // Get Product ID
        public IProductState GetState()
        {
            if (ProductValidateState.PRODUCT_STATE_DICTIONARY.ContainsKey(state))
            {
                return ProductValidateState.PRODUCT_STATE_DICTIONARY[state];
            }

            // Handle the case when the state is not found
            throw new ArgumentException($"Invalid state: {state}");
        }

        public void SetState(string state)
        {
            if (ProductValidateState.PRODUCT_STATE_DICTIONARY.ContainsKey(state))
            {
                this.state = state;
                return;
            }

            // Handle the case when the state is not found
            throw new ArgumentException($"Invalid state: {state}");
        }

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