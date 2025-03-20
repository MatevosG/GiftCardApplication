using GiftCardSystem.Application.Contracts;
using GiftCardSystem.Application.Exceptions;
using GiftCardSystem.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftCardSystem.Application.Features.GiftCards.Commands.DeleteGiftCard
{
    public class DeleteGiftCardCmHandler : IRequestHandler<DeleteGiftCardCm, ResponseModel>
    {
        private readonly IGiftCardRepository _giftCardRepository;

        public DeleteGiftCardCmHandler(IGiftCardRepository giftCardRepository)
        {
            _giftCardRepository = giftCardRepository;
        }

        public async Task<ResponseModel> Handle(DeleteGiftCardCm request, CancellationToken cancellationToken)
        {
            var giftCard = await _giftCardRepository.GetByIdAsNoTrackingAsync(request.Id);
            if (giftCard == null)
                throw new CustomException(nameof(Domain.Entities.GiftCard), request.Id);
            await _giftCardRepository.DeleteAsync(giftCard);
            return new ResponseModel("GiftCard deleted successfully");
        }
    }
}
