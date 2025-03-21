using GiftCardSystem.Application.Dtoes;
using GiftCardSystem.Application.Models;
using MediatR;

namespace GiftCardSystem.Application.Features.GiftCardPurchases.Commands.UpdateGiftCardPurchase
{
    public class UpdateGiftCardPurchaseRedeemedCm : IRequest<ResponseModel>
    {
        public int Id { get; set; }

        public UpdateGiftCardPurchaseRedeemedCm(int id)
        {
            Id = id;
        }
    }
}
