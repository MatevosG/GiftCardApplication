using GiftCardSystem.Application.Dtoes;
using GiftCardSystem.Application.Models;
using MediatR;

namespace GiftCardSystem.Application.Features.GiftCards.Commands.CreateGiftCard
{
    public class CreateGiftCardCm : IRequest<ResponseModel>
    {
        public GiftCardDto Model { get; set; }

        public CreateGiftCardCm(GiftCardDto model)
        {
            Model = model;
        }
    }
}
