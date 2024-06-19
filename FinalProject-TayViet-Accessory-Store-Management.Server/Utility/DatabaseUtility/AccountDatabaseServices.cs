using Microsoft.Extensions.Options;
using MongoDB.Driver;
using FinalProject_TayViet_Accessory_Store_Management.Models.ExceptionModels;
using FinalProject_TayViet_Accessory_Store_Management.Server.Models;

namespace FinalProject_TayViet_Accessory_Store_Management.Utility.DatabaseUtility
{
    public class AccountDatabaseServices<T> : DatabaseServices<T>
    {
        public AccountDatabaseServices(IOptions<DBSettings> dbSettings)
            : base(dbSettings, GetCollectionIndex<T>())
        {
        }

        private static int GetCollectionIndex<T>()
        {
            if (typeof(T) == typeof(Account)) return 0;
            if (typeof(T) == typeof(Customer)) return 1;
            if (typeof(T) == typeof(Admin)) return 2;
            if (typeof(T) == typeof(Seller)) return 3;
            throw new ArgumentException("Unknown account type");
        }

        public async Task<List<T>> ReadByRoleAsync(string role)
        {
            var filter = Builders<T>.Filter.Eq("Role", role);
            return await _collection.Find(filter).ToListAsync();
        }
    }
}
