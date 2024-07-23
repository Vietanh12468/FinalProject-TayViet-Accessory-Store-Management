using Microsoft.AspNetCore.Mvc;
using FinalProject_TayViet_Accessory_Store_Management.Server.Utility.DatabaseUtility.AccountDatabaseUtility;
using FinalProject_TayViet_Accessory_Store_Management.Server.Interfaces;
using FinalProject_TayViet_Accessory_Store_Management.Utility.DatabaseUtility;

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
        private new readonly AccountDatabaseServiceTemplate<T> _databaseServices;
        public AccountControllerTemplate(AccountDatabaseServiceTemplate<T> accountDatabaseServices) : base(databaseServices: accountDatabaseServices) => _databaseServices = accountDatabaseServices;

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

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                T result = await _databaseServices.ReadAsync("username", request.Username);

                if(result == null)
                {
                    return NotFound();
                }
                if (result.password != request.Password)
                {
                    return Unauthorized();
                }
                result.login();
                return Ok("Login successful.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout([FromBody] LogoutRequest request)
        {
            try
            {
                T result = await _databaseServices.ReadAsync("username", request.Username);

                if (result == null)
                {
                    return NotFound();
                }
                result.logout();
                return Ok("Logout successful.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class LogoutRequest
    {
        public string Username { get; set; }
    }

}
