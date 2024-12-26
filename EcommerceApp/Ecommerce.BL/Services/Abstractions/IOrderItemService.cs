using Ecommerce.BL.DTOs.OrderItemDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BL.Services.Abstractions;

public interface IOrderItemService
{
    Task<ICollection<OrderItemReadDto>> GetAllAsync();
    Task<OrderItemReadDto> GetByIdAsync(int id);
    Task<OrderItemReadDto> AddAsync(OrderItemCreateDto orderItemCreateDto);
    Task<bool> UpdateAsync(int id, OrderItemUpdateDto orderItemUpdateDto);
    Task<bool> SoftDeleteAsync(int id);
    Task<bool> RestoreAsync(int id);
    Task<bool> DeleteAsync(int id);
}
