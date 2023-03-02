using MediatR;

namespace ETradeAPI.Application.Features.Commands.Product.DeleteProduct
{
    public class RemoveProductCommandRequest : IRequest<RemoveProductCommandResponse>
    {
        public string Id { get; set; }
    }
}
