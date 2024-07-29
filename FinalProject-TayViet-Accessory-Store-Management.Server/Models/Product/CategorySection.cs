using FinalProject_TayViet_Accessory_Store_Management.Server.States;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
namespace FinalProject_TayViet_Accessory_Store_Management.Server.Models
{
    public class CategorySection
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? id { get; set; }
        // Name of the category section
        public string name { get; set; } = null!;

        // List of categories
        public List<string> categoryList { get; set; } = null!;

        // Add Category
        public void AddCategory(string category)
        {
            if (categoryList.Contains(category)) {
                throw new Exception("Category already exists");
            }

            categoryList.Add(category);
        }

        // Remove Category
        public void RemoveCategory(string category)
        {
            if (!categoryList.Contains(category))
            {
                throw new Exception("Category not found");
            }

            categoryList.Remove(category);
        }
    }
}