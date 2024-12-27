using Ecommerce.BL.DTOs.AuthDTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BL.Services.Abstractions;

public interface IAuthService
{
    Task<bool> RegisterAsync(RegisterDto registerDto, IUrlHelper baseUrl);
    Task<string> LoginAsync(LoginDto loginDto);
    Task<bool> LogoutAsync();
}
