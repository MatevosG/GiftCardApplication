﻿using GiftCardSystem.Application.Contracts;
using GiftCardSystem.Application.Exceptions;
using GiftCardSystem.Application.Models;
using GiftCardSystem.Domain.Entities;
using MediatR;

namespace GiftCardSystem.Application.Features.GiftCardPurchases.Commands.UpdateGiftCardPurchase
{
    public class UpdateGiftCardPurchaseRedeemedCmHandler : IRequestHandler<UpdateGiftCardPurchaseRedeemedCm, ResponseModel>
    {
        private readonly IGiftCardPurchaseRepository _giftCardPurchaseRepository;

        public UpdateGiftCardPurchaseRedeemedCmHandler(IGiftCardPurchaseRepository giftCardPurchaseRepository)
        {
            _giftCardPurchaseRepository = giftCardPurchaseRepository;
        }

        public async Task<ResponseModel> Handle(UpdateGiftCardPurchaseRedeemedCm request, CancellationToken cancellationToken)
        {
            var giftCardPurchase = await _giftCardPurchaseRepository.GetByIdAsNoTrackingAsync(request.Model.Id.Value);
            if (giftCardPurchase == null)
                throw new CustomException(nameof(GiftCardPurchase), request.Model.Id);
          
            if (giftCardPurchase.IsRedeemed != request.Model.IsRedeemed.Value && !giftCardPurchase.IsRedeemed)
            {
                giftCardPurchase.IsRedeemed = request.Model.IsRedeemed.Value;
                await _giftCardPurchaseRepository.UpdateAsync(giftCardPurchase);
            }
            return new ResponseModel("GiftCardPurchase Redeemed updated successfully");
        }
    }
}
