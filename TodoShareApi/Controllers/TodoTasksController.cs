using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using TodoShareApi.Models;
using TodoShareApi.Repositories;

namespace TodoShareApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoTasksController : Controller
{
    private readonly ITodoTaskRepository _todoTaskRepository;
    
    public TodoTasksController(ITodoTaskRepository todoTaskRepository)
    {
        _todoTaskRepository = todoTaskRepository;
    }
    
    [HttpGet]
    public async Task<IEnumerable<TodoTask>> Get()
    {
        return await _todoTaskRepository.GetAsync();
    }
    
    [HttpPost]
    public IActionResult CreateAsync(TodoTask task)
    {
        try
        {
            return Ok(_todoTaskRepository.InsertAsync(task));
        }
        catch (DbException e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPatch]
    public IActionResult UpdateAsync(TodoTask task)
    {
        try
        {
            return Ok(_todoTaskRepository.UpdateAsync(task));
        }
        catch (DbException e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpDelete]
    public IActionResult DeleteAsync(int id)
    {
        try
        {
            return Ok(_todoTaskRepository.DeleteByIdAsync(id));
        }
        catch (DbException e)
        {
            return BadRequest();
        }
    }
}