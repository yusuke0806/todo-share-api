using Microsoft.EntityFrameworkCore;
using TodoShareApi.Data;
using TodoShareApi.Models;

namespace TodoShareApi.Repositories;

public class TodoTaskRepository : ITodoTaskRepository
{
    private readonly TodoDataContext _context;
    
    public TodoTaskRepository(TodoDataContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<TodoTask>> GetAsync()
    {
        return await _context.TodoTasks.ToListAsync();
    }

    public async Task<TodoTask> GetByIdAsync(int id)
    {
        return await _context.TodoTasks.FindAsync(id);
    }

    public async Task InsertAsync(TodoTask task)
    {
        await _context.TodoTasks.AddAsync(task);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(TodoTask task)
    {
        _context.Entry(task).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(int id)
    {
        var targetTask = await GetByIdAsync(id);
        targetTask.DeletedAt = DateTimeOffset.Now;

        await UpdateAsync(targetTask);
    }
}