using Microsoft.AspNetCore.Mvc;
using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
using FinalProject_TayViet_Accessory_Store_Management.Utility.DatabaseUtility;
namespace FinalProject_TayViet_Accessory_Store_Management.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SellerController : ControllerTemplate<Seller>
    {
        private readonly AccountDatabaseServices<Seller> _accountDatabaseServices;

        public SellerController(AccountDatabaseServices<Seller> accountDatabaseServices)
            : base(databaseServices: accountDatabaseServices)
        {
            _accountDatabaseServices = accountDatabaseServices;
        }

        [HttpGet]
        public override async Task<ActionResult<List<Seller>>> Get()
        {
            try
            {
                var sellers = await _accountDatabaseServices.ReadByRoleAsync("Seller");
                return Ok(sellers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
