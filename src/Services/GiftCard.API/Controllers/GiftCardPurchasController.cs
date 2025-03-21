using GiftCardSystem.Application.Constants;
using GiftCardSystem.Application.Dtoes;
using GiftCardSystem.Application.Features.GiftCardPurchases.Commands.BuyGiftCard;
using GiftCardSystem.Application.Features.GiftCardPurchases.Commands.UpdateGiftCardPurchase;
using GiftCardSystem.Application.Features.GiftCardPurchases.Commands.UseGiftCard;
using GiftCardSystem.Application.Features.GiftCardPurchases.Queries.GetGiftCardPurchaseById;
using GiftCardSystem.Application.Features.GiftCardPurchases.Queries.GetGiftCardPurchases;
using GiftCardSystem.Application.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GiftCard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiftCardPurchasController : ControllerBase
    {
        private readonly IMediator _mediator;
        public GiftCardPurchasController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        [HttpGet("GetGiftCardPurchaseById/{id}")]
        public async Task<IActionResult> GetGiftCardPurchaseById(int id)
        {
            return Ok(await _mediator.Send(new GetGiftCardPurchaseByIdQuery(id)));
        }

        [HttpGet("GetGiftCardPurchases")]
        public async Task<IActionResult> GetGiftCardPurchases([FromQuery]RequestModel query)
        {
            return Ok(await _mediator.Send(new GetGiftCardPurchasesQuery(query)));
        }

        [HttpPost("BuyGiftCard")]
        public async Task<IActionResult> BuyGiftCard(BuyGiftCardDto model)
        {
            return Ok(await _mediator.Send(new BuyGiftCardCm(model)));
        }

        [HttpPost("Purchase")]
        public async Task<IActionResult> Purchase(TransactionDto model)
        {
            model.Type = (int)GiftCardTransactionTypes.Purchase;
            return Ok(await _mediator.Send(new UseGiftCardCm(model)));
        }

        [HttpPost("Refund")]
        public async Task<IActionResult> Refund(TransactionDto model)
        {
            model.Type = (int)GiftCardTransactionTypes.Refund;
            return Ok(await _mediator.Send(new UseGiftCardCm(model)));
        }
        [HttpPut("Redeeme")]
        public async Task<IActionResult> UpdateGiftCardPurchaseRedeeme(int id)
        {
            return Ok(await _mediator.Send(new UpdateGiftCardPurchaseRedeemedCm(id)));
        }
    }
}
