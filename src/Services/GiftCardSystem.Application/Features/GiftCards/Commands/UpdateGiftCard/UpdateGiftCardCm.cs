using Azure;
using GiftCardSystem.Application.Dtoes;
using GiftCardSystem.Application.Models;
using MediatR;

namespace GiftCardSystem.Application.Features.GiftCards.Commands.UpdateGiftCard
{
    public class UpdateGiftCardCm : IRequest<ResponseModel>
    {
        public GiftCardDto Model { get; set; }

        public UpdateGiftCardCm(GiftCardDto model)
        {
            Model = model;
        }
    }
}
