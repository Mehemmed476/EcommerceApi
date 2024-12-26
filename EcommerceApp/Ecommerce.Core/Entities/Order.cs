using Ecommerce.Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Core.Entities;

public class Order : AuditableEntity
{
    public DateTime OrderDate { get; set; }
    public ICollection<OrderItem>? OrderItems { get; set; }
    public decimal TotalPrice { get; set; }
}
