using TodoShareApi.Models;

namespace TodoShareApi.Repositories;

public interface ITodoTaskRepository
{
    public Task<IEnumerable<TodoTask>> GetAsync();

    public Task<TodoTask> GetByIdAsync(int id);
    
    public Task InsertAsync(TodoTask task);

    public Task UpdateAsync(TodoTask task);

    public Task DeleteByIdAsync(int id);
}