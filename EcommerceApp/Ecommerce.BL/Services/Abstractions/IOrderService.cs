using Ecommerce.BL.DTOs.OrderDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BL.Services.Abstractions;

public interface IOrderService
{
    Task<ICollection<OrderReadDto>> GetAllAsync();
    Task<OrderReadDto> GetByIdAsync(int id);
    Task<OrderReadDto> AddAsync(OrderCreateDto orderCreateDto);
    Task<bool> UpdateAsync(int id, OrderUpdateDto orderUpdateDto);
    Task<bool> SoftDeleteAsync(int id);
    Task<bool> RestoreAsync(int id);
    Task<bool> DeleteAsync(int id);
}
