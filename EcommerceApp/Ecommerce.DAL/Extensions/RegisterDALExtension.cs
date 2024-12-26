using Ecommerce.DAL.Contexts;
using Ecommerce.DAL.Helpers;
using Ecommerce.DAL.Repositories.Abstractions;
using Ecommerce.DAL.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL.Extensions;

public static class RegisterDALExtension
{
    public static void AddDALServices(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(
            opt =>
            {
                opt.UseSqlServer(ConnectionStr.GetConnectionString());
            }
        );

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IOrderItemRepository, OrderItemRepository>();
    }
}
