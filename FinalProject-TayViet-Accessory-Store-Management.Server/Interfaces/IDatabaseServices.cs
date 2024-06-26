using MongoDB.Driver;

namespace FinalProject_TayViet_Accessory_Store_Management.Server.Interfaces
{
    public interface IDatabaseServices<T>
    {
        Task<List<T>> ReadAsync();     
        Task<T> ReadAsync<TT>(string attribute, TT value);
        Task CreateAsync(T obj);
        Task UpdateAsync<TT>(T obj, string attribute, TT value);
        Task DeleteAsync<TT>(string attribute, TT value);
        Task<long> GetTotalRecordAsync();
        Task<List<T>> ReadAsync(int skip = 0, int limit = 20);
    }
}
