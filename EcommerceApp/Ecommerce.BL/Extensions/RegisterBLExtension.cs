using Ecommerce.BL.ExternalServices.Abstractions;
using Ecommerce.BL.ExternalServices.Implementations;
using Ecommerce.BL.Services.Abstractions;
using Ecommerce.BL.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BL.Extensions;

public static class RegisterBLExtension
{
    public static void AddBLServices(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IOrderItemService, OrderItemService>();
        services.AddScoped<IJwtTokenService, JwtTokenService>();
    }
}
