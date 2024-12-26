using AutoMapper;
using Ecommerce.BL.DTOs.OrderDTOs;
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

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public OrderService(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<OrderReadDto> AddAsync(OrderCreateDto orderCreateDto)
    {
        var order = _mapper.Map<Order>(orderCreateDto);
        order.CreatedAt = DateTime.UtcNow.AddHours(4);

        await _orderRepository.AddAsync(order);
        await _orderRepository.SaveChangesAsync();

        return _mapper.Map<OrderReadDto>(order);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var order = await _orderRepository.GetByIdAsync(id)
            ?? throw new EntityNotFoundException("Order not found");

        _orderRepository.Delete(order);
        await _orderRepository.SaveChangesAsync();

        return true;
    }

    public async Task<ICollection<OrderReadDto>> GetAllAsync()
    {
        var orders = await _orderRepository.GetAllAsync();
        return _mapper.Map<ICollection<OrderReadDto>>(orders);
    }

    public async Task<OrderReadDto> GetByIdAsync(int id)
    {
        var order = await _orderRepository.GetByIdAsync(id)
            ?? throw new EntityNotFoundException("Order not found");

        return _mapper.Map<OrderReadDto>(order);
    }

    public async Task<bool> RestoreAsync(int id)
    {
        var order = await _orderRepository.GetByIdAsync(id)
            ?? throw new EntityNotFoundException("Order not found");

        if (order.DeletedAt == null)
            throw new InvalidOperationException("Order is not soft deleted");

        order.DeletedAt = null;
        _orderRepository.Restore(order);
        await _orderRepository.SaveChangesAsync();

        return true;
    }

    public async Task<bool> SoftDeleteAsync(int id)
    {
        var order = await _orderRepository.GetByIdAsync(id)
            ?? throw new EntityNotFoundException("Order not found");

        if (order.DeletedAt != null)
            throw new InvalidOperationException("Order is already soft deleted");

        order.DeletedAt = DateTime.UtcNow.AddHours(4);
        _orderRepository.SoftDelete(order);
        await _orderRepository.SaveChangesAsync();

        return true;
    }

    public async Task<bool> UpdateAsync(int id, OrderUpdateDto orderUpdateDto)
    {
        var existingOrder = await _orderRepository.GetByIdAsync(id)
            ?? throw new EntityNotFoundException("Order not found");

        _mapper.Map(orderUpdateDto, existingOrder);
        existingOrder.UpdatedAt = DateTime.UtcNow.AddHours(4);

        await _orderRepository.UpdateAsync(existingOrder);
        await _orderRepository.SaveChangesAsync();

        return true;
    }
}

