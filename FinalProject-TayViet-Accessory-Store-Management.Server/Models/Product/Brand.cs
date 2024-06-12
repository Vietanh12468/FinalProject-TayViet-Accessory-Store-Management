using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

public class Brand
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    private string? brandID;

    // Brand name
    private string Name;

    // Description of the brand
    private string Description;

    // Image URL of the brand
    private string Image;

    // Constructor
    public Brand(string name, string description, string image)
    {
        Name = name;
        Description = description;
        Image = image;
    }

    // Get Brand ID
    public string GetBrandID()
    {
        return brandID;
    }

    // Get Name
    public string GetName()
    {
        return Name;
    }

    // Get Description
    public string GetDescription()
    {
        return Description;
    }

    // Get Image
    public string GetImage()
    {
        return Image;
    }

    // Set Name
    public void SetName(string name)
    {
        Name = name;
    }

    // Set Description
    public void SetDescription(string description)
    {
        Description = description;
    }

    // Set Image
    public void SetImage(string image)
    {
        Image = image;
    }
    
    // Get Total Spend
    public float GetTotalSpend()
    {
        // Return Total Spend
        return 0f;
    }

    // Get Total Purchase
    public int GetTotalPurchase()
    {
        //Return TotalPurchase
        return 0;
    }
}
