using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FinalProject_TayViet_Accessory_Store_Management.Utility.DatabaseUtility
{
    // This class is used to set category section collection and model for this databaseServices. To use method inside this class, check the DatabaseServices.cs
    public class CategorySectionDatabaseService : DatabaseServices<CategorySection>
    {
        public CategorySectionDatabaseService(IOptions<DBSettings> dbSettings, int index_collection = 3) : base(dbSettings, index_collection) { }
    }
}