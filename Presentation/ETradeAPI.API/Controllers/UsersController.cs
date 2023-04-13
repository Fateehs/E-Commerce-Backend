using ETradeAPI.Application.Abstractions.Services;
using ETradeAPI.Application.Features.Commands.AppUser.CreateUser;
using ETradeAPI.Application.Features.Commands.AppUser.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ETradeAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        readonly IMediator _mediator;
        readonly IMailService _mailService;

        public UsersController(IMediator mediator, IMailService mailService)
        {
            _mediator = mediator;
            _mailService = mailService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCommandRequest createUserCommandRequest)
        {
            CreateUserCommandResponse response = await _mediator.Send(createUserCommandRequest);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> ExampleMailTest()
        {
            await _mailService.SendMessageAsync("fatiheselvi@gmail.com", "Test Mail", "<stong> Its just a test mail</strong>");

            return Ok();
        }
    }
}
