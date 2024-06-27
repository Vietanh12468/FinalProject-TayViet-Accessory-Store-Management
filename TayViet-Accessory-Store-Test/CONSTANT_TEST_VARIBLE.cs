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
    }
}
