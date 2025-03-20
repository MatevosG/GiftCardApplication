using GiftCardSystem.Application.Models;
using MediatR;

namespace GiftCardSystem.Application.Features.GiftCardPurchases.Queries.GetGiftCardPurchases
{
    public class GetGiftCardPurchasesQuery : IRequest<ResponseModel>
    {
        public RequestModel Request { get; set; }
        public GetGiftCardPurchasesQuery(RequestModel request)
        {
            Request = request;
        }
    }
}
