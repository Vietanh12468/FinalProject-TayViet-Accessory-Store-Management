using FinalProject_TayViet_Accessory_Store_Management.Models.ExceptionModels;
using FinalProject_TayViet_Accessory_Store_Management.Utility.DatabaseUtility;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject_TayViet_Accessory_Store_Management.Server.Controllers
{
    public class ControllerTemplate<T> : Controller
    {
        protected readonly DatabaseServices<T> _databaseServices;

        public ControllerTemplate(DatabaseServices<T> databaseServices)
        {
            _databaseServices = databaseServices;
        }

        [HttpGet]
        public virtual async Task<ActionResult<List<T>>> Get()
        {
            try
            {
                var result = await _databaseServices.ReadAsync();
                return Ok(result);
            }
            catch (NotFoundException) { return NotFound("The List Is Empty"); }
            catch (Exception) { throw new UnknownException(); }
        }

        [HttpGet("{page:int}")]
        public async Task<ActionResult<Dictionary<string, object>>> Get(int page)
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
