using ETradeAPI.Application.Features.Commands.ProductImage.UploadProductImage;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace ETradeAPI.Application.Features.Commands.ProductImageFile.UploadProductImage
{
    public class UploadProductImageCommandRequest: IRequest<UploadProductImageCommandResponse>
    {
        public string Id { get; set; }
        public IFormFileCollection? FormFileCollection { get; set; }
    }
}
