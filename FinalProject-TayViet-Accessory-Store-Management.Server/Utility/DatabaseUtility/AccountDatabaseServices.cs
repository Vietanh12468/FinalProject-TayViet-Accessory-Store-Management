﻿using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using FinalProject_TayViet_Accessory_Store_Management.Models.ExceptionModels;
using MongoDB.Driver.Linq;
using MongoDB.Bson;
using System.Linq;

namespace FinalProject_TayViet_Accessory_Store_Management.Utility.DatabaseUtility
{
    // This class is used to set account collection and model for this databaseServices. To use method inside this class, check the DatabaseServices.cs
    public class AccountDatabaseServices : DatabaseServices<Account>
    {
        private IMongoCollection<Customer> _customerCollection;
        private IMongoCollection<Seller> _sellerCollection;
        private IMongoCollection<Admin> _adminCollection;

        public AccountDatabaseServices(IOptions<DBSettings> dbSettings, int index_customer = 0, int index_seller = 1, int index_admin = 2) : base(dbSettings, index_customer)
        {
            MongoClient client = new MongoClient(dbSettings.Value.ConnectionURI);
            IMongoDatabase mongoDatabase = client.GetDatabase(dbSettings.Value.DatabaseName);
            _customerCollection = mongoDatabase.GetCollection<Customer>(dbSettings.Value.Collections[index_customer]);
            _sellerCollection = mongoDatabase.GetCollection<Seller>(dbSettings.Value.Collections[index_seller]);
            _adminCollection = mongoDatabase.GetCollection<Admin>(dbSettings.Value.Collections[index_admin]);
        }

        public override async Task<List<Account>> ReadAsync()
        {
            List<Customer> customerResult = await _customerCollection.Find(_ => true).ToListAsync();
            List<Seller> sellerResult = await _sellerCollection.Find(_ => true).ToListAsync();
            List<Admin> adminResult = await _adminCollection.Find(_ => true).ToListAsync();
            List<Account> result = customerResult.Cast<Account>().Concat(sellerResult.Cast<Account>()).Concat(adminResult.Cast<Account>()).ToList();
            if (result == null)
            {
                throw new NotFoundException();
            }

            return result;
        }

        public override async Task<long> GetTotalRecordAsync()
        {
            return await _customerCollection.CountDocumentsAsync(_ => true) + await _sellerCollection.CountDocumentsAsync(_ => true) + await _adminCollection.CountDocumentsAsync(_ => true);
        }


        public override async Task<Account> ReadAsync<TT>(string attribute, TT value)
        {
            Account result = null;
            result = await ReadFromCollection(attribute, value, _customerCollection);
            if (result != null)
            {
                return new Account(result);
            }
            result = await ReadFromCollection(attribute, value, _sellerCollection);
            if (result != null)
            {
                return new Account(result);
            }
            result = await ReadFromCollection(attribute, value, _adminCollection);
            if (result != null)
            {
                return new Account(result);
            }
            /*            // Iterate over each collection
                        var filter = Builders<Customer>.Filter.Eq(attribute, value);
                        Account result = await _customerCollection.Find(filter).FirstOrDefaultAsync();
                        if (result != null)
                        {
                            return result;
                        }

                        var filter1 = Builders<Admin>.Filter.Eq(attribute, value);
                        Account admin = await _adminCollection.Find(filter1).FirstOrDefaultAsync();
                        if (result != null)
                        {
                            return result;
                        }*/

            throw new NotFoundException();
        }

        private async Task<Account> ReadFromCollection<T, TT>(string attribute, TT value, IMongoCollection<T> collection)
        {
            var filter = Builders<T>.Filter.Eq(attribute, value);
            T result = await collection.Find(filter).FirstOrDefaultAsync();
            return result as Account;
        }

        public override async Task<List<Account>> ReadAsync(int skip = 0, int limit = 20)
        {
            List<Customer> customerResult = await _customerCollection.Find(_ => true).ToListAsync();
            List<Seller> sellerResult = await _sellerCollection.Find(_ => true).ToListAsync();
            List<Admin> adminResult = await _adminCollection.Find(_ => true).ToListAsync();
            List<Account> result = customerResult.Cast<Account>().Concat(sellerResult.Cast<Account>()).Concat(adminResult.Cast<Account>()).ToList();
            if (result == null)
            {
                throw new NotFoundException();
            }
            result = result.OrderBy(obj => obj.id).Skip(skip).Take(limit).ToList();
            return result;
        }

        public override async Task<List<Account>> SearchAsync(string attribute, string value, int skip = 0, int limit = 20)
        {
            List<Account> customerResult = await SearchFromCollection(attribute, value, _customerCollection);
            List<Account> sellerResult = await SearchFromCollection(attribute, value, _sellerCollection);
            List<Account> adminResult = await SearchFromCollection(attribute, value, _adminCollection);
            List<Account> result = customerResult.Cast<Account>().Concat(sellerResult.Cast<Account>()).Concat(adminResult.Cast<Account>()).ToList();
            if (result == null)
            {
                throw new NotFoundException();
            }
            result = result.OrderBy(obj => obj.id).Skip(skip).Take(limit).ToList();
            return result;
        }

        public async Task<List<Account>> SearchFromCollection<T>(string attribute, string value, IMongoCollection<T> collection)
        {
            var pattern = new BsonRegularExpression(value, "i");
            var filter = Builders<T>.Filter.Regex(attribute, pattern);
            List<T> collectionResult = await collection.Find(filter).ToListAsync();
            List<Account> result = collectionResult.Cast<Account>().ToList();
            return result;
        }

        public override async Task<long> GetTotalSearchRecordAsync(string attribute, string value)
        {
            List<Account> customerResult = await SearchFromCollection(attribute, value, _customerCollection);
            List<Account> sellerResult = await SearchFromCollection(attribute, value, _sellerCollection);
            List<Account> adminResult = await SearchFromCollection(attribute, value, _adminCollection);
            List<Account> result = customerResult.Cast<Account>().Concat(sellerResult.Cast<Account>()).Concat(adminResult.Cast<Account>()).ToList();
            if (result == null)
            {
                throw new NotFoundException();
            }
            return result.Count;
        }
    }
}
