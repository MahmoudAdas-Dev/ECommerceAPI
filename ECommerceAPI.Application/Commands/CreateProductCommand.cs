using System;

namespace ECommerceAPI.Application.Commands;

public record CreateProductCommand(string Name, string Description, decimal Price, int Stock);

