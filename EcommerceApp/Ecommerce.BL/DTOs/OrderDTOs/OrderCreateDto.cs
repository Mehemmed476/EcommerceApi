using Ecommerce.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BL.DTOs.OrderDTOs;

public class OrderCreateDto
{
    public DateTime OrderDate { get; set; }
    public decimal TotalPrice { get; set; }
}
