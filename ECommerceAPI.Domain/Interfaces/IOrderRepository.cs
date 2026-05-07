using System;
using ECommerceAPI.Domain.Entities;

namespace ECommerceAPI.Domain.Interfaces;

public interface IOrderRepository
{
    Task<List<Order>> GetAllAsync();
    Task<Order?> GetByIdAsync(int id);
    Task<Order> AddAsync(Order order);
    Task UpdateStatusAsync(int id, string status); // ← nur Status ändern
}
