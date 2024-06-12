using System.Collections.Generic;

public class SubProduct
{
    // Sub-product ID
    public string SubProductID { get; set; }

    // Product ID
    public string ProductID { get; set; }

    // Name of the sub-product
    public string Name { get; set; }

    // List of images
    public List<string> ListImage { get; set; }

    // Stock quantity
    public int InStock { get; set; }

    // State of the product
    public IState State { get; set; }

    // Buy cost
    public int BuyCost { get; set; }

    // Sell cost
    public int SellCost { get; set; }

    // Sale percentage
    public int Sale { get; set; }

    // Total purchase
    public int TotalPurchase { get; set; }

    // Constructor
    public SubProduct(string productID, string subProductID, string name, List<string> listImage, int inStock, int buyCost, int sellCost, int sale)
    {
        ProductID = productID;
        SubProductID = subProductID;
        Name = name;
        ListImage = listImage;
        InStock = inStock;
        BuyCost = buyCost;
        SellCost = sellCost;
        Sale = sale;
    }

    // Get Product ID
    public string GetProductID()
    {
        return ProductID;
    }

    // Get Sub-product ID
    public string GetSubProductID()
    {
        return SubProductID;
    }

    // Get Name
    public string GetName()
    {
        return Name;
    }

    // Get List of Images
    public List<string> GetListImage()
    {
        return ListImage;
    }

    // Get In Stock Quantity
    public int GetInStock()
    {
        return InStock;
    }

    // Get Buy Cost
    public int GetBuyCost()
    {
        return BuyCost;
    }

    // Get Sell Cost
    public int GetSellCost()
    {
        return SellCost;
    }

    // Get Sale Percentage
    public int GetSale()
    {
        return Sale;
    }

    // Get Total Purchase
    public int GetTotalPurchase()
    {
        return TotalPurchase;
    }

    // Set State
    public void SetState(IState state)
    {
        State = state;
    }

    // Add Image
    public void AddImage(string image)
    {
        ListImage.Add(image);
    }

    // Remove Image
    public void RemoveImage(int index)
    {
        ListImage.RemoveAt(index);
    }

    // Set In Stock Quantity
    public void SetInStock(int inStock)
    {
        InStock = inStock;
    }

    // Set Buy Cost
    public void SetBuyCost(int buyCost)
    {
        BuyCost = buyCost;
    }

    // Set Sell Cost
    public void SetSellCost(int sellCost)
    {
        SellCost = sellCost;
    }

    // Set Sale Percentage
    public void SetSale(int sale)
    {
        Sale = sale;
    }

    // Set Total Purchase
    public void SetTotalPurchase(int totalPurchase)
    {
        TotalPurchase = totalPurchase;
    }
}
