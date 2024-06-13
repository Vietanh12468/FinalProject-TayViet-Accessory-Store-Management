using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FinalProject_TayViet_Accessory_Store_Management.Utility.DatabaseUtility
{
    // This class is used to set brand collection and model for this databaseServices. To use method inside this class, check the DatabaseServices.cs
    public class BrandDatabaseServices : DatabaseServices<Brand>
    {
        public BrandDatabaseServices(IOptions<DBSettings> dbSettings, int index_collection = 1) : base(dbSettings, index_collection) { }

    }
}