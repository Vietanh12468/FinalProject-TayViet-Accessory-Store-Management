using FinalProject_TayViet_Accessory_Store_Management.Server.Models;

namespace TayViet_Accessory_Store_Test
{
    public class CONSTANT_TEST_VARIBLE
    {
        public static OrderHistory sampleOrderHistory = new OrderHistory(
            "6674986baa7ae506c9",
            "TestLocation",
            new List<ProductInCart>
            {
                new ProductInCart("Product 1", new List<SubProductInCart>{
                    new SubProductInCart("Product 1", 10, 5, 2),
                    new SubProductInCart("Product 2", 15, 8, 3)
                }),
                new ProductInCart("Product 2", new List<SubProductInCart>{
                    new SubProductInCart("Product 3", 20, 10, 1)
                })
        });

        public static Product sampleProduct = new Product(
            "Product 1",
            "This is product 1",
            "1238u4821748271duwweu123u8ua8ru8wq8ewq8euq9",
            new List<string> { "category 1, category 2"},
            new List<SubProduct>
            {
                new SubProduct("SubProduct 1", "This is product 1", new List<string> { "1238u4821748271duwweu123u8ua8ru8wq8ewq8euq9,1238u4821748271duwweu123u8ua8ru8wq8ewq8euq9"}, 10, "Unavailable", 5, 10, 2),
                new SubProduct("SubProduct 2", "This is product 2", new List<string> { "9876i54329876i5432i3o2i3o2i3o2i3o2i3o2"}, 15, "Available", 5, 20, 10),
                new SubProduct("SubProduct 3", "This is product 3", new List<string> { "1238u4821748271duwweu123u8ua8ru8wq8ewq8euq9,1238u4821748271duwweu123u8ua8ru8wq8ewq8euq9"}, 20, "Out of Stock", 10, 30, 5),
                new SubProduct("SubProduct 4", "This is product 4", new List<string> { "1238u4821748271duwweu123u8ua8ru8wq8ewq8euq9,1238u4821748271duwweu123u8ua8ru8wq8ewq8euq9"}, 25, "Limited", 25, 40, 10)
            },
            "Brand 1"
        );
    }
}
