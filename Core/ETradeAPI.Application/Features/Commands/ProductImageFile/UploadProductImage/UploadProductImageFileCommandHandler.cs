using ETradeAPI.Application.Features.Commands.ProductImage.UploadProductImage;
using MediatR;

namespace ETradeAPI.Application.Features.Commands.ProductImageFile.UploadProductImage
{
    public class UploadProductImageFileCommandHandler : IRequestHandler<UploadProductImageFileCommandRequest, UploadProductImageFileCommandResponse>
    {
        public async Task<UploadProductImageFileCommandResponse> Handle(UploadProductImageFileCommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
