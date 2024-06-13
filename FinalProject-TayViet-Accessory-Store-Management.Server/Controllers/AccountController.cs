using Microsoft.AspNetCore.Mvc;
using FinalProject_TayViet_Accessory_Store_Management.Utility.DatabaseUtility;
using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
using FinalProject_TayViet_Accessory_Store_Management.Server.Controllers;

namespace FinalProject_TayViet_Accessory_Store_Management.Controllers
{
    /*    [Controller]
        [Route("api/[controller]")]
        public class AccountController : Controller
        {

            private readonly AccountDatabaseServices<Account> _accountDatabaseServices;
            public AccountController(AccountDatabaseServices<Account> accountDatabaseServices) => _accountDatabaseServices = accountDatabaseServices;

            [HttpGet]
            public async Task<List<Account>> Get()
            {
                return await _accountDatabaseServices.ReadAsync();
            }

            [HttpGet("{id}")]
            public async Task<Account> Get(string id)
            {
                return await _accountDatabaseServices.ReadAsync("id", id);
            }

            [HttpPost]
            public async Task<IActionResult> Post([FromBody] Account account)
            {
                await _accountDatabaseServices.CreateAsync(account);
                return Ok();
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(string id)
            {
                await _accountDatabaseServices.DeleteAsync("id", id);
                return NoContent();
            }*/
    /*    }*/
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerTemplate<Account>
    {
        public AccountController(AccountDatabaseServices<Account> accountDatabaseServices) : base(databaseServices: accountDatabaseServices) { }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class SellerController : ControllerTemplate<Seller>
    {
        public SellerController(AccountDatabaseServices<Seller> accountDatabaseServices) : base(databaseServices: accountDatabaseServices) { }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerTemplate<Admin>
    {
        public AdminController(AccountDatabaseServices<Admin> accountDatabaseServices) : base(databaseServices: accountDatabaseServices) { }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerTemplate<Customer>
    {
        public CustomerController(AccountDatabaseServices<Customer> accountDatabaseServices) : base(databaseServices: accountDatabaseServices) { }
    }
}
