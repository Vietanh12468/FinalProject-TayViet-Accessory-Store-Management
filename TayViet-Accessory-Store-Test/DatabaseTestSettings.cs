using FinalProject_TayViet_Accessory_Store_Management.Server.Utility.DatabaseUtility.AccountDatabaseUtility;
using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
using FinalProject_TayViet_Accessory_Store_Management.Utility.DatabaseUtility;
using Microsoft.Extensions.Options;

namespace TayViet_Accessory_Store_Test
{
    public class DatabaseTestSettings
    {
        private static DatabaseTestSettings instance;

        public static DatabaseTestSettings GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new DatabaseTestSettings();
                return instance;
            }
        }

        private DatabaseTestSettings()
        {
            // Private constructor to prevent external instantiation
        }

        static DBSettings settings = new DBSettings
        {
            ConnectionURI = "mongodb+srv://anhnvbh00404:Z2z30GRwahp7iGeS@tayviet.badgawc.mongodb.net/?retryWrites=true&w=majority&appName=TayViet",
            DatabaseName = "TayViet-Data",
            Collections = [
                "Customer",
                "Seller",
                "Admin",
                "Brand",
                "CategorySection",
                "OrderHistory",
                "Product"
            ]
        };

        // Create an instance of IOptions<DBSettings> with the DBSettings object
        static IOptions<DBSettings> dbSettings = Options.Create(settings);

/*        public AccountDatabaseServices<IAccount> accountDatabaseServices = new AccountDatabaseServices<IAccount>(dbSettings, 0);*/

        public AccountDatabaseServices accountDatabaseServices = new AccountDatabaseServices(dbSettings, 0, 1, 2);

        public BrandDatabaseServices brandDatabaseServices = new BrandDatabaseServices(dbSettings, 1);
        public CategorySectionDatabaseService categorySectionDatabaseServices = new CategorySectionDatabaseService(dbSettings, 2);
        public OrderHistoryDatabaseService orderHistoryDatabaseServices = new OrderHistoryDatabaseService(dbSettings, 3);
        public ProductDatabaseService productDatabaseServices = new ProductDatabaseService(dbSettings, 4);
    }
}
