using Books.Data.Dtos.Manager;
using Books.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace Books.Controllers;

[ApiController]
[Route("[controller]")]
public class ManagerController : ControllerBase
{
    private ManagerService _managerService;

    public ManagerController(ManagerService managerService)
    {
        _managerService = managerService;
    }

    [HttpPost]
    public IActionResult AddManager(CreateManagerDto createManagerDto)
    {
        ReadManagerDto? readManagerDto = _managerService.AddManager(createManagerDto);

        return CreatedAtAction(nameof(GetManagerById), new { id = readManagerDto.Id }, readManagerDto);
    }

    [HttpGet("{id}")]
    public IActionResult GetManagerById(int id)
    {
        ReadManagerDto? readManagerDto = _managerService.GetManagerById(id);

        if (readManagerDto != null)
            return Ok(readManagerDto);

        return NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteManager(int id)
    {
        Result result = _managerService.DeleteManager(id);
       
        if(result.IsSuccess)
            return NoContent();

        return NotFound();
    }
}
