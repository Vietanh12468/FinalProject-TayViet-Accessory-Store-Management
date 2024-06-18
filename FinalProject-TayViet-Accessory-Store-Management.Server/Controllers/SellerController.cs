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
    public class SellerController : ControllerTemplate<Account>
    {
        public SellerController(DatabaseServices<Account> databaseServices) : base(databaseServices)
        {
        }

        // Override Get method to return only seller accounts
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Account>>> GetSellers()
        {
            try
            {
                var result = await _databaseServices.ReadAsync("Role", "Seller");
                if (result == null || result.Count == 0)
                {
                    throw new NotFoundException();
                }
                var totalRecords = result.Count;
                Response.Headers.Add("X-Total-Count", totalRecords.ToString());
                return result;
            }
            catch (NotFoundException) { return NotFound("The List Is Empty"); }
            catch (Exception) { throw new UnknownException(); }
        }
    }
}
