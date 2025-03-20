using GiftCardSystem.Application.Dtoes;
using GiftCardSystem.Application.Models;
using MediatR;

namespace GiftCardSystem.Application.Features.GiftCardPurchases.Commands.UseGiftCard
{
    public class UseGiftCardCm :IRequest<ResponseModel>
    {
        public TransactionDto Model { get; set; }

        public UseGiftCardCm(TransactionDto model)
        {
            Model = model;
        }
    }
}
