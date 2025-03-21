using GiftCardSystem.Application.Constants;
using GiftCardSystem.Application.Contracts;
using GiftCardSystem.Application.Exceptions;
using GiftCardSystem.Application.Models;
using GiftCardSystem.Domain.Entities;
using MediatR;

namespace GiftCardSystem.Application.Features.GiftCardPurchases.Commands.UseGiftCard
{
    public class UseGiftCardCmHandler : IRequestHandler<UseGiftCardCm, ResponseModel>
    {
        private readonly IGiftCardTransactionRepository _giftCardTransactionRepository;
        private readonly IGiftCardPurchaseRepository _giftCardPurchaseRepository;

        public UseGiftCardCmHandler(IGiftCardTransactionRepository giftCardTransactionRepository,
                                    IGiftCardPurchaseRepository giftCardPurchaseRepository)
        {
            _giftCardTransactionRepository = giftCardTransactionRepository;
            _giftCardPurchaseRepository = giftCardPurchaseRepository;
        }

        public async Task<ResponseModel> Handle(UseGiftCardCm request, CancellationToken cancellationToken)
        {
            var giftCardPurchase = await _giftCardPurchaseRepository.GetByIdAsNoTrackingAsync(request.Model.GiftCardPurchaseId);
            
            if (giftCardPurchase == null)
                throw new CustomException(nameof(GiftCardPurchase), request.Model.GiftCardPurchaseId);

            if(giftCardPurchase.ExpirationDate < DateTime.UtcNow)
                throw new CustomException("Gift Card has expired");

            if (request.Model.Type == (int)GiftCardTransactionTypes.Refund)
            {
                var transaction = await _giftCardTransactionRepository.GetByIdAsNoTrackingAsync(request.Model.RefundTransactionId.Value);
                if(transaction == null)
                    throw new CustomException(nameof(GiftCardTransaction), request.Model.RefundTransactionId.Value);

                if(transaction.Type == (int)GiftCardTransactionTypes.Refund)
                    throw new CustomException("Transaction has already been refunded");
                transaction.Type = (int)GiftCardTransactionTypes.Refund;
                await _giftCardTransactionRepository.UpdateAsync(transaction);
               
                giftCardPurchase.Balance += transaction.Amount;
                if(giftCardPurchase.IsRedeemed)
                    giftCardPurchase.IsRedeemed =false;
                await _giftCardPurchaseRepository.UpdateAsync(giftCardPurchase);
                
                return new ResponseModel { Response = "Gift Card Refunded Successfully" };
            }

            if(giftCardPurchase.IsRedeemed)
                throw new CustomException("Gift Card has already been redeemed");

            if (giftCardPurchase.Balance == 0m)
                throw new CustomException("Gift Card has no balance");

            if (giftCardPurchase.Balance - request.Model.Amount < 0m)
                throw new CustomException("Gift Card has insufficient balance");

            var newTransaction = await _giftCardTransactionRepository.AddAsync(new GiftCardTransaction
            {
                Amount = request.Model.Amount,
                GiftCardPurchaseId = giftCardPurchase.Id,
                Type = (int)GiftCardTransactionTypes.Purchase,
            });
            giftCardPurchase.Balance -= newTransaction.Amount;
            await _giftCardPurchaseRepository.UpdateAsync(giftCardPurchase);
            return new ResponseModel { Response = "Gift Card Used Successfully" };
        }
    }
}
