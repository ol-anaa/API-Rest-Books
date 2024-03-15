using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System;
using UserApi.Data.Dtos;
using UserApi.Models;

namespace UserApi.Services;

public class UserService
{
    private IMapper _mapper;
    private UserManager<UserViewModel> _userManager;
    private SignInManager<UserViewModel> _signInManager;
    private TokenService _tokenService;

    public UserService(IMapper mapper, UserManager<UserViewModel> userManager, TokenService tokenService)
    {
        _mapper = mapper;
        _userManager = userManager;
        _tokenService = tokenService;
    }

    public async Task CreateUser(CreateUserDto createUser)
    {
        UserViewModel user = _mapper.Map<UserViewModel>(createUser);
        IdentityResult identityResult = await _userManager.CreateAsync(user, createUser.Password);

        if (!identityResult.Succeeded)
            throw new ApplicationException("Falha ao cadastrar usuário.");
    }

    public async Task<string> Login(LoginUserDto loginDto)
    {
        var result = await _signInManager.PasswordSignInAsync(loginDto.Username, loginDto.Password, false, false);
        
        if (!result.Succeeded)
            throw new ApplicationException("Usuário não autenticado.");

        var user = _signInManager.UserManager.Users.FirstOrDefault(user => user.NormalizedUserName == loginDto.Username.ToUpper());
        var token = _tokenService.GenerateToken(user);
        return token;
    }
}
