using System;
using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Domain.Interfaces;
using ECommerceAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Infrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _context;
    public OrderRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<Order>> GetAllAsync()
    {
        return await _context.Orders.Include(o => o.OrderItems).ToListAsync();
    }
    public async Task<Order?> GetByIdAsync(int id)
    {
        return await _context.Orders.Include(o => o.OrderItems).FirstOrDefaultAsync(o => o.Id == id);
    }
    public async Task<Order> AddAsync(Order order)
    {
        _context.Orders.Add(order);
        await _context.SaveChangesAsync();
        return order;
    }
    public async Task UpdateStatusAsync(int id, string status)
    {
        var order = await _context.Orders.FindAsync(id);
        if (order == null)
            throw new InvalidOperationException($"Order {id} nicht gefunden.");

        order.Status = status;
        await _context.SaveChangesAsync();
    }


}
