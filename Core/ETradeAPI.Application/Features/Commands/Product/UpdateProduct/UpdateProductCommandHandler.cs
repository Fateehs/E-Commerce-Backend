using ETradeAPI.Application.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using P = ETradeAPI.Domain.Entities;
namespace ETradeAPI.Application.Features.Commands.Product.UpdateProduct
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        readonly IProductReadRepository _productReadRepository;
        readonly IProductWriteRepository _productWriteRepository;
        readonly ILogger<UpdateProductCommandHandler> _logger;

        public UpdateProductCommandHandler(IProductReadRepository productReadRepository,
            IProductWriteRepository productWriteRepository,
            ILogger<UpdateProductCommandHandler> logger)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            _logger = logger;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            P.Product product = await _productReadRepository.GetByIdAsync(request.Id);

            product.Stock = request.Stock;
            product.Price = request.Price;
            product.Name = request.Name;

            await _productWriteRepository.SaveAsync();
            _logger.LogInformation("Product Updated");

            return new();
        }
    }
}
