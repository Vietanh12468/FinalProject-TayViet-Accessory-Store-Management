using Microsoft.AspNetCore.Mvc;
using FinalProject_TayViet_Accessory_Store_Management.Server.Utility.DatabaseUtility.AccountDatabaseUtility;
using FinalProject_TayViet_Accessory_Store_Management.Server.Models;

namespace FinalProject_TayViet_Accessory_Store_Management.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SellerController : AccountControllerTemplate<Seller>
    {
        public SellerController(SellerDatabaseServices accountDatabaseServices) : base(accountDatabaseServices) { }
    }
}
