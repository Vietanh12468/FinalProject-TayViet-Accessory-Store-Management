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
    public class SellerController : ControllerTemplate<Seller>
    {
        public SellerController(AccountDatabaseServices<Seller> accountDatabaseServices) : base(databaseServices: accountDatabaseServices) { }

        // Override the Get method to return only sellers
        [HttpGet]
        public override async Task<ActionResult<List<Seller>>> Get()
        {
            try
            {
                var records = await _databaseServices.ReadAsync("role", "Seller");
                var totalRecords = await _databaseServices.GetTotalRecord();
                return Ok(new { Records = records, TotalRecords = totalRecords });
            }
            catch (NotFoundException) { return NotFound("No Sellers Found"); }
            catch (Exception) { throw new UnknownException(); }
        }

        // Override the Get method to return a specific page of sellers
        [HttpGet("{page}")]
        public override async Task<ActionResult<List<Seller>>> Get(int page)
        {
            try
            {
                var records = await _databaseServices.ReadAsync(page);
                var totalRecords = await _databaseServices.GetTotalRecord();
                return Ok(new { Records = records, TotalRecords = totalRecords });
            }
            catch (NotFoundException) { return NotFound("No Sellers Found"); }
            catch (Exception) { throw new UnknownException(); }
        }
    }
}
