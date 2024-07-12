using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
using Microsoft.Extensions.Options;

namespace FinalProject_TayViet_Accessory_Store_Management.Server.Utility.DatabaseUtility.AccountDatabaseUtility
{
    public class SellerDatabaseServices : AccountDatabaseServiceTemplate<Seller>
    {
        public SellerDatabaseServices(IOptions<DBSettings> dbSettings, int index_collection = 1) : base(dbSettings, index_collection) { }
    }
}
