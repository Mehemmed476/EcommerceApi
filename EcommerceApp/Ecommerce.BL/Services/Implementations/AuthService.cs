using AutoMapper;
using Ecommerce.BL.DTOs.AuthDTOs;
using Ecommerce.BL.ExternalServices.Abstractions;
using Ecommerce.BL.Services.Abstractions;
using Ecommerce.Core.Entities;
using Ecommerce.DAL.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ecommerce.BL.Services.Implementations;

public class AuthService : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly IMapper _mapper;
    private readonly IJwtTokenService _jwtTokenService;
    public AuthService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper, IJwtTokenService jwtTokenService)
    {
        _signInManager = signInManager;
        _mapper = mapper;
        _userManager = userManager;
        _jwtTokenService = jwtTokenService;
    }

    public async Task<bool> RegisterAsync(RegisterDto registerDto, IUrlHelper urlHelper)
    {
        var newUser = _mapper.Map<AppUser>(registerDto);

        var result = await _userManager.CreateAsync(newUser, registerDto.Password);
        if (!result.Succeeded) return false;
        return true;
    }

    public async Task<string> LoginAsync(LoginDto loginDto)
    {
        AppUser? searchedUser = await _userManager.FindByEmailAsync(loginDto.UserNameOrEmail)
                               ?? await _userManager.FindByNameAsync(loginDto.UserNameOrEmail);

        if (searchedUser == null)
            throw new EntityNotFoundException("User not found");

        bool result = await _userManager.CheckPasswordAsync(searchedUser, loginDto.Password);
        if (!result) { throw new Exception("Username or password is wrong"); }
        string token = _jwtTokenService.GenerateJwtToken(searchedUser);
        return token;
    }

    public async Task<bool> LogoutAsync()
    {
        await _signInManager.SignOutAsync();
        return true;
    }
}
