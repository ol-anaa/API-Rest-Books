using AutoMapper;
using Books.Data;
using Books.Data.Dtos.AutographSession;
using Books.Data.Dtos.Book;
using Books.Models;
using Books.Services;
using Microsoft.AspNetCore.Mvc;

namespace Books.Controllers;

[ApiController]
[Route("[controller]")]
public class AutographSessionController : ControllerBase
{
    private AutographSessionService _autographSessionService;

    public AutographSessionController(AutographSessionService autographSessionService)
    {
        _autographSessionService = autographSessionService;
    }

    [HttpPost]
    public IActionResult AddAutographSession(CreateAutographSessionDto createAutographSessionDto)
    {
        ReadAutographSessionDto? readAutographSessionDto = _autographSessionService.AddAutographSession(createAutographSessionDto);
        return CreatedAtAction(nameof(GetAutographSessionById), new { id = readAutographSessionDto.Id }, readAutographSessionDto);
    }

    [HttpGet("{id}")]
    public IActionResult GetAutographSessionById(int id)
    {
        ReadAutographSessionDto? readAutographSessionDto = _autographSessionService.GetAutographSessionById(id);

        if(readAutographSessionDto != null)
            return Ok(readAutographSessionDto);

        return NotFound();
    }

}
