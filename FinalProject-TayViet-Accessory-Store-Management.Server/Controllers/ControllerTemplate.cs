using FinalProject_TayViet_Accessory_Store_Management.Models.ExceptionModels;
using FinalProject_TayViet_Accessory_Store_Management.Utility.DatabaseUtility;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject_TayViet_Accessory_Store_Management.Server.Controllers
{
    public class ControllerTemplate<T> : Controller
    {
        protected readonly DatabaseServices<T> _databaseServices;

        // Constructor to initialize the database service
        public ControllerTemplate(DatabaseServices<T> databaseServices) => _databaseServices = databaseServices;

        // Get first 20 records
        [HttpGet]
        public virtual async Task<ActionResult<List<T>>> Get()
        {
            try
            {
                // Fetch first 20 records
                var result = await _databaseServices.ReadAsync();
                // Get total record count
                var totalRecords = await _databaseServices.GetTotalRecordAsync();
                // Add total record count to response headers
                Response.Headers.Add("X-Total-Count", totalRecords.ToString());
                return result;
            }
            catch (NotFoundException) { return NotFound("The List Is Empty"); }
            catch (Exception) { throw new UnknownException(); }
        }

        // Get records for the specified page (20 records per page)
        [HttpGet("{page:int}")]
        public virtual async Task<ActionResult<List<T>>> Get(int page)
        {
            try
            {
                // Fetch records for the specified page
                var result = await _databaseServices.ReadAsync(page);
                // Get total record count
                var totalRecords = await _databaseServices.GetTotalRecordAsync();
                // Add total record count to response headers
                Response.Headers.Add("X-Total-Count", totalRecords.ToString());
                return result;
            }
            catch (NotFoundException) { return NotFound("The List Is Empty"); }
            catch (Exception) { throw new UnknownException(); }
        }

        // Get record by id
        [HttpGet("{id}")]
        public async Task<ActionResult<T>> Get(string id)
        {
            try
            {
                var result = await _databaseServices.ReadAsync("id", id);
                if (result == null)
                {
                    return NotFound("Item Not Found Or Deleted");
                }
                return Ok(result);
            }
            catch (FormatException) { return BadRequest("Invalid Id"); }
            catch (NotFoundException) { return NotFound("Item Not Found Or Deleted"); }
            catch (Exception) { throw new UnknownException(); }
        }

        // Update record by id
        [HttpPut]
        public async Task<ActionResult> UpdateAccount([FromBody] T obj)
        {
            try
            {
                var objectId = obj.GetType().GetProperty("id")?.GetValue(obj)?.ToString();
                var objChange = await _databaseServices.ReadAsync("id", objectId);
                await _databaseServices.UpdateAsync(obj, "id", objectId);
                return Ok("Item Updated Successfully");
            }
            catch (FormatException) { return BadRequest("Invalid Id"); }
            catch (NotFoundException) { return NotFound("Item Not Found Or Deleted"); }
            catch (Exception) { throw new UnknownException(); }
        }

        // Create record
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] T obj)
        {
            await _databaseServices.CreateAsync(obj);
            return Ok();
        }

        // Delete record
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _databaseServices.DeleteAsync("id", id);
            return NoContent();
        }
    }
}
