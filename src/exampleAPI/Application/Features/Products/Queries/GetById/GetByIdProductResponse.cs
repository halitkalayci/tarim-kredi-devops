using NArchitecture.Core.Application.Responses;

namespace Application.Features.Products.Queries.GetById;

public class GetByIdProductResponse : IResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}