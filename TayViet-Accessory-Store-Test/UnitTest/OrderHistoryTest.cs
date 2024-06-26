using FinalProject_TayViet_Accessory_Store_Management.Server.Interfaces;
using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
using FinalProject_TayViet_Accessory_Store_Management.Utility.DatabaseUtility;
using Microsoft.Extensions.Options;

namespace TayViet_Accessory_Store_Test.UnitTest
{
    public class OrderHistoryTest
    {
        static DBSettings settings = new DBSettings
        {
            ConnectionURI = "mongodb://localhost:27017",
            DatabaseName = "mydatabase",
            Collections = [
            "Account",
                "Brand",
                "CategorySection",
                "OrderHistory",
                "Product"
            ]
        };

        // Create an instance of IOptions<DBSettings> with the DBSettings object
        static IOptions<DBSettings> dbSettings = Options.Create(settings);

        // Create an instance of DatabaseServices
        static int index = 1; // The index of the desired collection
        OrderHistoryDatabaseService databaseService = new OrderHistoryDatabaseService(dbSettings, index);

/*        OrderHistoryDatabaseService databaseService;*/

        [Fact]
        public void Add_ReadAllOrderHistory_Success()
        {
            List<OrderHistory> result = databaseService.ReadAsync().Result.ToList();

            Assert.NotNull(result);
        }

    }
}
