using ETradeAPI.Application.Abstractions;
using ETradeAPI.Application.Features.Commands.CreateProduct;
using ETradeAPI.Application.Features.Queries.GetAllProduct;
using ETradeAPI.Application.Repositories;
using ETradeAPI.Application.Repositories.File;
using ETradeAPI.Application.RequestParameters;
using ETradeAPI.Application.ViewModels.Products;
using ETradeAPI.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ETradeAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly IProductWriteRepository _productWriteRepository;
        readonly IProductReadRepository _productReadRepository;
        readonly IWebHostEnvironment _webHostEnvironment;
        readonly IStorageService _storageService;
        readonly IFileReadRepository _fileReadRepository;
        readonly IFileWriteRepository _fileWriteRepository;
        readonly IProductImageFileWriteRepository _productImageFileWriteRepository;
        readonly IProductImageFileReadRepository _productImageFileReadRepository;
        readonly IInvoiceFileWriteRepository _invoiceFileWriteRepository;
        readonly IInvoiceFileReadRepository _invoiceFileReadRepository;
        readonly IConfiguration _configuration;

        readonly IMediator _mediator;

        public ProductsController(IProductWriteRepository productWriteRepository,
            IProductReadRepository productReadRepository,
            IWebHostEnvironment webHostEnvironment,
            IStorageService storageService,
            IFileReadRepository fileReadRepository,
            IFileWriteRepository fileWriteRepository,
            IProductImageFileWriteRepository productImageFileWriteRepository,
            IProductImageFileReadRepository productImageFileReadRepository,
            IInvoiceFileWriteRepository invoiceFileWriteRepository,
            IInvoiceFileReadRepository invoiceFileReadRepository,
            IConfiguration configuration,
            IMediator mediator
            )
        {
            _configuration = configuration;
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _webHostEnvironment = webHostEnvironment;
            _storageService = storageService;
            _fileReadRepository = fileReadRepository;
            _fileWriteRepository = fileWriteRepository;
            _productImageFileWriteRepository = productImageFileWriteRepository;
            _productImageFileReadRepository = productImageFileReadRepository;
            _invoiceFileWriteRepository = invoiceFileWriteRepository;
            _invoiceFileReadRepository = invoiceFileReadRepository;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllProductQueryRequest getAllProductQueryRequest)
        {
            GetAllProductQueryResponse response = await _mediator.Send(getAllProductQueryRequest);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(_productReadRepository.GetByIdAsync(id, false));
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateProductCommandRequest createProductCommandRequest)
        {
            CreateProductCommandResponse response = await _mediator.Send(createProductCommandRequest);

            return Ok((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> Put(VM_Update_Product model)
        {
            Product product = await _productReadRepository.GetByIdAsync(model.Id);

            product.Stock = model.Stock;
            product.Price = model.Price;
            product.Name = model.Name;

            await _productWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _productWriteRepository.RemoveAsync(id);
            await _productWriteRepository.SaveAsync();
            return Ok(new
            {
                message = "Object successfully deleted."
            });
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> Upload(string id)
        {
            List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("photo-images", Request.Form.Files);

            Product product = await _productReadRepository.GetByIdAsync(id);

            //foreach (var item in result)
            //{
            // product.ProductImageFiles.Add(new()
            // {
            // FileName = item.fileName,
            // Path = item.pathOrContainerName,
            //  Storage = _storageService.StorageName,
            //Products = new List<Product>() { product }
            //});
            //}

            await _productImageFileWriteRepository.AddRangeAsync(result.Select(p => new ProductImageFile
            {
                FileName = p.fileName,
                Path = p.pathOrContainerName,
                Storage = _storageService.StorageName,
                Products = new List<Product>() { product }
            }).ToList());

            await _productImageFileWriteRepository.SaveAsync();

            return Ok();
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetImages(string id)
        {
            Product? product = await _productReadRepository.Table.Include(p => p.ProductImageFiles).FirstOrDefaultAsync(p => p.Id == Guid.Parse(id));

            //_productImageFileReadRepository.GetWhere(p => p.Id == Guid.Parse(id));
            //await _productImageFileReadRepository.GetByIdAsync(id, true);

            return Ok(product.ProductImageFiles.Select(p => new
            {
                Path = $"{_configuration["BaseStorageUrl"]}/{p.Path}",
                p.FileName,
                p.Id
            }));
        }

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeleteImage(string id, string imageId)
        {
            Product? product = await _productReadRepository.Table.Include(p => p.ProductImageFiles).FirstOrDefaultAsync(p => p.Id == Guid.Parse(id));

            ProductImageFile productImageFile = product.ProductImageFiles.FirstOrDefault(p => p.Id == Guid.Parse(imageId));
            product.ProductImageFiles.Remove(productImageFile);
            await _productWriteRepository.SaveAsync();

            return Ok();
        }
    }
}
