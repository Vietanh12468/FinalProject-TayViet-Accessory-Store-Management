using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
using FinalProject_TayViet_Accessory_Store_Management.Models.ExceptionModels;
using FinalProject_TayViet_Accessory_Store_Management.Utility.DatabaseUtility;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject_TayViet_Accessory_Store_Management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrandController : Controller
    {
        private readonly BrandDatabaseServices _brandDatabaseServices;
        public BrandController(BrandDatabaseServices brandDatabaseServices) => _brandDatabaseServices = brandDatabaseServices;

        // Get all brands Api
        [HttpGet]
        public async Task<List<Brand>> Get()
        {
            try
            {
                return await _brandDatabaseServices.ReadAsync();
            }
            catch (NotFoundException ex) { throw ex; }
            catch (Exception) { throw new UnknownException(); }
        }

        // Get brand by id
        [HttpGet("{id}")]
        public async Task<ActionResult<Brand>> Get(string id)
        {
            try
            {
                return await _brandDatabaseServices.ReadAsync("id", id);
            }
            catch (FormatException){ return BadRequest("Invalid Brand Id"); }
            catch (NotFoundException) { return NotFound("Brand Not Found Or Deleted"); }
            catch (Exception) { throw new UnknownException(); }
        }

        // Update brand by id
        [HttpPut]
        public async Task<ActionResult> UpdateAccount([FromBody] Brand brand)
        {
            try
            {
                var brandChange = await _brandDatabaseServices.ReadAsync("id", brand.id);
                await _brandDatabaseServices.UpdateAsync(brand, "id", brand.id);
                return Ok("Account Updated Successfully");
            }
            catch (FormatException) { return BadRequest("Invalid Brand Id"); }
            catch (NotFoundException) { return NotFound("Brand Not Found Or Deleted"); }
            catch (Exception) { throw new UnknownException(); }
        }

        // Create brand
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Brand brand)
        {
            await _brandDatabaseServices.CreateAsync(brand);
            return Ok();
        }

        // Delete brand
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _brandDatabaseServices.DeleteAsync("id", id);
            return NoContent();
        }
    }
}