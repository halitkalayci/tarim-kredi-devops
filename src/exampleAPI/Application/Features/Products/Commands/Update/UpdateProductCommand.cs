using Application.Features.Products.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Commands.Update;

public class UpdateProductCommand : IRequest<UpdatedProductResponse>
{
    public Guid Id { get; set; }
    public required string Name { get; set; }

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, UpdatedProductResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly ProductBusinessRules _productBusinessRules;

        public UpdateProductCommandHandler(IMapper mapper, IProductRepository productRepository,
                                         ProductBusinessRules productBusinessRules)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _productBusinessRules = productBusinessRules;
        }

        public async Task<UpdatedProductResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            Product? product = await _productRepository.GetAsync(predicate: p => p.Id == request.Id, cancellationToken: cancellationToken);
            await _productBusinessRules.ProductShouldExistWhenSelected(product);
            product = _mapper.Map(request, product);

            await _productRepository.UpdateAsync(product!);

            UpdatedProductResponse response = _mapper.Map<UpdatedProductResponse>(product);
            return response;
        }
    }
}