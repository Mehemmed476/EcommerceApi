using Ecommerce.Core.Entities;
using Ecommerce.DAL.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.DAL.Repositories.Abstractions;

public interface IOrderItemRepository : IRepository<OrderItem>
{
}
