using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BL.DTOs.OrderDTOs;

public class OrderUpdateDto
{
    public DateTime OrderDate { get; set; }
    public decimal TotalPrice { get; set; }
}
