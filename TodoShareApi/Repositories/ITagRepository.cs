using TodoShareApi.Models;

namespace TodoShareApi.Repositories;

public interface ITagRepository
{
    public IEnumerable<Tag> GetAll();

    public Task<Tag> GetByIdAsync(int id);

    public Task InsertAsync(Tag tag);

    public Task UpdateAsync(Tag tag);

    public Task DeleteAsync(int id);
}