using Application.Features.Products.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Commands.Create;

public class CreateProductCommand : IRequest<CreatedProductResponse>
{
    public required string Name { get; set; }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreatedProductResponse>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly ProductBusinessRules _productBusinessRules;

        public CreateProductCommandHandler(IMapper mapper, IProductRepository productRepository,
                                         ProductBusinessRules productBusinessRules)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _productBusinessRules = productBusinessRules;
        }

        public async Task<CreatedProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Product product = _mapper.Map<Product>(request);

            await _productRepository.AddAsync(product);

            CreatedProductResponse response = _mapper.Map<CreatedProductResponse>(product);
            return response;
        }
    }
}