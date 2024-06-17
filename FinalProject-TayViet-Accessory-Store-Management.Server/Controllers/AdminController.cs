using Microsoft.AspNetCore.Mvc;
using FinalProject_TayViet_Accessory_Store_Management.Utility.DatabaseUtility;
using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
namespace FinalProject_TayViet_Accessory_Store_Management.Server.Controllers {

    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerTemplate<Admin>
    {
        private readonly AccountDatabaseServices<Admin> _accountDatabaseServices;

        public AdminController(AccountDatabaseServices<Admin> accountDatabaseServices)
            : base(databaseServices: accountDatabaseServices)
        {
            _accountDatabaseServices = accountDatabaseServices;
        }

        [HttpGet]
        public override async Task<ActionResult<List<Admin>>> Get()
        {
            try
            {
                var admins = await _accountDatabaseServices.ReadByRoleAsync("Admin");
                return Ok(admins);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
