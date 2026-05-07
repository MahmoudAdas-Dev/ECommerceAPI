using ECommerceAPI.Application.DTOs;
using ECommerceAPI.Domain.Interfaces;
using Mapster;

namespace ECommerceAPI.Application.Queries.Handlers;

public class GetAllProductsQueryHandler
{
    private readonly IProductRepository _repository;

    public GetAllProductsQueryHandler(IProductRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ProductDto>> Handle(GetAllProductsQuery query)
    {
        var products = await _repository.GetAllAsync();
        return products.Adapt<List<ProductDto>>();
    }
}