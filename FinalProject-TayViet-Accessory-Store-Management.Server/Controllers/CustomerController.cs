using Microsoft.AspNetCore.Mvc;
using FinalProject_TayViet_Accessory_Store_Management.Utility.DatabaseUtility;
using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinalProject_TayViet_Accessory_Store_Management.Models.ExceptionModels;

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

        // Use a unique route template for this method to avoid conflict
        [HttpGet("customers")]
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

        // Use a unique route template for this method to avoid conflict
        [HttpGet("customers/page/{page:int}")]
        public override async Task<ActionResult<Dictionary<string, object>>> Get(int page)
        {
            try
            {
                int skip = (page - 1) * 20;
                var result = await _databaseServices.ReadAsync(skip, 20);
                long totalRecords = await _databaseServices.GetTotalRecordAsync();

                var response = new Dictionary<string, object>
                {
                    { "data", result },
                    { "totalRecords", totalRecords }
                };

                return Ok(response);
            }
            catch (NotFoundException) { return NotFound("The List Is Empty"); }
            catch (Exception) { throw new UnknownException(); }
        }
    }
}
