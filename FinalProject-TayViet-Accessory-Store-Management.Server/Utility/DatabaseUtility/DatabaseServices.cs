using FinalProject_TayViet_Accessory_Store_Management.Models.ExceptionModels;
using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FinalProject_TayViet_Accessory_Store_Management.Utility.DatabaseUtility
{
    // This class provides general CRUD services for collections in the database.
    // It can be used to create new object database services by declaring the object model in <T> and collection in _collection.
    public class DatabaseServices<T>
    {
        // Abstract collection, can be used for any collection
        protected IMongoCollection<T> _collection;

        // Constructor to initialize database connection and collection
        public DatabaseServices(IOptions<DBSettings> dbSettings, int index_collection)
        {
            MongoClient client = new MongoClient(dbSettings.Value.ConnectionURI);
            IMongoDatabase mongoDatabase = client.GetDatabase(dbSettings.Value.DatabaseName);
            _collection = mongoDatabase.GetCollection<T>(dbSettings.Value.Collections[index_collection]);
        }

        // Method to read records with pagination
        public async Task<List<T>> ReadAsync(int page = 1, int pageSize = 20)
        {
            List<T> result = await _collection.Find(_ => true)
                                              .Skip((page - 1) * pageSize)
                                              .Limit(pageSize)
                                              .ToListAsync();

            if (result == null)
            {
                throw new NotFoundException();
            }

            return result;
        }

        // Method to get total number of records in the collection
        public async Task<int> GetTotalRecordAsync()
        {
            return (int)await _collection.CountDocumentsAsync(_ => true);
        }

        // Method to read a single record by an attribute
        public async Task<List<T>> ReadAsync<TT>(string attribute, TT value)
        {
            var filter = Builders<T>.Filter.Eq(attribute, value);
            List<T> result = await _collection.Find(filter).ToListAsync();

            if (result == null)
            {
                throw new NotFoundException();
            }

            return result;
        }

        // Method to create a new record
        public async Task CreateAsync(T obj) => await _collection.InsertOneAsync(obj);

        // Method to update an existing record
        public async Task UpdateAsync<TT>(T obj, string attribute, TT value)
        {
            var filter = Builders<T>.Filter.Eq(attribute, value);
            await _collection.ReplaceOneAsync(filter, obj);
        }

        // Method to delete a record
        public async Task DeleteAsync<TT>(string attribute, TT value)
        {
            var filter = Builders<T>.Filter.Eq(attribute, value);
            await _collection.DeleteOneAsync(filter);
        }
    }
}
