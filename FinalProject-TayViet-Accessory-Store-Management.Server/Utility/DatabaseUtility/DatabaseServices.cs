using FinalProject_TayViet_Accessory_Store_Management.Models.ExceptionModels;
using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FinalProject_TayViet_Accessory_Store_Management.Utility.DatabaseUtility
{
    // This class provides general CRUD services for collections in the database.
    // It can be used to create new object database services by declaring object model in <T> and collection in _collection.
    public class DatabaseServices<T>
    {
        // Abstract collection, can be used for any collection
        public IMongoCollection<T> _collection;

        public DatabaseServices(IOptions<DBSettings> dbSettings, int index_collection)
        {
            MongoClient client = new MongoClient(dbSettings.Value.ConnectionURI);
            IMongoDatabase mongoDatabase = client.GetDatabase(dbSettings.Value.DatabaseName);
            _collection = mongoDatabase.GetCollection<T>(dbSettings.Value.Collections[index_collection]);
        }

        public async Task<List<T>> ReadAsync(int pageNumber = 1, int pageSize = 20)
        {
            var result = await _collection.Find(_ => true)
                                          .Skip((pageNumber - 1) * pageSize)
                                          .Limit(pageSize)
                                          .ToListAsync();

            if (result == null || result.Count == 0)
            {
                throw new NotFoundException();
            }

            return result;
        }

        public async Task<T> ReadAsync<TT>(string attribute, TT value)
        {
            var filter = Builders<T>.Filter.Eq(attribute, value);
            var result = await _collection.Find(filter).FirstOrDefaultAsync();

            if (result == null)
            {
                throw new NotFoundException();
            }

            return result;
        }

        public async Task<int> GetTotalRecord()
        {
            return (int)await _collection.CountDocumentsAsync(FilterDefinition<T>.Empty);
        }

        public async Task CreateAsync(T obj) => await _collection.InsertOneAsync(obj);

        public async Task UpdateAsync<TT>(T obj, string attribute, TT value)
        {
            var filter = Builders<T>.Filter.Eq(attribute, value);
            await _collection.ReplaceOneAsync(filter, obj);
        }

        public async Task DeleteAsync<TT>(string attribute, TT value)
        {
            var filter = Builders<T>.Filter.Eq(attribute, value);
            await _collection.DeleteOneAsync(filter);
        }
    }
}
