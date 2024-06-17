using Microsoft.Extensions.Options;
using MongoDB.Driver;
using FinalProject_TayViet_Accessory_Store_Management.Models.ExceptionModels;
using FinalProject_TayViet_Accessory_Store_Management.Server.Models;

namespace FinalProject_TayViet_Accessory_Store_Management.Utility.DatabaseUtility
{
    public class AccountDatabaseServices<T> : DatabaseServices<T>
    {
        public AccountDatabaseServices(IOptions<DBSettings> dbSettings, int index_collection)
            : base(dbSettings, index_collection)
        {
        }

        public async Task<List<T>> ReadByRoleAsync(string role)
        {
            var filter = Builders<T>.Filter.Eq("Role", role);
            return await _collection.Find(filter).ToListAsync();
        }
    }
}
