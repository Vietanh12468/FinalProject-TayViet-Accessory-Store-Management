namespace FinalProject_TayViet_Accessory_Store_Management.Server.Models
{
    public class ProductRevenueCost
    {
        public string ProductName { get; set; } = null!;
        public double TotalSpend { get; set; }
        public double TotalRevenue { get; set; }
        public List<SubProductRevenueCost> Subproducts { get; set; } = new List<SubProductRevenueCost>();
    }
}
