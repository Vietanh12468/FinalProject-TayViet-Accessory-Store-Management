using FinalProject_TayViet_Accessory_Store_Management.Server.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class InMemoryDatabaseService<T> : IDatabaseServices<T>
{
    private readonly List<T> _data;

    public InMemoryDatabaseService()
    {
        _data = new List<T>();
    }

    public InMemoryDatabaseService(List<T> initialData)
    {
        _data = initialData;
    }

    public Task CreateAsync(T obj)
    {
        _data.Add(obj);
        return Task.CompletedTask;
    }

    public Task DeleteAsync<TT>(string attribute, TT value)
    {
        var item = _data.FirstOrDefault(d => (d as dynamic).GetType().GetProperty(attribute)?.GetValue(d, null).Equals(value) == true);
        if (item != null)
        {
            _data.Remove(item);
        }
        return Task.CompletedTask;
    }

    public Task<List<T>> ReadAsync()
    {
        return Task.FromResult(_data.ToList());
    }

    public Task<T> ReadAsync<TT>(string attribute, TT value)
    {
        var item = _data.FirstOrDefault(d => (d as dynamic).GetType().GetProperty(attribute)?.GetValue(d, null).Equals(value) == true);
        return Task.FromResult(item);
    }

    public Task<List<T>> ReadAsync(int skip = 0, int limit = 20)
    {
        return Task.FromResult(_data.Skip(skip).Take(limit).ToList());
    }

    public Task<List<T>> SearchAsync(string attribute, string value, int? skip = 1, int limit = 20)
    {
        var result = _data.Where(d => (d as dynamic).GetType().GetProperty(attribute)?.GetValue(d, null).ToString().Contains(value) == true).ToList();
        return Task.FromResult(result.Skip(skip ?? 0).Take(limit).ToList());
    }

    public Task<long> GetTotalRecordAsync()
    {
        return Task.FromResult((long)_data.Count);
    }

    public Task<long> GetTotalSearchRecordAsync(string attribute, string value)
    {
        var result = _data.Count(d => (d as dynamic).GetType().GetProperty(attribute)?.GetValue(d, null).ToString().Contains(value) == true);
        return Task.FromResult((long)result);
    }

    public Task UpdateAsync<TT>(T obj, string attribute, TT value)
    {
        var index = _data.FindIndex(d => (d as dynamic).GetType().GetProperty(attribute)?.GetValue(d, null).Equals(value) == true);
        if (index >= 0)
        {
            _data[index] = obj;
        }
        return Task.CompletedTask;
    }
    public Task<List<T>> SearchAsync(string attribute, string value, int skip = 1, int limit = 20) 
    {
        return null;
    }
}
