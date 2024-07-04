using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using FinalProject_TayViet_Accessory_Store_Management.Server.States;
namespace FinalProject_TayViet_Accessory_Store_Management.Server.Models
{
    public class Product
    {
        // Product ID
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? id { get; set; }
        public string name { get; set; } = null!;
        public string description { get; set; } = null!;
        public string image { get; set; } = null!;
        public List<string> categoryList { get; set; } = null!;
        // List of sub-products
        public List<SubProduct> subProductList { get; set; } = null!;
        // Brand of the product
        public string brandID { get; set; } = null!;

        public Product(string name, string description, string image, List<string> categoryList, List<SubProduct> subProductList, string brandID)
        {
            this.name = name;
            this.description = description;
            this.image = image;
            this.categoryList = categoryList;
            this.subProductList = subProductList;
            this.brandID = brandID;
        }

        // Add Sub-product
        public void AddSubProduct(SubProduct subProduct)
        {
            subProductList.Add(subProduct);
        }

        // Remove Sub-product
        public void RemoveSubProduct(int index)
        {
            subProductList.RemoveAt(index);
        }

/*        // List of reviews
        public List<Review> reviewList { get; set; } = null!;

        // Add Review
        public void AddReview(Review review)
        {
            reviewList.Add(review);
        }

        // Remove Review
        public void RemoveReview(int index)
        {
            reviewList.RemoveAt(index);
        }*/

        //This Code is Error Pls Fix it NOW!
/*        // Buy product
        public void Buy(int quantity)
        {
            State.Buy(this, quantity);
        }

        // Restock product
        public void Restock(int newStock)
        {
            State.Restock(this, newStock);
        }*/
    }
}