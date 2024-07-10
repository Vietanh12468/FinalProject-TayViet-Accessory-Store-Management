namespace FinalProject_TayViet_Accessory_Store_Management.Server.Models
{
    public class DBSettings
    {
        public string ConnectionURI { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public List<string> Collections = [
            "Customer", "Seller", "Admin", "Brand", "CategorySection", "OrderHistory", "Product"
        ];
    }
}