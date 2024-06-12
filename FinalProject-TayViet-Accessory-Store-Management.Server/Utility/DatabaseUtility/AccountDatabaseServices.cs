using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace FinalProject_TayViet_Accessory_Store_Management.Utility.DatabaseUtility
{
    // This class is used to set account collection and model for this databaseServices. To use method inside this class, check the DatabaseServices.cs
    public class AccountDatabaseServices<T> : DatabaseServices<T>
    {
        public AccountDatabaseServices(IOptions<DBSettings> dbSettings)
        {
            MongoClient client = new MongoClient(dbSettings.Value.ConnectionURI);
            IMongoDatabase mongoDatabase = client.GetDatabase(dbSettings.Value.DatabaseName);
            _collection = mongoDatabase.GetCollection<T>(dbSettings.Value.Collections[1].nameCollection);
        }
    }
}
