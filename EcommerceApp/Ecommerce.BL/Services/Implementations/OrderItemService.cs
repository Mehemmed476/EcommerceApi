using AutoMapper;
using Ecommerce.BL.DTOs.OrderItemDTOs;
using Ecommerce.BL.Services.Abstractions;
using Ecommerce.Core.Entities;
using Ecommerce.DAL.Exceptions;
using Ecommerce.DAL.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BL.Services.Implementations;

public class OrderItemService : IOrderItemService
{
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly IMapper _mapper;

    public OrderItemService(IOrderItemRepository orderItemRepository, IMapper mapper)
    {
        _orderItemRepository = orderItemRepository;
        _mapper = mapper;
    }

    public async Task<OrderItemReadDto> AddAsync(OrderItemCreateDto orderItemCreateDto)
    {
        var orderItem = _mapper.Map<OrderItem>(orderItemCreateDto);
        orderItem.CreatedAt = DateTime.UtcNow.AddHours(4);

        await _orderItemRepository.AddAsync(orderItem);
        await _orderItemRepository.SaveChangesAsync();

        return _mapper.Map<OrderItemReadDto>(orderItem);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var orderItem = await _orderItemRepository.GetByIdAsync(id)
            ?? throw new EntityNotFoundException("OrderItem not found");

        _orderItemRepository.Delete(orderItem);
        await _orderItemRepository.SaveChangesAsync();

        return true;
    }

    public async Task<ICollection<OrderItemReadDto>> GetAllAsync()
    {
        var orderItems = await _orderItemRepository.GetAllAsync();
        return _mapper.Map<ICollection<OrderItemReadDto>>(orderItems);
    }

    public async Task<OrderItemReadDto> GetByIdAsync(int id)
    {
        var orderItem = await _orderItemRepository.GetByIdAsync(id)
            ?? throw new EntityNotFoundException("OrderItem not found");

        return _mapper.Map<OrderItemReadDto>(orderItem);
    }

    public async Task<bool> RestoreAsync(int id)
    {
        var orderItem = await _orderItemRepository.GetByIdAsync(id)
            ?? throw new EntityNotFoundException("OrderItem not found");

        if (orderItem.DeletedAt == null)
            throw new InvalidOperationException("OrderItem is not soft deleted");

        orderItem.DeletedAt = null;
        _orderItemRepository.Restore(orderItem);
        await _orderItemRepository.SaveChangesAsync();

        return true;
    }

    public async Task<bool> SoftDeleteAsync(int id)
    {
        var orderItem = await _orderItemRepository.GetByIdAsync(id)
            ?? throw new EntityNotFoundException("OrderItem not found");

        if (orderItem.DeletedAt != null)
            throw new InvalidOperationException("OrderItem is already soft deleted");

        orderItem.DeletedAt = DateTime.UtcNow.AddHours(4);
        _orderItemRepository.SoftDelete(orderItem);
        await _orderItemRepository.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdateAsync(int id, OrderItemUpdateDto orderItemUpdateDto)
    {
        var existingOrderItem = await _orderItemRepository.GetByIdAsync(id)
            ?? throw new EntityNotFoundException("OrderItem not found");

        _mapper.Map(orderItemUpdateDto, existingOrderItem);
        existingOrderItem.UpdatedAt = DateTime.UtcNow.AddHours(4);

        await _orderItemRepository.UpdateAsync(existingOrderItem);
        await _orderItemRepository.SaveChangesAsync();

        return true;
    }
}

