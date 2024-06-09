using FinalProject_TayViet_Accessory_Store_Management.Models;
using FinalProject_TayViet_Accessory_Store_Management.Models.ExceptionModels;
using FinalProject_TayViet_Accessory_Store_Management.Utility.DatabaseUtility;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FinalProject_TayViet_Accessory_Store_Management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BrandController : Controller
    {
        private readonly BrandDatabaseServices _brandDatabaseServices;
        public BrandController(BrandDatabaseServices brandDatabaseServices) => _brandDatabaseServices = brandDatabaseServices;

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

        [HttpGet("{id}")]
        public async Task<Brand> Get(string id)
        {
            try
            {
                return await _brandDatabaseServices.ReadAsync("id", id);
            }
            catch (FormatException) { throw new IncorrectFormatException($"Incorrect id format"); }
            catch (NotFoundException ex) { throw ex; }
            catch (Exception) { throw new UnknownException(); }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Brand brand)
        {
            await _brandDatabaseServices.CreateAsync(brand);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _brandDatabaseServices.DeleteAsync("id", id);
            return NoContent();
        }
    }
}