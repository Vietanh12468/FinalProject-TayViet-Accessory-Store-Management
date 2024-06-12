using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.Collections.Generic;

public class Product
{
    // Product ID
    public string ProductID { get; set; }

    // Name of the product
    public string Name { get; set; }

    // List of categories
    public List<Category> ListCategory { get; set; }

    // Description of the product
    public string Description { get; set; }

    // Image URL of the product
    public string Image { get; set; }

    // List of sub-products
    public List<SubProduct> InStockList { get; set; }

    // Brand of the product
    public Brand Brand { get; set; }

    // State of the product
    public IState State { get; set; }

    // List of reviews
    public List<Review> ListReview { get; set; }

    // Constructor
    public Product(string name, List<Category> listCategory, string description, string image, List<SubProduct> inStockList, Brand brand, IState state)
    {
        Name = name;
        ListCategory = listCategory;
        Description = description;
        Image = image;
        InStockList = inStockList;
        Brand = brand;
        State = state;
        ListReview = new List<Review>();
    }

    // Get Product ID
    public string GetProductID()
    {
        return ProductID;
    }

    // Get Name
    public string GetName()
    {
        return Name;
    }

    // Get List of Categories
    public List<Category> GetListCategory()
    {
        return ListCategory;
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

    // Get List of Sub-products
    public List<SubProduct> GetInStockList()
    {
        return InStockList;
    }

    // Get Brand
    public Brand GetBrand()
    {
        return Brand;
    }

    // Get State
    public IState GetState()
    {
        return State;
    }

    // Get List of Reviews
    public List<Review> GetListReview()
    {
        return ListReview;
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

    // Set Brand
    public void SetBrand(Brand brand)
    {
        Brand = brand;
    }

    // Add Sub-product
    public void AddSubProduct(SubProduct subProduct)
    {
        InStockList.Add(subProduct);
    }

    // Remove Sub-product
    public void RemoveSubProduct(int index)
    {
        InStockList.RemoveAt(index);
    }

    // Set State
    public void SetState(IState state)
    {
        State = state;
    }

    // Add Review
    public void AddReview(Review review)
    {
        ListReview.Add(review);
    }

    // Remove Review
    public void RemoveReview(int index)
    {
        ListReview.RemoveAt(index);
    }

    // Buy product
    public void Buy(int quantity)
    {
        State.Buy(this, quantity);
    }

    // Restock product
    public void Restock(int newStock)
    {
        State.Restock(this, newStock);
    }

    public override string ToString()
    {
        return State.ToString();
    }
}
