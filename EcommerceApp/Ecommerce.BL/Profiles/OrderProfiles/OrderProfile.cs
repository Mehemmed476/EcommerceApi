using AutoMapper;
using Ecommerce.BL.DTOs.OrderDTOs;
using Ecommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BL.Profiles.OrderProfiles;

public class OrderProfile : Profile
{
    public OrderProfile()
    {
        CreateMap<OrderCreateDto, Order>().ReverseMap();
        CreateMap<OrderUpdateDto, Order>().ReverseMap();
        CreateMap<OrderReadDto, Order>().ReverseMap();
    }
}
