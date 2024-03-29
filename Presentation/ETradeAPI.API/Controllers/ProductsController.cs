﻿using ETradeAPI.Application.Abstractions.Services;
using ETradeAPI.Application.Consts;
using ETradeAPI.Application.CustomAttributes;
using ETradeAPI.Application.Enums;
using ETradeAPI.Application.Features.Commands.Product.CreateProduct;
using ETradeAPI.Application.Features.Commands.Product.DeleteProduct;
using ETradeAPI.Application.Features.Commands.Product.UpdateProduct;
using ETradeAPI.Application.Features.Commands.ProductImage.UploadProductImage;
using ETradeAPI.Application.Features.Commands.ProductImageFile.ChangeShowcaseImage;
using ETradeAPI.Application.Features.Commands.ProductImageFile.RemoveProductImage;
using ETradeAPI.Application.Features.Commands.ProductImageFile.UploadProductImage;
using ETradeAPI.Application.Features.Queries.Product.GetAllProduct;
using ETradeAPI.Application.Features.Queries.Product.GetByIdProduct;
using ETradeAPI.Application.Features.Queries.ProductImageFile.GetProductImages;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ETradeAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly IMediator _mediator;
        readonly ILogger<ProductsController> logger;
        readonly IProductService _productService;

        public ProductsController(IMediator mediator, IProductService productService, ILogger<ProductsController> logger)
        {
            _mediator = mediator;
            _productService = productService;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllProductQueryRequest getAllProductQueryRequest)
        {
            GetAllProductQueryResponse response = await _mediator.Send(getAllProductQueryRequest);

            return Ok(response);
        }

        [HttpGet("qrcode/{productId}")]
        public async Task<IActionResult> GetQrCodeToProduct([FromRoute] string productId)
        {
            var data = await _productService.QrCodeToProductAsync(productId);

            return File(data, "image/png");
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdProductQueryRequest getByIdProductQueryRequest)
        {
            GetByIdProductQueryResponse response = await _mediator.Send(getByIdProductQueryRequest);

            return Ok(response);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitonConstants.Products, ActionType = ActionType.Writing, Definition = "Create Product")]
        public async Task<IActionResult> Post(CreateProductCommandRequest createProductCommandRequest)
        {
            CreateProductCommandResponse response = await _mediator.Send(createProductCommandRequest);

            return Ok((int)HttpStatusCode.Created);
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitonConstants.Products, ActionType = ActionType.Updating, Definition = "Update Product")]
        public async Task<IActionResult> Put([FromBody] UpdateProductCommandRequest updateProductCommandRequest)
        {
            UpdateProductCommandResponse response = await _mediator.Send(updateProductCommandRequest);

            return Ok();
        }

        [HttpDelete("{Id}")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitonConstants.Products, ActionType = ActionType.Deleting, Definition = "Delete Product")]
        public async Task<IActionResult> Delete([FromRoute] RemoveProductCommandRequest removeProductCommandRequest)
        {
            RemoveProductCommandResponse response = await _mediator.Send(removeProductCommandRequest);

            return Ok();
        }

        [HttpPost("[action]")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitonConstants.Products, ActionType = ActionType.Writing, Definition = "Upload Product File")]
        public async Task<IActionResult> Upload([FromQuery] UploadProductImageCommandRequest uploadProductImageCommandRequest)
        {
            uploadProductImageCommandRequest.FormFileCollection = Request.Form.Files;
            UploadProductImageCommandResponse response = await _mediator.Send(uploadProductImageCommandRequest);

            return Ok();
        }

        [HttpGet("[action]/{id}")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitonConstants.Products, ActionType = ActionType.Reading, Definition = "Get Product Images")]
        public async Task<IActionResult> GetImages([FromRoute] GetProductImagesQueryRequest getProductImagesQueryRequest)
        {
            List<GetProductImagesQueryResponse> response = await _mediator.Send(getProductImagesQueryRequest);

            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitonConstants.Products, ActionType = ActionType.Deleting, Definition = "Delete Product Image")]
        public async Task<IActionResult> DeleteImage([FromRoute] RemoveProductImageCommandRequest removeProductImageCommandRequest, [FromQuery] string imageId)
        {
            removeProductImageCommandRequest.ImageId = imageId;
            RemoveProductImageCommandResponse response = await _mediator.Send(removeProductImageCommandRequest);

            return Ok();
        }

        [HttpGet("[action]")]
        [Authorize(AuthenticationSchemes = "Admin")]
        [AuthorizeDefinition(Menu = AuthorizeDefinitonConstants.Products, ActionType = ActionType.Updating, Definition = "Change Product Showcase Image")]
        public async Task<IActionResult> ChangeShowcaseImage([FromQuery] ChangeShowcaseImageCommandRequest changeShowcaseImageCommandRequest)
        {
            ChangeShowcaseImageCommandResponse response = await _mediator.Send(changeShowcaseImageCommandRequest);

            return Ok(response);
        }
    }
}
