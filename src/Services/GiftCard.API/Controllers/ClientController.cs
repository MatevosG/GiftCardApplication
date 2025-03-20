using GiftCardSystem.Application.Dtoes;
using GiftCardSystem.Application.Features.Clients.Commands.CreateClient;
using GiftCardSystem.Application.Features.Clients.Commands.DeleteClient;
using GiftCardSystem.Application.Features.Clients.Commands.UpdateClient;
using GiftCardSystem.Application.Features.Clients.Queries.GetClientById;
using GiftCardSystem.Application.Features.Clients.Queries.GetClients;
using GiftCardSystem.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GiftCard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : BaseController
    {
        private readonly IMediator _mediator;
        public ClientController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        [HttpPost("CreateClient")]
        public async Task<IActionResult> CreateClient(RegisterClientDto model)
        {
            return Ok(await _mediator.Send(new CreateClientCm(model)));
        }

        [HttpPut("UpdateClient")]
        public async Task<IActionResult> UpdateClient(ClientDto model)
        {
            return Ok(await _mediator.Send(new UpdateClientCm(model)));
        }

        [HttpGet("GetClientById/{id}")]
        public async Task<IActionResult> GetClientById(int id)
        {
            return Ok(await _mediator.Send(new GetClientByIdQuery(id)));
        }

        [HttpGet("GetClients")]
        public async Task<IActionResult> GetClients([FromQuery]RequestModel model)
        {
            return Ok(await _mediator.Send(new GetClientsQuery(model)));
        }
        [HttpDelete("DeleteClient/{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            return Ok(await _mediator.Send(new DeleteClientCm(id)));
        }
    }
}
