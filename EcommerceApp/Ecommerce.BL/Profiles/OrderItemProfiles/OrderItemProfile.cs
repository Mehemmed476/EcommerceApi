using AutoMapper;
using Ecommerce.BL.DTOs.OrderItemDTOs;
using Ecommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BL.Profiles.OrderItemOrderItemProfiles;

public class OrderItemProfile : Profile
{
    public OrderItemProfile()
    {
        CreateMap<OrderItemCreateDto, OrderItem>().ReverseMap();
        CreateMap<OrderItemUpdateDto, OrderItem>().ReverseMap();
        CreateMap<OrderItemReadDto, OrderItem>().ReverseMap();
    }
}
