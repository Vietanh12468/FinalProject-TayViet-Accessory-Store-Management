public class Brand
{
    // Brand ID
    public string BrandID { get; set; }

    // Brand name
    public string Name { get; set; }

    // Description of the brand
    public string Description { get; set; }

    // Image URL of the brand
    public string Image { get; set; }

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
        return BrandID;
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
        // Implement the logic
        return 0f;
    }

    // Get Total Purchase
    public int GetTotalPurchase()
    {
        // Implement the logic
        return 0;
    }
}
