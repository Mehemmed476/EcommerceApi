using AutoMapper;
using Ecommerce.BL.DTOs.AuthDTOs;
using Ecommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BL.Profiles.AuthProfiles;

public class AuthProfile : Profile
{
    public AuthProfile()
    {
        CreateMap<LoginDto, AppUser>().ReverseMap()
            .ForMember(dest => dest.Password, opt => opt.Ignore());

        CreateMap<RegisterDto, AppUser>().ReverseMap()
            .ForMember(dest => dest.Password, opt => opt.Ignore())
            .ForMember(dest => dest.CheckPassword, opt => opt.Ignore());
    }
}
