using Microsoft.AspNetCore.Mvc;
using FinalProject_TayViet_Accessory_Store_Management.Models;
using FinalProject_TayViet_Accessory_Store_Management.Utility.DatabaseUtility;

namespace FinalProject_TayViet_Accessory_Store_Management.Controllers
{
    [Controller]
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
/*        private readonly AccountDatabaseServices _accountDatabaseServices;
        public AccountController(AccountDatabaseServices accountDatabaseServices) => _accountDatabaseServices = accountDatabaseServices;

        [HttpGet]
        public async Task<List<User>> Get()
        {
            return await _accountDatabaseServices.ReadAsync();
        }

        [HttpGet("{id}")]
        public async Task<User> Get(string id)
        {
            return await _accountDatabaseServices.ReadAsync("id", id);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            await _accountDatabaseServices.CreateAsync(user);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _accountDatabaseServices.DeleteAsync("id", id);
            return NoContent();
        }

*/
    }
}
