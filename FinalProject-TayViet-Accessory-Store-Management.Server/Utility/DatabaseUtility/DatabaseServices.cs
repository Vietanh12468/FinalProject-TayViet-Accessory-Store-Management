using FinalProject_TayViet_Accessory_Store_Management.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace FinalProject_TayViet_Accessory_Store_Management.Utility.DatabaseUtility
{
    // This class provided general CRUD services for collections in database.
    // It can be used to create new object database services by declare object model in <T> and collection in _collection
    public class DatabaseServices<T>
    {
        // Abstact colletion, can be used for any colletion
        protected IMongoCollection<T> _collection;

        public async Task<List<T>> ReadAsync() => await _collection.Find(_ => true).ToListAsync();

        public async Task<T> ReadAsync<TT>(string attribute, TT value)
        {
            var filter = Builders<T>.Filter.Eq(attribute, value);
            return await _collection.Find(filter).FirstOrDefaultAsync();
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
