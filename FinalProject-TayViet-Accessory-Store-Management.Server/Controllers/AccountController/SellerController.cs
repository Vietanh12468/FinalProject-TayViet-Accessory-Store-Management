using Microsoft.AspNetCore.Mvc;
using FinalProject_TayViet_Accessory_Store_Management.Utility.DatabaseUtility;
using FinalProject_TayViet_Accessory_Store_Management.Server.Models;

namespace FinalProject_TayViet_Accessory_Store_Management.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SellerController : AccountControllerTemplate<Seller>
    {
        public SellerController(AccountDatabaseServices<Seller> accountDatabaseServices) : base(accountDatabaseServices) => _databaseServices = accountDatabaseServices;
    }
}
