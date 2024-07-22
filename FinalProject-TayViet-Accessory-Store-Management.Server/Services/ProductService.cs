using System;
using System.Linq;
using FinalProject_TayViet_Accessory_Store_Management.Server.Interfaces;
using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace FinalProject_TayViet_Accessory_Store_Management.Server.Services
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<Product> _products;

        public ProductService(IOptions<DBSettings> dbSettings)
        {
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionURI);
            var database = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
            var productCollectionName = dbSettings.Value.Collections.FirstOrDefault(c => c == "Product");
            if (productCollectionName == null)
            {
                throw new ArgumentException("Product collection name not found in settings.");
            }
            _products = database.GetCollection<Product>(productCollectionName);
        }

        public void Buy(string productId, string subProductId, int quantity)
        {
            var product = _products.Find(p => p.id == productId).FirstOrDefault();
            if (product == null) throw new ArgumentException($"Product with ID {productId} not found.");

            var subProduct = product.subProductList.FirstOrDefault(sp => sp.name == subProductId);
            if (subProduct == null) throw new ArgumentException($"SubProduct with ID {subProductId} not found.");

            subProduct.Buy(quantity);
            _products.ReplaceOne(p => p.id == productId, product);
        }

        public void Restock(string productId, string subProductId, int quantity)
        {
            var product = _products.Find(p => p.id == productId).FirstOrDefault();
            if (product == null) throw new ArgumentException($"Product with ID {productId} not found.");

            var subProduct = product.subProductList.FirstOrDefault(sp => sp.name == subProductId);
        }
    }
}
