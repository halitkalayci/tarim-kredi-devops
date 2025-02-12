using Application.Features.Products.Commands.Create;
using Application.Features.Products.Commands.Delete;
using Application.Features.Products.Commands.Update;
using Application.Features.Products.Queries.GetById;
using Application.Features.Products.Queries.GetList;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedProductResponse>> Add([FromBody] CreateProductCommand command)
    {
        CreatedProductResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedProductResponse>> Update([FromBody] UpdateProductCommand command)
    {
        UpdatedProductResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedProductResponse>> Delete([FromRoute] Guid id)
    {
        DeleteProductCommand command = new() { Id = id };

        DeletedProductResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdProductResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdProductQuery query = new() { Id = id };

        GetByIdProductResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListProductListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListProductQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListProductListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}