using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
using FinalProject_TayViet_Accessory_Store_Management.Utility.DatabaseUtility;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject_TayViet_Accessory_Store_Management.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategorySectionController : ControllerTemplate<CategorySection>
    {
        public CategorySectionController(CategorySectionDatabaseService categorySectionDatabaseService) : base(databaseServices: categorySectionDatabaseService) { }
    }
}
