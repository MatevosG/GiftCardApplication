using GiftCardSystem.Application.Models;
using MediatR;

namespace GiftCardSystem.Application.Features.GiftCards.Queries.GetGiftCards
{
    public class GetGiftCardsQuery : IRequest<ResponseModel>
    {
        public RequestModel Request { get; set; }

        public GetGiftCardsQuery(RequestModel request)
        {
            Request = request;
        }
    }
}
