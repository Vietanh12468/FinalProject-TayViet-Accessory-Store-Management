using FinalProject_TayViet_Accessory_Store_Management.Models.ExceptionModels;
using FinalProject_TayViet_Accessory_Store_Management.Server.Interfaces;

namespace TayViet_Accessory_Store_Test.UnitTest.DatabaseUltility
{
    public class DatabaseServicesTestTemplate<T>
    {
        protected T _sampleObject;
        protected IDatabaseServices<T> _databaseServices;

        public async void ReadAll_Object_Success()
        {
            List<T> result = await _databaseServices.ReadAsync();
            Assert.NotNull(result);
        }

        public async void Read1_Object_Success(string id)
        {
            T result = await _databaseServices.ReadAsync("id", id);
            Assert.NotNull(result);
        }

        public async void CreateAndDelete_Object_Success(T sampleObject,string attribute, string value)
        {
            // Test Create
            await _databaseServices.CreateAsync(sampleObject);
            T result = await _databaseServices.ReadAsync(attribute, value);
            Assert.NotNull(result);

            // Test Delete
            await Assert.ThrowsAsync<NotFoundException>(async () =>
            {
                await _databaseServices.DeleteAsync("id", result.GetType().GetProperty("id")?.GetValue(result)?.ToString());
                await _databaseServices.ReadAsync(attribute, value);
            });
        }

        public async void Update_Object_Success(string id, string attribute, string value)
        {
            T obj = await _databaseServices.ReadAsync("id", id);

            obj.GetType().GetProperty(attribute)?.SetValue(obj, value);
            await _databaseServices.UpdateAsync(obj, "id", id);

            T result = await _databaseServices.ReadAsync(attribute, value);
            Assert.Equal(value, result.GetType().GetProperty(attribute)?.GetValue(result)?.ToString());
        }

        public async void GetTotalRecord_Object_Success()
        {
            long result = await _databaseServices.GetTotalRecordAsync();

            Assert.True(result > 0);
        }

        public async void ReadByPage_Object_Success(int page)
        {
            int skip = (page - 1) * 20;
            List<T> result = await _databaseServices.ReadAsync(skip);

            Assert.True(result.Count > 0);
        }
    }
}
