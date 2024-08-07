using FinalProject_TayViet_Accessory_Store_Management.Server.Interfaces;
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

        public IProductState GetState()
        {
            if (ProductValidateState.CheckState(state))
            {
                return ProductValidateState.STATE_DICTIONARY[state];
            }

            throw new ArgumentException($"Invalid state: {state}");
        }

        public void SetState(string state)
        {
            if (ProductValidateState.CheckState(state))
            {
                this.state = state;
                return;
            }

            throw new ArgumentException($"Invalid state: {state}");
        }

        public void Restock(int newStock)
        {
            GetState().Restock(this, newStock);
        }

        public void Buy(int quantity)
        {
            GetState().Buy(this, quantity);
        }
    }
}
