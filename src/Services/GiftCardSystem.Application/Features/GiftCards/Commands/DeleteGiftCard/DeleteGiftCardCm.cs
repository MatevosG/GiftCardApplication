using GiftCardSystem.Application.Models;
using MediatR;

namespace GiftCardSystem.Application.Features.GiftCards.Commands.DeleteGiftCard
{
    public class DeleteGiftCardCm : IRequest<ResponseModel>
    {
        public int Id { get; set; }

        public DeleteGiftCardCm(int id)
        {
            Id = id;
        }
    }
}
