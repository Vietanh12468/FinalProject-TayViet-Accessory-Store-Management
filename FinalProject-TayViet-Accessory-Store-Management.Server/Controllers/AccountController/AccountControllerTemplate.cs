using Microsoft.AspNetCore.Mvc;
using FinalProject_TayViet_Accessory_Store_Management.Server.Utility.DatabaseUtility.AccountDatabaseUtility;
using FinalProject_TayViet_Accessory_Store_Management.Server.Interfaces;
using FinalProject_TayViet_Accessory_Store_Management.Utility.DatabaseUtility;
using FinalProject_TayViet_Accessory_Store_Management.Models.ExceptionModels;
using System.Security.Authentication;

namespace FinalProject_TayViet_Accessory_Store_Management.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountControllerTemplate<T> : ControllerTemplate<T> where T : IAccount
    {
        private new readonly AccountDatabaseServiceTemplate<T> _databaseServices;
        public AccountControllerTemplate(AccountDatabaseServiceTemplate<T> accountDatabaseServices)
            : base(databaseServices: accountDatabaseServices)
        {
            _databaseServices = accountDatabaseServices;
        }

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
        public async Task<T> Login([FromBody] LoginRequest request)
        {
            try
            {
                T result = await _databaseServices.ReadAsync("username", request.Username);

                if (result == null)
                {
                    throw new NotFoundException();
                }

                if (result.password != request.Password)
                {
                    throw new AuthenticationException();
                }

                result.Login();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
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
                result.Logout();
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
