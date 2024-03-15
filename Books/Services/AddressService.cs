using AutoMapper;
using Books.Data;
using Books.Data.Dtos.Address;
using Books.Models;
using FluentResults;
using Microsoft.AspNetCore.JsonPatch;

namespace Books.Services;

public class AddressService
{
    private BookContext _context;
    private IMapper _mapper;

    public AddressService(BookContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public ReadAddressDto? AddAdress(CreateAddressDto addressDto)
    {
        AddressViewModel address = _mapper.Map<AddressViewModel>(addressDto);
        _context.Addresses.Add(address);
        _context.SaveChanges();

        return _mapper.Map<ReadAddressDto>(address);
    }

    public IEnumerable<ReadAddressDto> GetAddresses(int skip, int take)
    {
        return _mapper.Map<IEnumerable<ReadAddressDto>>(_context.Addresses.Skip(skip).Take(take));
    }

    public ReadAddressDto? GetAddressById(int id)
    {
        var address = _context.Addresses.FirstOrDefault(address => address.Id == id);

        if (address != null)
            return _mapper.Map<ReadAddressDto>(address);

        return null;
    }

    public Result UpdateAddress(int id, UpdateAddressDto addressDto)
    {
        var address = _context.Addresses.FirstOrDefault(address => address.Id == id);

        if (address != null)
        {
            _mapper.Map(addressDto, address);
            _context.SaveChanges();
            return Result.Ok();
        }
        return Result.Fail("Algo deu errado ao atualizar um address");
    }

    public Result UpdatePartialAddress(int id, JsonPatchDocument<UpdateAddressDto> patch)
    {
        var address = _context.Addresses.FirstOrDefault(address => address.Id == id);

        if (address != null)
        {
            var addressUpdate = _mapper.Map<UpdateAddressDto>(address);

            patch.ApplyTo(addressUpdate);

            try
            {
                _mapper.Map(addressUpdate, address);
                _context.SaveChanges();
                return Result.Ok();
            }
            catch(Exception ex)
            {
                Result.Fail("Houve um problema! " + ex.ToString());
            }
        }
        return Result.Fail("Erro ao atualizar um address");
    }

    public Result DeleteAddress(int id)
    {
        var address = _context.Addresses.FirstOrDefault(address => address.Id == id);

        if (address != null)
        {
            _context.Addresses.Remove(address);
            _context.SaveChanges();
            return Result.Ok();
        }
        return Result.Fail("Erro ao deletar um address");
    }
}

