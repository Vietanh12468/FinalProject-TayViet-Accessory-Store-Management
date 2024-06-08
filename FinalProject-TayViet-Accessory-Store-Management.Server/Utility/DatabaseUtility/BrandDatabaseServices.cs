using FinalProject_TayViet_Accessory_Store_Management.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FinalProject_TayViet_Accessory_Store_Management.Utility.DatabaseUtility
{
    public class BrandDatabaseServices : DatabaseServices<Brand>
    {
        public BrandDatabaseServices(IOptions<DBSettings> dbSettings)
        {
            MongoClient client = new MongoClient(dbSettings.Value.ConnectionURI);
            IMongoDatabase mongoDatabase = client.GetDatabase(dbSettings.Value.DatabaseName);
            _collection = mongoDatabase.GetCollection<Brand>(dbSettings.Value.Collections.BrandCollection);
        }
    }
}
