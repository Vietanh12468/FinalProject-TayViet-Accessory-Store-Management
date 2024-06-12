public class CartItem:Product
{
    public CartItem(string name, List<Category> listCategory, string description, string image, List<SubProduct> inStockList, Brand brand, IState state) : base(name, listCategory, description, image, inStockList, brand, state)
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
}