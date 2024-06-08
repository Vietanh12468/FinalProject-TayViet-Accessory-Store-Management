using FinalProject_TayViet_Accessory_Store_Management.Models;
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

        [HttpGet]
        public async Task<List<Brand>> Get()
        {
            return await _brandDatabaseServices.ReadAsync();
        }

        [HttpGet("{id}")]
        public async Task<Brand> Get(string id)
        {
            return await _brandDatabaseServices.ReadAsync("id", id);
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