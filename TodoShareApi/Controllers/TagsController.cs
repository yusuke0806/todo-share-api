using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using TodoShareApi.Models;
using TodoShareApi.Repositories;

namespace TodoShareApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TagsController : Controller
{
    private readonly ITagRepository _tagRepository;
    
    public TagsController(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }

    [HttpGet]
    public ActionResult<List<Tag>> Get()
    {
        return Ok(_tagRepository.GetAll());
    }
    
    [HttpGet]
    public ActionResult<Tag> GetById(int id)
    {
        return Ok(_tagRepository.GetByIdAsync(id));
    }

    [HttpPost]
    public IActionResult CreateAsync(Tag tag)
    {
        try
        {
            return Ok(_tagRepository.InsertAsync(tag));
        }
        catch (DbException e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPatch]
    public IActionResult UpdateAsync(Tag tag)
    {
        try
        {
            return Ok(_tagRepository.UpdateAsync(tag));
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
            return Ok(_tagRepository.DeleteAsync(id));
        }
        catch (DbException e)
        {
            return BadRequest();
        }
    }
}