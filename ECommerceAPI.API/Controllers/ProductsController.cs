using System;
using ECommerceAPI.Application.Commands;
using ECommerceAPI.Application.Commands.Handlers;
using ECommerceAPI.Application.DTOs;
using ECommerceAPI.Application.Queries;
using ECommerceAPI.Application.Queries.Handlers;
using ECommerceAPI.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly GetAllProductsQueryHandler _getAllHandler;
    private readonly GetProductByIdQueryHandler _getByIdHandler;
    private readonly CreateProductCommandHandler _createHandler;
    private readonly DeleteProductCommandHandler _deleteHandler;

    public ProductsController(
        GetAllProductsQueryHandler getAllHandler,
        GetProductByIdQueryHandler getByIdHandler,
        CreateProductCommandHandler createHandler,
        DeleteProductCommandHandler deleteHandler)
    {
        _getAllHandler = getAllHandler;
        _getByIdHandler = getByIdHandler;
        _createHandler = createHandler;
        _deleteHandler = deleteHandler;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _getAllHandler.Handle(new GetAllProductsQuery());
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _getByIdHandler.Handle(new GetProductByIdQuery(id));
        if (product == null)
            return NotFound();
        return Ok(product);
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductDto dto)
    {
        var command = new CreateProductCommand(dto.Name, dto.Description, dto.Price, dto.Stock);
        var product = await _createHandler.Handle(command);
        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _deleteHandler.Handle(new DeleteProductCommand(id));
            return NoContent();
        }
        catch (InvalidOperationException ex)
        {
            return NotFound(ex.Message);
        }
    }
}