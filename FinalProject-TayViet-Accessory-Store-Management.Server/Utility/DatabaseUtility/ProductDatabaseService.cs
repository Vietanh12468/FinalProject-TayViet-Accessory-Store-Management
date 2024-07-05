using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FinalProject_TayViet_Accessory_Store_Management.Utility.DatabaseUtility
{
    public class ProductDatabaseService : DatabaseServices<Product>
    {
        public ProductDatabaseService(IOptions<DBSettings> dbSettings, int index_collection = 4) : base(dbSettings, index_collection) { }

        public async Task ChangeSubProductState(string id, string subProductName, string state)
        {
            var filter = Builders<Product>.Filter.Eq("id", id);
            var update = Builders<Product>.Update.Set("subProductList.$[s].state", state);
            var arrayFilters = new List<ArrayFilterDefinition>
            {
                new BsonDocumentArrayFilterDefinition<Product>(new BsonDocument("s.name", subProductName))
            };
            var options = new UpdateOptions { ArrayFilters = arrayFilters };
            await _collection.UpdateOneAsync(filter, update, options);
        }
    }
}