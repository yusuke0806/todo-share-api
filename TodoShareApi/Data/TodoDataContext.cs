using Microsoft.EntityFrameworkCore;
using TodoShareApi.Models;

namespace TodoShareApi.Data;

public class TodoDataContext : DbContext
{
    public TodoDataContext(DbContextOptions<TodoDataContext> options) : base(options)
    { }

    public DbSet<TodoTask>? TodoTasks { get; set; }
    
    public DbSet<Tag>? Tags { get; set; }
}