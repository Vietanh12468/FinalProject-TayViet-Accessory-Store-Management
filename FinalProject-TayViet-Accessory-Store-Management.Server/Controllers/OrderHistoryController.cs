using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
using FinalProject_TayViet_Accessory_Store_Management.Utility.DatabaseUtility;
using FinalProject_TayViet_Accessory_Store_Management.Server.Utility;
using Microsoft.AspNetCore.Mvc;
using FinalProject_TayViet_Accessory_Store_Management.Models.ExceptionModels;

namespace FinalProject_TayViet_Accessory_Store_Management.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderHistoryController : ControllerTemplate<OrderHistory>
    {
        public OrderHistoryController(OrderHistoryDatabaseService orderHistoryDatabaseService) : base(databaseServices: orderHistoryDatabaseService) { }

        [HttpPut("{id}/newState={newState}")]
        public async Task<IActionResult> UpdateOrderHistory(string id, string newState)
        {
            if (!OrderValidateState.CheckState(newState))
            {
                return BadRequest("Invalid state");
            }

            OrderHistory orderHistory;
            try
            {
                orderHistory = await _databaseServices.ReadAsync("id", id);
            }
            catch (FormatException) { return BadRequest("Invalid Id"); }
            catch (NotFoundException) { return NotFound("Item Not Found Or Deleted"); }
            catch (Exception) { throw new UnknownException(); }

            orderHistory.UpdateState(newState);

            return Ok();
        }
    }
}
