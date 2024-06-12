using FinalProject_TayViet_Accessory_Store_Management.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FinalProject_TayViet_Accessory_Store_Management.Server.Utility.DatabaseMigration
{
    public class MainMigration
    {
        private readonly IMongoDatabase _database;
        private IEnumerable<string> collectionsName = [];

        public MainMigration(IOptions<DBSettings> dbSettings)
        {
            MongoClient client = new MongoClient(dbSettings.Value.ConnectionURI);
            _database = client.GetDatabase(dbSettings.Value.DatabaseName);
            collectionsName = [
                dbSettings.Value.Collections.AccountCollection,
                dbSettings.Value.Collections.BrandCollection,
                dbSettings.Value.Collections.CategorySectionCollection,
                dbSettings.Value.Collections.OrderHistoryCollection,
                dbSettings.Value.Collections.ProductCollection,
            ];
        }

        public void CreateCollection(string collectionName)
        {
            _database.CreateCollection(collectionName);
        }

        public void DropCollection(string collectionName)
        {
            _database.DropCollection(collectionName);
        }

        public void CheckForUpdate<T>(string collectionNameCheck)
        {
            IMongoCollection<T> collectionCheck = _database.GetCollection<T>(collectionNameCheck);
            if (collectionCheck == null)
            {
                _database.CreateCollection(collectionNameCheck);
            }
            //this code will be use for future update, assume that colletion need update
            else
            {
                _database.DropCollection(collectionNameCheck);
                _database.CreateCollection(collectionNameCheck);
            }
        }
    }
}
