using System;

namespace ECommerceAPI.Domain.Entities;

public class OrderItem
{
    /*
    Id (int)
    OrderId (int)
    ProductId (int)
    ProductName (string)
    Price (decimal)
    Quantity (int)
    */
    public int Id { get; set; }
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}
