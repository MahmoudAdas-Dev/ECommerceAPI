using ECommerceAPI.Application.DTOs;
using ECommerceAPI.Domain.Interfaces;
using Mapster;

namespace ECommerceAPI.Application.Queries.Handlers;

public class GetProductByIdQueryHandler
{
    private readonly IProductRepository _productService;

    public GetProductByIdQueryHandler(IProductRepository productService)
    {
        _productService = productService;
    }
    public async Task<ProductDto?> Handle(GetProductByIdQuery query)
    {
        var product = await _productService.GetByIdAsync(query.Id);
        if (product == null)
        {
            return null;
        }

        return product.Adapt<ProductDto>();
    }
}
