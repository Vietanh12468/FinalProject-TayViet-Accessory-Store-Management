using FinalProject_TayViet_Accessory_Store_Management.Server.States;
namespace FinalProject_TayViet_Accessory_Store_Management.Server.Models
{
    public class CategorySection
    {
        // Name of the category section
        public string name { get; set; }

        // List of categories
        public List<string> listCategory { get; set; }

        // Constructor
        public CategorySection(string name, List<string> listCategory)
        {
            this.name = name;
            this.listCategory = listCategory;
        }

        // Add Category
        public void AddCategory(string category)
        {
            if (listCategory.Contains(category)) {
                throw new Exception("Category already exists");
            }

            listCategory.Add(category);
        }

        // Remove Category
        public void RemoveCategory(string category)
        {
            if (!listCategory.Contains(category))
            {
                throw new Exception("Category not found");
            }

            listCategory.Remove(category);
        }
    }
}