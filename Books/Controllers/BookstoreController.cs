using Books.Data.Dtos.Bookstore;
using Books.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace Books.Controllers;

[ApiController]
[Route("[controller]")]
public class BookstoreController : ControllerBase
{
    private BookstoreService _bookstoreService;

    public BookstoreController(BookstoreService bookstoreService)
    {
        _bookstoreService = bookstoreService;
    }

    /// <summary>
    /// Add a book to the database
    /// </summary>
    /// <param name="bookstoreDto">Object with the fields necessary to create a bookstore</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">If the insertion is successful</response>

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AddBookstore([FromBody] CreateBookstoreDto bookstoreDto)
    {
        ReadBookstoreDto readBookstoreDto = _bookstoreService.AddBookstore(bookstoreDto); 
        return CreatedAtAction(nameof(GetBookstoreById), new { id = readBookstoreDto.Id }, readBookstoreDto);
    }

    [HttpGet]
    public IActionResult GetBookstores([FromQuery] int skip = 0, [FromQuery] int take = 25)
    {
        IEnumerable<ReadBookstoreDto> readBookstoreDto = _bookstoreService.GetBookstores(skip, take);
       
        if (readBookstoreDto != null) 
            return Ok(readBookstoreDto);

        return NotFound();
    }

    [HttpGet("{id}")]
    public IActionResult GetBookstoreById(int id)
    {
        ReadBookstoreDto? readBookstoreDto = _bookstoreService.GetBookstoreById(id); 

        if (readBookstoreDto != null)
            return Ok(readBookstoreDto);

        return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateBookstore(int id, [FromBody] UpdateBooksoteDto bookstoreDto) 
    { 
        Result result = _bookstoreService.UpdateBookstore(id, bookstoreDto); 

        if(result.IsSuccess)
            return NoContent();

        return NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBookstore(int id) 
    {
        Result result  = _bookstoreService.DeleteBookstore(id); 

        if(result.IsSuccess)
            return NoContent();
        
        return NotFound(); 
    }
}
