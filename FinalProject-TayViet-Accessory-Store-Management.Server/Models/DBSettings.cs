namespace FinalProject_TayViet_Accessory_Store_Management.Models
{
    public class DBSettings
    {
        public string ConnectionURI { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public Collections Collections { get; set; } = null!;
    }

    public class Collections
    {
        public string AccountCollection { get; set; } = null!;
        public string BrandCollection { get; set; } = null!;
        public string CategorySectionCollection { get; set; } = null!;
        public string OrderHistoryCollection { get; set; } = null!;
        public string ProductCollection { get; set; } = null!;
    }
}