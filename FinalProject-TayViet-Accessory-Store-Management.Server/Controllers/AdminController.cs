using Microsoft.AspNetCore.Mvc;
using FinalProject_TayViet_Accessory_Store_Management.Utility.DatabaseUtility;
using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
using FinalProject_TayViet_Accessory_Store_Management.Server.Controllers;

namespace FinalProject_TayViet_Accessory_Store_Management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerTemplate<Admin>
    {
        public AdminController(AccountDatabaseServices<Admin> accountDatabaseServices) : base(databaseServices: accountDatabaseServices) { }

        // Override the Get method to include pagination
        [HttpGet("paged")]
        public async Task<ActionResult<List<Admin>>> GetPaged([FromQuery] int page = 1)
        {
            var result = await _databaseServices.ReadAsync(page);
            var totalRecords = await _databaseServices.GetTotalRecord();
            Response.Headers.Add("X-Total-Count", totalRecords.ToString());
            return result;
        }

        // Additional methods with unique routes
        [HttpGet("by-role")]
        public async Task<ActionResult<List<Admin>>> GetByRole()
        {
            var result = await _databaseServices.ReadAsync(1); // or whatever logic to get by role
            return result;
        }
    }
}
