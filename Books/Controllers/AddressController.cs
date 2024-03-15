using AutoMapper;
using Books.Data;
using Books.Data.Dtos.Address;
using Books.Data.Dtos.Book;
using Books.Models;
using Books.Services;
using FluentResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Books.Controllers;

[ApiController]
[Route("[controller]")]
public class AddressController : ControllerBase
{
    private readonly AddressService _addressService;

    public AddressController(AddressService addressService)
    {
        _addressService = addressService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AddAdress([FromBody] CreateAddressDto addressDto)
    {
        ReadAddressDto? readAddressDto = _addressService.AddAdress(addressDto);
        return CreatedAtAction(nameof(GetAddressById), new { id = readAddressDto.Id }, readAddressDto);
    }

    [HttpGet]
    public IActionResult GetAddresses([FromQuery] int skip = 0, [FromQuery] int take = 25)
    {
        IEnumerable<ReadAddressDto> readAddressDto = _addressService.GetAddresses(skip, take);

        if(readAddressDto != null)
            return Ok(readAddressDto);

        return NotFound();

    }

    [HttpGet("{id}")]
    public IActionResult GetAddressById(int id)
    {
        ReadAddressDto? readAddressDto = _addressService.GetAddressById(id);
       
        if(readAddressDto != null)
            return Ok(readAddressDto);

        return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateAddress(int id, [FromBody] UpdateAddressDto addressDto) 
    { 
       Result result = _addressService.UpdateAddress(id, addressDto);

        if(result.IsSuccess)
            return NoContent();

        return NotFound();
    }

    [HttpPatch("{id}")]
    public IActionResult UpdatePartialAddress(int id, [FromBody] JsonPatchDocument<UpdateAddressDto> patch)
    {
        Result result = _addressService.UpdatePartialAddress(id, patch);
       
        if(result.IsSuccess)
           return NoContent();

        return NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAddress(int id) 
    {
        Result result = _addressService.DeleteAddress(id);
        
        if (result.IsSuccess)
            return NoContent();
        
        return NotFound(); 
    }
}
