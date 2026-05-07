using System;

namespace ECommerceAPI.Domain.Entities;

public class Order
{
    /*
    Id (int)
    CustomerId (string)
    CustomerEmail (string)
    TotalAmount (decimal)
    Status (string) → "Pending", "Confirmed", "Shipped", "Delivered"
    CreatedAt (DateTime)
    OrderItems (List<OrderItem>)
    */
    public int Id { get; set; }
    public string CustomerId { get; set; } = string.Empty;
    public string CustomerEmail { get; set; } = string.Empty;
    public decimal TotalAmount { get; set; }
    public string Status { get; set; } = "Pending";
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public List<OrderItem> OrderItems { get; set; } = [];
}
