using FinalProject_TayViet_Accessory_Store_Management.Models.ExceptionModels;
using FinalProject_TayViet_Accessory_Store_Management.Utility.DatabaseUtility;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject_TayViet_Accessory_Store_Management.Server.Controllers
{
    public class ControllerTemplate<T> : Controller
    {
        protected readonly DatabaseServices<T> _databaseServices;
        public ControllerTemplate(DatabaseServices<T> databaseServices) => _databaseServices = databaseServices;

        // Get with pagination
        [HttpGet]
        public virtual async Task<ActionResult<List<T>>> Get([FromQuery] int page = 1)
        {
            try
            {
                var result = await _databaseServices.ReadAsync(page);
                var totalRecords = await _databaseServices.GetTotalRecord();
                Response.Headers.Add("X-Total-Count", totalRecords.ToString());
                return result;
            }
            catch (NotFoundException) { return NotFound("The List Is Empty"); }
            catch (Exception) { throw new UnknownException(); }
        }

        // Get by id
        [HttpGet("{id}")]
        public async Task<ActionResult<T>> Get(string id)
        {
            try
            {
                return await _databaseServices.ReadAsync("id", id);
            }
            catch (FormatException) { return BadRequest("Invalid Id"); }
            catch (NotFoundException) { return NotFound("Item Not Found Or Deleted"); }
            catch (Exception) { throw new UnknownException(); }
        }

        // Other CRUD methods remain unchanged
    }
}
