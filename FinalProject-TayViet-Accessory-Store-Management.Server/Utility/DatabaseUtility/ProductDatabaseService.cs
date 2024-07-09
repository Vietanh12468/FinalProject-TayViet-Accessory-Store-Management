using FinalProject_TayViet_Accessory_Store_Management.Models;
using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FinalProject_TayViet_Accessory_Store_Management.Utility.DatabaseUtility
{
    // This class is used to set product collection and model for this databaseServices. To use method inside this class, check the DatabaseServices.cs
    public class ProductDatabaseService : DatabaseServices<Product>
    {
        public ProductDatabaseService(IOptions<DBSettings> dbSettings, int index_collection = 4) : base(dbSettings, index_collection) { }

        public async Task<SubProduct> GetSubProduct(string productId, string subProductName, int? quanity = 0)
        {
            Product product = await ReadAsync("id", productId);
            return product.subProductList.FirstOrDefault(subProduct => subProduct.name == subProductName);
        }
    }
}