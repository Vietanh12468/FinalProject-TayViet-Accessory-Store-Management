using FinalProject_TayViet_Accessory_Store_Management.Server.Interfaces;
using FinalProject_TayViet_Accessory_Store_Management.Server.Models;
using FinalProject_TayViet_Accessory_Store_Management.Utility.DatabaseUtility;

namespace TayViet_Accessory_Store_Test.UnitTest.DatabaseUltility
{
    public class AccountDatabaseServicesTest : DatabaseServicesTestTemplate<Account>
    {
        public AccountDatabaseServicesTest()
        {
            _databaseServices = DatabaseTestSettings.GetInstance.accountDatabaseServices;
        }

        [Fact]
        public void ReadAll_Account_Success()
        {
            ReadAll_Object_Success();
        }

        [Theory]
        [InlineData("668de4aeff3fac536eec3c36")]
        public void Read1_Account_Success(string id)
        {
            Read1_Object_Success(id);
        }

/*        [Fact]
        public void CreateAndDelete_OrderHistory_Success()
        {
            CreateAndDelete_Object_Success(sampleObject, "customerID", sampleObject.customerID);
        }*/

        [Theory]
        [InlineData("667dad66c15313612f61c613", "password", "123@123a")]
        [InlineData("667dad66c15313612f61c613", "password", "SamplePassword")]
        public void Update_Account_Success(string id, string attribute, string value)
        {
            Update_Object_Success(id, attribute, value);
        }

        [Fact]
        public void GetTotalRecord_Account_Success()
        {
            GetTotalRecord_Object_Success();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void ReadByPage_Account_Success(int page)
        {
            ReadByPage_Object_Success(page);
        }

    }
}
