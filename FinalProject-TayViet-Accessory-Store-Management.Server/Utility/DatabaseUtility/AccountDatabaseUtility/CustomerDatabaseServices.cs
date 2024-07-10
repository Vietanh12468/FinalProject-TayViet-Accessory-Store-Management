using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FinalProject_TayViet_Accessory_Store_Management.Server.Utility.DatabaseUtility.AccountDatabaseUtility
{
    public class CustomerDatabaseServices : AccountDatabaseServiceTemplate<Customer>
    {
        public CustomerDatabaseServices(IOptions<DBSettings> dbSettings, int index_collection = 0) : base(dbSettings, index_collection) { }

        public async Task InsertSubProductInCart(string customerId, string productId, SubProductInCart subProductInCart)
        {
            var filter = Builders<Customer>.Filter.And(
                Builders<Customer>.Filter.Eq("id", customerId),
                Builders<Customer>.Filter.Eq("cartList.productID", productId)
            );

            var update = Builders<Customer>.Update.Push("cartList.$.subProductList", subProductInCart);

            await _collection.UpdateOneAsync(filter, update);
        }

        public async Task InsertProductInCart(string customerId, string productId, ProductInCart productInCart)
        {
            var filter = Builders<Customer>.Filter.Eq("id", customerId);
            var update = Builders<Customer>.Update.Push("cartList", productInCart);

            await _collection.UpdateOneAsync(filter, update);
        }
    }
}
