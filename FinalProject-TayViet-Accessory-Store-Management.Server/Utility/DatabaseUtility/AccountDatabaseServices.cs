using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using FinalProject_TayViet_Accessory_Store_Management.Models.ExceptionModels;
using System.Collections.Generic;
using System.Data;

namespace FinalProject_TayViet_Accessory_Store_Management.Utility.DatabaseUtility
{
    // This class is used to set account collection and model for this databaseServices. To use method inside this class, check the DatabaseServices.cs
    public class AccountDatabaseServices<T> : DatabaseServices<T>
    {
        public AccountDatabaseServices(IOptions<DBSettings> dbSettings, int index_collection = 0) : base(dbSettings, index_collection) { }

        public override async Task<List<T>> ReadAsync()
        {
            List<T> result;
            if (typeof(T).Name == "Account")
            {
                result = await _collection.Find(_ => true).ToListAsync();
            }
            else
            {
                var filter = Builders<T>.Filter.Eq("role", typeof(T).Name);
                result = await _collection.Find(filter).ToListAsync();
            }

            if (result == null)
            {
                throw new NotFoundException();
            }

            return result;
        }

        public override async Task<long> GetTotalRecordAsync()
        {
            if (typeof(T).Name == "Account")
            {
                return await _collection.CountDocumentsAsync(_ => true);
            }
            else
            {
                var filter = Builders<T>.Filter.Eq("role", typeof(T).Name);
                return await _collection.CountDocumentsAsync(filter);
            }
        }
    }
}
