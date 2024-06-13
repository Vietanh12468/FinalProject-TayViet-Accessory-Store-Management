using FinalProject_TayViet_Accessory_Store_Management.Models.ExceptionModels;
using FinalProject_TayViet_Accessory_Store_Management.Utility.DatabaseUtility;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinalProject_TayViet_Accessory_Store_Management.Server.Controllers
{
    // Generic controller template class for basic CRUD operations
    public class ControllerTemplate<T> : Controller
    {
        protected readonly DatabaseServices<T> _databaseServices;

        // Constructor to initialize database services
        public ControllerTemplate(DatabaseServices<T> databaseServices) => _databaseServices = databaseServices;

        // Method to get the first 20 records and the total record count
        [HttpGet]
        public virtual async Task<ActionResult<List<T>>> Get()
        {
            try
            {
                var records = await _databaseServices.ReadAsync();
                var totalRecords = await _databaseServices.GetTotalRecord();
                return Ok(new { Records = records, TotalRecords = totalRecords });
            }
            catch (NotFoundException) { return NotFound("The List Is Empty"); }
            catch (Exception) { throw new UnknownException(); }
        }

        // Virtual method to get a specific page of records and the total record count
        [HttpGet("{page}")]
        public virtual async Task<ActionResult<List<T>>> Get(int page)
        {
            try
            {
                var records = await _databaseServices.ReadAsync(page);
                var totalRecords = await _databaseServices.GetTotalRecord();
                return Ok(new { Records = records, TotalRecords = totalRecords });
            }
            catch (NotFoundException) { return NotFound("The List Is Empty"); }
            catch (Exception) { throw new UnknownException(); }
        }

        // Method to create a new record
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] T obj)
        {
            await _databaseServices.CreateAsync(obj);
            return Ok();
        }

        // Method to update an existing record
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

        // Method to delete a record
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _databaseServices.DeleteAsync("id", id);
            return NoContent();
        }
    }
}
