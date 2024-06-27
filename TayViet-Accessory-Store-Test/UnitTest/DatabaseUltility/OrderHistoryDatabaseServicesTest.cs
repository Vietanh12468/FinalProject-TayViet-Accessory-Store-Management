using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
using FinalProject_TayViet_Accessory_Store_Management.Utility.DatabaseUtility;

namespace TayViet_Accessory_Store_Test.UnitTest.DatabaseUltility
{
    public class OrderHistoryDatabaseServicesTest : DatabaseServicesTestTemplate<OrderHistory>
    {
        public OrderHistoryDatabaseServicesTest()
        {
            _sampleObject = CONSTANT_TEST_VARIBLE.sampleOrderHistory;
            _databaseServices = DatabaseTestSettings.GetInstance.orderHistoryDatabaseServices;
        }

        [Fact]
        public void ReadAll_OrderHistory_Success()
        {
            ReadAll_Object_Success();
        }

        [Theory]
        [InlineData("6674986baa7ae506cca99059")]
        public void Read1_OrderHistory_Success(string id)
        {
            Read1_Object_Success(id);
        }

        [Fact]
        public void CreateAndDelete_OrderHistory_Success()
        {
            CreateAndDelete_Object_Success(_sampleObject, "customerID", _sampleObject.customerID);
        }

        [Theory]
        [InlineData("6674986baa7ae506cca99059", "shipLocation" , "New Location")]
        [InlineData("6674986baa7ae506cca99059", "shipLocation" , "Old Location")]
        public void Update_OrderHistory_Success(string id, string attribute, string value)
        {
            Update_Object_Success(id, attribute, value);
        }

        [Fact]
        public void GetTotalRecord_OrderHistory_Success()
        {
            GetTotalRecord_Object_Success();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void ReadByPage_OrderHistory_Success(int page)
        {
            ReadByPage_Object_Success(page);
        }
    }
}
