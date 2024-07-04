using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
using FinalProject_TayViet_Accessory_Store_Management.Server.States;

namespace TayViet_Accessory_Store_Test.UnitTest.Model
{
    public class OrderHistoryTest
    {
        OrderHistory sampleObject = CONSTANT_TEST_VARIBLE.sampleOrderHistory;

        [Theory]
        [InlineData("Processing")]
        public void UpdateState_OrderHistory_Success(string state)
        {
            sampleObject.UpdateState(state);
            Assert.IsType<OrderPlacedState/*ProcessingState*/>(sampleObject.GetState());
        }

        [Fact]
        public void RequestRefund_OrderHistory_Fail()
        {
            Assert.Throws<Exception>(() => sampleObject.RequestRefund());
        }
        

        [Fact]
        public void HandleOrder_OrderHistory_Success()
        {
            sampleObject.HandleOrder();
            Assert.IsType<OrderPlacedState/*ProcessingState*/>(sampleObject.GetState());
        }



    }
}
