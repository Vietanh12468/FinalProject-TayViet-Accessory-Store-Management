using FinalProject_TayViet_Accessory_Store_Management.Models.ExceptionModels;
using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
using FinalProject_TayViet_Accessory_Store_Management.Utility.DatabaseUtility;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalProject_TayViet_Accessory_Store_Management.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerTemplate<Admin>
    {
        public AdminController(AccountDatabaseServices<Admin> accountDatabaseServices) : base(databaseServices: accountDatabaseServices) { }

        // Override the Get method to return only admins
        [HttpGet]
        public override async Task<ActionResult<List<Admin>>> Get()
        {
            try
            {
                var records = await _databaseServices.ReadAsync("role", "Admin");
                var totalRecords = await _databaseServices.GetTotalRecord();
                return Ok(new { Records = records, TotalRecords = totalRecords });
            }
            catch (NotFoundException) { return NotFound("No Admins Found"); }
            catch (Exception) { throw new UnknownException(); }
        }

        // Override the Get method to return a specific page of admins
        [HttpGet("{page}")]
        public override async Task<ActionResult<List<Admin>>> Get(int page)
        {
            try
            {
                var records = await _databaseServices.ReadAsync(page);
                var totalRecords = await _databaseServices.GetTotalRecord();
                return Ok(new { Records = records, TotalRecords = totalRecords });
            }
            catch (NotFoundException) { return NotFound("No Admins Found"); }
            catch (Exception) { throw new UnknownException(); }
        }
    }
}
