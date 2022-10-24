using Microsoft.EntityFrameworkCore;
using TodoShareApi.Data;
using TodoShareApi.Models;

namespace TodoShareApi.Repositories;

public class TagRepository : ITagRepository
{
    private readonly TodoDataContext _context;
    
    public TagRepository(TodoDataContext context)
    {
        _context = context;
    }

    public IEnumerable<Tag> GetAll()
    {
        return _context.Tags.ToList();
    }

    public async Task<Tag> GetByIdAsync(int id)
    {
        return await _context.Tags.FindAsync(id);
    }

    public async Task InsertAsync(Tag tag)
    {
        await _context.Tags.AddAsync(tag);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Tag tag)
    {
        _context.Entry(tag).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var tag = await _context.Tags.FindAsync(id);
        _context.Tags.Remove(tag);

        await _context.SaveChangesAsync();
    }
}