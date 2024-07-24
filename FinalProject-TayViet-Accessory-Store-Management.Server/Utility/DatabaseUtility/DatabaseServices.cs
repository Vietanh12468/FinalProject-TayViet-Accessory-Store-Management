using FinalProject_TayViet_Accessory_Store_Management.Models.ExceptionModels;
using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
using FinalProject_TayViet_Accessory_Store_Management.Server.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Linq;

namespace FinalProject_TayViet_Accessory_Store_Management.Utility.DatabaseUtility
{
    // This class provided general CRUD services for collections in database.
    // It can be used to create new object database services by declare object model in <T> and collection in _collection
    public class DatabaseServices<T> : IDatabaseServices<T>
    {
        // Abstact colletion, can be used for any colletion
        protected IMongoCollection<T> _collection;
        public DatabaseServices(IOptions<DBSettings> dbSettings, int index_collection)
        {
            MongoClient client = new MongoClient(dbSettings.Value.ConnectionURI);
            IMongoDatabase mongoDatabase = client.GetDatabase(dbSettings.Value.DatabaseName);
            _collection = mongoDatabase.GetCollection<T>(dbSettings.Value.Collections[index_collection]);
        }

        public virtual async Task<List<T>> ReadAsync()
        {
            List<T> result = await _collection.Find(_ => true).ToListAsync();

            if (result == null)
            {
                throw new NotFoundException();
            }

            return result;
        }

        public virtual async Task<T> ReadAsync<TT>(string attribute, TT value)
        {
            var filter = Builders<T>.Filter.Eq(attribute, value);
            T result = await _collection.Find(filter).FirstOrDefaultAsync();

            if (result == null)
            {
                throw new NotFoundException();
            }

            return result;
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

        public virtual async Task<long> GetTotalRecordAsync()
        {
            return await _collection.CountDocumentsAsync(_ => true);
        }

        public virtual async Task<List<T>> ReadAsync(int skip = 0, int limit = 20)
        {
            IMongoQueryable<T> queryableCollection = _collection.AsQueryable();
            return await queryableCollection.Skip(skip).Take(limit).ToListAsync();

/*            return await _collection.Find(_ => true).Skip(skip).Limit(limit).ToListAsync();*/
        }
        public virtual async Task<List<T>> SearchAsync(string attribute, string value, int skip = 0, int limit = 20)
        {
            var pattern = new BsonRegularExpression(value, "i"); 
            var filter = Builders<T>.Filter.Regex(attribute, pattern); 
            return await _collection.Find(filter).Skip(skip).Limit(limit).ToListAsync();
        }

        public virtual async Task<long> GetTotalSearchRecordAsync(string attribute, string value)
        {
            var pattern = new BsonRegularExpression(value, "i"); 
            var filter = Builders<T>.Filter.Regex(attribute, pattern); 
            return await _collection.CountDocumentsAsync(filter);
        }
    }

}
