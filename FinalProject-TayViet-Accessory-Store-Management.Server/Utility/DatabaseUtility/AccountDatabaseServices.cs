using FinalProject_TayViet_Accessory_Store_Management.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace FinalProject_TayViet_Accessory_Store_Management.Utility.DatabaseUtility
{
    // This class is used to set account colletion and model for databaseServices. To use method inside this class, check the DatabaseServices.cs
    public class AccountDatabaseServices : DatabaseServices<User>
    {
        public AccountDatabaseServices(IOptions<DBSettings> dbSettings)
        {
/*            MongoClient client = new MongoClient(dbSettings.Value.ConnectionURI);
            IMongoDatabase mongoDatabase = client.GetDatabase(dbSettings.Value.DatabaseName);
            _collection = mongoDatabase.GetCollection<User>(dbSettings.Value.CollectionName);*/
        }
    }
}
