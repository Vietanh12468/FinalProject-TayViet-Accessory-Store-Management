using FinalProject_TayViet_Accessory_Store_Management.Server.Models;

namespace FinalProject_TayViet_Accessory_Store_Management.Server.Utility.DatabaseMigration
{
    public class MigrationService
    {
        private readonly MainMigration _migration;
        public MigrationService(MainMigration migration) => _migration = migration; 
        public void CheckForUpdate()
        {
            _migration.CheckForUpdate<Account>("Account");
            _migration.CheckForUpdate<Brand>("Brand");
            _migration.CheckForUpdate<CategorySection>("CategorySection");
            _migration.CheckForUpdate<OrderHistory>("OrderHistory");
            _migration.CheckForUpdate<Product>("Product");
        }
    }
}
