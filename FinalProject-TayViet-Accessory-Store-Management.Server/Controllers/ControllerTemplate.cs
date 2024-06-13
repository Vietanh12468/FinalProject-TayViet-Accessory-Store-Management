using FinalProject_TayViet_Accessory_Store_Management.Models.ExceptionModels;
using FinalProject_TayViet_Accessory_Store_Management.Utility.DatabaseUtility;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject_TayViet_Accessory_Store_Management.Server.Controllers
{
    public class ControllerTemplate<T> : Controller
    {
        private readonly DatabaseServices<T> _databaseServices;
        public ControllerTemplate(DatabaseServices<T> databaseServices) => _databaseServices = databaseServices;

        // Get all brands Api
        [HttpGet]
        public async Task<ActionResult<List<T>>> Get()
        {
            try
            {
                return await _databaseServices.ReadAsync();
            }
            catch (NotFoundException) { return NotFound("The List Is Empty"); }
            catch (Exception) { throw new UnknownException(); }
        }

        // Get brand by id
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

        // Update brand by id
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

        // Create brand
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] T obj)
        {
            await _databaseServices.CreateAsync(obj);
            return Ok();
        }

        // Delete brand
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _databaseServices.DeleteAsync("id", id);
            return NoContent();
        }
    }
}
