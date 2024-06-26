using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FinalProject_TayViet_Accessory_Store_Management.Server.Utility.DatabaseMigration
{
    public class MainMigration
    {
        private readonly IMongoDatabase database;
        private static int version = 1;
        private static int previousVersion;

        public MainMigration(IOptions<DBSettings> dbSettings)
        {
            MongoClient client = new MongoClient(dbSettings.Value.ConnectionURI);
            database = client.GetDatabase(dbSettings.Value.DatabaseName);
        }

        public void CreateCollection(string collectionName)
        {
            database.CreateCollection(collectionName);
        }

        public void DropCollection(string collectionName)
        {
            database.DropCollection(collectionName);
        }

        public void CheckForUpdate<T>(string collectionName)
        {
            IMongoCollection<T> collectionCheck = database.GetCollection<T>(collectionName);
            if (collectionCheck == null)
            {
                database.CreateCollection(collectionName);
            }

            //this code will be use for future update, assume that colletion need update
/*            else if (version > previousVersion)
            {
                previousVersion = version;
                database.DropCollection(collectionName);
                database.CreateCollection(collectionName);
            }*/
        }
    }
}
