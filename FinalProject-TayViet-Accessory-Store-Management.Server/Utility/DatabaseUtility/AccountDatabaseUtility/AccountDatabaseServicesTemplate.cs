using FinalProject_TayViet_Accessory_Store_Management.Models.ExceptionModels;
using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
using FinalProject_TayViet_Accessory_Store_Management.Utility.DatabaseUtility;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FinalProject_TayViet_Accessory_Store_Management.Server.Utility.DatabaseUtility.AccountDatabaseUtility
{
    public class AccountDatabaseServiceTemplate<T> : DatabaseServices<T>
    {
        public AccountDatabaseServiceTemplate(IOptions<DBSettings> dbSettings, int index_collection = 0) : base(dbSettings, index_collection) { }
    }
}
