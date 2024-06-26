using Microsoft.AspNetCore.Mvc;
using FinalProject_TayViet_Accessory_Store_Management.Utility.DatabaseUtility;
using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
using FinalProject_TayViet_Accessory_Store_Management.Server.Interfaces;

namespace FinalProject_TayViet_Accessory_Store_Management.Server.Controllers
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
    public class AccountControllerTemplate<T> : ControllerTemplate<T> where T : IAccount
    {
        private new readonly AccountDatabaseServices<T> _databaseServices;
        public AccountControllerTemplate(AccountDatabaseServices<T> accountDatabaseServices) : base(databaseServices: accountDatabaseServices) => _databaseServices = accountDatabaseServices;

        public override async Task<ActionResult<Dictionary<string, object>>> Get()
        {
            long totalRecords = await _databaseServices.GetTotalRecordAsync();
            var response = new Dictionary<string, object>
            {
                { "data", await _databaseServices.ReadAsync()},
                { "total", totalRecords}
            };
            return response;
        }
    }

}
