using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

public class Category
{
    // Name of the category
 
    public string Name { get; set; }

    // Constructor
    public Category(string name)
    {
        Name = name;
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
  
    
}
