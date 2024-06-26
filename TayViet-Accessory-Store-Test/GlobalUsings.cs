global using Xunit;
using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
using FinalProject_TayViet_Accessory_Store_Management.Utility.DatabaseUtility;
using Microsoft.Extensions.Options;

DBSettings settings = new DBSettings
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
IOptions<DBSettings> dbSettings = Options.Create(settings);

/*// Create an instance of DatabaseServices
int index = 1; // The index of the desired collection
OrderHistoryDatabaseService databaseService = new OrderHistoryDatabaseService(dbSettings, index);*/