using FinalProject_TayViet_Accessory_Store_Management.Server.Models;

namespace TayViet_Accessory_Store_Test.UnitTest.Model
{
    public class AdminTest
    {
        Admin sampleObject = CONSTANT_TEST_VARIBLE.sampleAdmin;

        public static IEnumerable<object[]> GetStateVaribleTest()
        {
            yield return new object[] { "Active", typeof(ActiveState) };
            yield return new object[] { "Inactive", typeof(InactiveState) };
            yield return new object[] { "Locked" ,typeof(LockState) };
            yield return new object[] { "Unlocked",typeof(UnlockState) };
        }

        [Theory]
        [MemberData(nameof(GetStateVaribleTest))]
        public void GetAndSetState_Account_Success(string stateName, Type stateTypeCheck)
        {
            sampleObject.SetState(stateName);
            Assert.IsType(stateTypeCheck, sampleObject.GetState());
        }
    }
}
