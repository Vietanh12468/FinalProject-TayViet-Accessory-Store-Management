using Microsoft.AspNetCore.Mvc;
using FinalProject_TayViet_Accessory_Store_Management.Utility.DatabaseUtility;
using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
namespace FinalProject_TayViet_Accessory_Store_Management.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerTemplate<Customer>
    {
        private readonly AccountDatabaseServices<Customer> _accountDatabaseServices;

        public CustomerController(AccountDatabaseServices<Customer> accountDatabaseServices)
            : base(databaseServices: accountDatabaseServices)
        {
            _accountDatabaseServices = accountDatabaseServices;
        }

        [HttpGet]
        public override async Task<ActionResult<List<Customer>>> Get()
        {
            try
            {
                var customers = await _accountDatabaseServices.ReadByRoleAsync("Customer");
                return Ok(customers);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }

}
