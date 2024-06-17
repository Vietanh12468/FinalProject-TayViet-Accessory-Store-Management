using FinalProject_TayViet_Accessory_Store_Management.Models.ExceptionModels;
using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
using FinalProject_TayViet_Accessory_Store_Management.Utility.DatabaseUtility;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalProject_TayViet_Accessory_Store_Management.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SellerController : ControllerTemplate<Seller>
    {
        public SellerController(AccountDatabaseServices<Seller> accountDatabaseServices) : base(databaseServices: accountDatabaseServices) { }

        // Override the Get method to include pagination
        [HttpGet]
        public override async Task<ActionResult<List<Seller>>> Get([FromQuery] int page = 1)
        {
            var result = await _databaseServices.ReadAsync(page);
            var totalRecords = await _databaseServices.GetTotalRecord();
            Response.Headers.Add("X-Total-Count", totalRecords.ToString());
            return result;
        }

        // Additional methods with unique routes
        [HttpGet("role")]
        public async Task<ActionResult<List<Seller>>> GetByRole()
        {
            var result = await _databaseServices.ReadAsync(1); // or whatever logic to get by role
            return result;
        }
    }
}
