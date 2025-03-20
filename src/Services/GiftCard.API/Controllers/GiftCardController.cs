using GiftCardSystem.Application.Dtoes;
using GiftCardSystem.Application.Features.GiftCards.Commands.CreateGiftCard;
using GiftCardSystem.Application.Features.GiftCards.Commands.DeleteGiftCard;
using GiftCardSystem.Application.Features.GiftCards.Commands.UpdateGiftCard;
using GiftCardSystem.Application.Features.GiftCards.Queries.GetGiftCardById;
using GiftCardSystem.Application.Features.GiftCards.Queries.GetGiftCards;
using GiftCardSystem.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GiftCard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiftCardController : ControllerBase
    {
        private readonly IMediator _mediator;
        public GiftCardController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost("CreateGiftCard")]
        public async Task<IActionResult> CreateGiftCard(GiftCardDto model)
        {
            return Ok(await _mediator.Send(new CreateGiftCardCm(model)));
        }

        [HttpGet("GetGiftCardById/{id}")]
        public async Task<IActionResult> GetGiftCardById(int id)
        {
            return Ok(await _mediator.Send(new GetGiftCardByIdQuery(id)));
        }

        [HttpGet("GetGiftCards")]
        public async Task<IActionResult> GetGiftCards([FromQuery] RequestModel model)
        {
            return Ok(await _mediator.Send(new GetGiftCardsQuery(model)));
        }

        [HttpPut("UpdateGiftCard")]
        public async Task<IActionResult> UpdateGiftCard(GiftCardDto model)
        {
            return Ok(await _mediator.Send(new UpdateGiftCardCm(model)));
        }

        [HttpDelete("DeleteGiftCard/{id}")]
        public async Task<IActionResult> DeleteGiftCard(int id)
        {
            return Ok(await _mediator.Send(new DeleteGiftCardCm(id)));
        }
    }
}
