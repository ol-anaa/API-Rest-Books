using Books.Data.Dtos;
using Books.Data.Dtos.Book;
using Books.Services;
using FluentResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Books.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private BookService _bookService;

    public BookController(BookService bookService)
    {
        _bookService = bookService;
    }

    /// <summary>
    /// Add a book to the database
    /// </summary>
    /// <param name="bookDto">Object with the fields necessary to create a book</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">If the insertion is successful</response>

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AddBook([FromBody] CreateBookDto bookDto)
    {
        ReadBookDto readBookDto = _bookService.AddBook(bookDto);
        return CreatedAtAction(nameof(GetBookById), new { id = readBookDto.Id }, readBookDto);
    }

    [HttpGet]
    public IActionResult GetBooks([FromQuery] int skip = 0, [FromQuery] int take = 25)
    {
        IEnumerable<ReadBookDto> readBookDto = _bookService.GetBooks(skip, take);
       
        if(readBookDto != null)
            return Ok(readBookDto);

        return NotFound();
    }

    [HttpGet("{id}")]
    public IActionResult GetBookById(int id)
    {
        ReadBookDto? readBookDto = _bookService.GetBookById(id);

       if (readBookDto != null) 
            return Ok(readBookDto);

       return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateBook(int id, [FromBody] UpdateBookDto bookDto) 
    {
         Result result = _bookService.UpdateBook(id, bookDto);

        if (result.IsSuccess)
            return NoContent();

        return NotFound();
    }

    [HttpPatch("{id}")]
    public IActionResult UpdatePartialBook(int id, [FromBody] JsonPatchDocument<UpdateBookDto> patch)
    {
        Result result = _bookService.UpdatePartialBook(id, patch);

        if (result.IsSuccess)
            return NoContent();

        return NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBook(int id) 
    {
        Result result = _bookService.DeleteBook(id);

        if(result.IsSuccess)
            return NoContent();

        return NotFound(); 
    }
}
