using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
using FinalProject_TayViet_Accessory_Store_Management.Utility.DatabaseUtility;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject_TayViet_Accessory_Store_Management.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderHistoryController : ControllerTemplate<OrderHistory>
    {
        public OrderHistoryController(OrderHistoryDatabaseService orderHistoryDatabaseService) : base(databaseServices: orderHistoryDatabaseService) { }
    }
}
