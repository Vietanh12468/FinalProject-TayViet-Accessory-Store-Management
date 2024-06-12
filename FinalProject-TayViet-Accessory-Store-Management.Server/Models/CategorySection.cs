using System.Collections.Generic;

public class CategorySection
{
    // Name of the category section
    public string Name { get; set; }

    // List of categories
    public List<Category> ListCategory { get; set; }

    // Constructor
    public CategorySection(string name)
    {
        Name = name;
        ListCategory = new List<Category>();
    }

    // Add Category
    public void AddCategory(Category category)
    {
        ListCategory.Add(category);
    }

    // Remove Category
    public void RemoveCategory(int index)
    {
        ListCategory.RemoveAt(index);
    }

    // Get Name
    public string GetName()
    {
        return Name;
    }

    // Set Name
    public void SetName(string name)
    {
        Name = name;
    }

    // Get List of Categories
    public List<Category> GetListCategory()
    {
        return ListCategory;
    }
}
