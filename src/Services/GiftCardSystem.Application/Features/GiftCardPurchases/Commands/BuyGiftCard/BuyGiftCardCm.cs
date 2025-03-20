using GiftCardSystem.Application.Dtoes;
using GiftCardSystem.Application.Models;
using MediatR;

namespace GiftCardSystem.Application.Features.GiftCardPurchases.Commands.BuyGiftCard
{
    public class BuyGiftCardCm : IRequest<ResponseModel>
    {
        public BuyGiftCardDto Model { get; set; }
        public BuyGiftCardCm(BuyGiftCardDto model)
        {
            Model = model;
        }
    }
}
