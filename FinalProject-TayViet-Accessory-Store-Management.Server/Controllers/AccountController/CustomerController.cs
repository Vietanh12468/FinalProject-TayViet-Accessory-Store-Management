using Microsoft.AspNetCore.Mvc;
using FinalProject_TayViet_Accessory_Store_Management.Utility.DatabaseUtility;
using FinalProject_TayViet_Accessory_Store_Management.Server.Models;

namespace FinalProject_TayViet_Accessory_Store_Management.Server.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : AccountControllerTemplate<Customer>
    {
        public CustomerController(AccountDatabaseServices<Customer> accountDatabaseServices) : base(accountDatabaseServices) => _databaseServices = accountDatabaseServices;
    }
}
