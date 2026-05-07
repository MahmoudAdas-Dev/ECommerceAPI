using System;
using ECommerceAPI.Application.DTOs;
using ECommerceAPI.Domain.Interfaces;
using Mapster;

namespace ECommerceAPI.Application.Commands.Handlers;

public class DeleteProductCommandHandler
{
    private readonly IProductRepository _productRepository;
    public DeleteProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task Handle(DeleteProductCommand command)
    {
        var existing = await _productRepository.GetByIdAsync(command.Id);
        if (existing == null)
        {
            throw new InvalidOperationException("Product not found");
        }

        await _productRepository.DeleteAsync(existing.Id);
    }
}
