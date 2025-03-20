using MediatR;
using Microsoft.AspNetCore.Http;
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

    }
}
