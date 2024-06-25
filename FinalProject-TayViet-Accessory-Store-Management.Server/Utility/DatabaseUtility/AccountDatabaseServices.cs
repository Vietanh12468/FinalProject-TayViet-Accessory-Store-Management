using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using FinalProject_TayViet_Accessory_Store_Management.Models.ExceptionModels;

namespace FinalProject_TayViet_Accessory_Store_Management.Utility.DatabaseUtility
{
    // This class is used to set account collection and model for this databaseServices. To use method inside this class, check the DatabaseServices.cs
    public class AccountDatabaseServices<T> : DatabaseServices<T>
    {
        public AccountDatabaseServices(IOptions<DBSettings> dbSettings, int index_collection = 0) : base(dbSettings, index_collection) { }

        public async Task<List<T>> ReadAsync(string role)
        {

            var filter = Builders<T>.Filter.Eq("role", role);
            List<T> result = await _collection.Find(filter).ToListAsync();

            if (result == null)
            {
                throw new NotFoundException();
            }

            return result;
        }
    }
}
