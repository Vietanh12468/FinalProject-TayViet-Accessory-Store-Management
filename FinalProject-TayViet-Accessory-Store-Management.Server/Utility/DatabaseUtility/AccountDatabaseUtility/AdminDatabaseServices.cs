using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
using Microsoft.Extensions.Options;

namespace FinalProject_TayViet_Accessory_Store_Management.Server.Utility.DatabaseUtility.AccountDatabaseUtility
{
    public class AdminDatabaseServices : AccountDatabaseServiceTemplate<Admin>
    {
        public AdminDatabaseServices(IOptions<DBSettings> dbSettings, int index_collection = 2) : base(dbSettings, index_collection) { }
    }
}
