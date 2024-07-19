using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
using FinalProject_TayViet_Accessory_Store_Management.Utility.DatabaseUtility;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject_TayViet_Accessory_Store_Management.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerTemplate<Product>
    {
        public ProductController(ProductDatabaseService productDatabaseService) : base(databaseServices: productDatabaseService) { }
        public void Buy(Product product) 
        { 
        
        }
    }
}
