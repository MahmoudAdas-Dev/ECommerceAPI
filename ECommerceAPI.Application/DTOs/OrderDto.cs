using System;

namespace ECommerceAPI.Application.DTOs;

public record OrderDto(int Id, string CustomerId, string CustomerEmail, decimal TotalAmount, string Status, DateTime CreatedAt, List<OrderItemDto> OrderItems);
public record OrderItemDto(int Id, int ProductId, string ProductName, decimal Price, int Quantity);
public record CreateOrderDto(string CustomerId, string CustomerEmail, List<CreateOrderItemDto> OrderItems);
public record CreateOrderItemDto(int ProductId, int Quantity);