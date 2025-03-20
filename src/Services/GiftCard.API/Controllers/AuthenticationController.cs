using Azure;
using GiftCardSystem.Application.Dtoes;
using GiftCardSystem.Application.Features.Clients.Commands.LoginClient;
using GiftCardSystem.Application.Features.Clients.Commands.RegisterClient;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GiftCard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthenticationController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginClientDto loginModel)
        {
            LoginClientCm loginClientCm = new LoginClientCm(loginModel);
            var response = await _mediator.Send(loginClientCm);
            Response.Headers.Add("Token", response.Response.ToString());
            Response.Cookies.Append("Authorization", "Bearer " + response.Response.ToString());
            return Ok();
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterClientDto request)
        {
            RegisterClientCm registerClientCm = new RegisterClientCm(request);
            var response = await _mediator.Send(registerClientCm);
            Response.Headers.Add("Token", response.Response.ToString());
            Response.Cookies.Append("Authorization", "Bearer " + response.Response.ToString());
            return Ok();
        }
    }
}
