using FinalProject_TayViet_Accessory_Store_Management.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FinalProject_TayViet_Accessory_Store_Management.Utility.DatabaseUtility
{
    // This class is used to set product collection and model for this databaseServices. To use method inside this class, check the DatabaseServices.cs
/*    public class ProductDatabaseService : DatabaseServices<Product>
    {
        public ProductDatabaseService(IOptions<DBSettings> dbSettings)
        {
            MongoClient client = new MongoClient(dbSettings.Value.ConnectionURI);
            IMongoDatabase mongoDatabase = client.GetDatabase(dbSettings.Value.DatabaseName);
            _collection = mongoDatabase.GetCollection<Product>(dbSettings.Value.Collections.ProductCollection);
        }
    }*/
}