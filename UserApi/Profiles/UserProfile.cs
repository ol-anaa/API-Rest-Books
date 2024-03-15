﻿using AutoMapper;
using UserApi.Data.Dtos;
using UserApi.Models;

namespace UserApi.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<CreateUserDto, UserViewModel>();
    }
}
