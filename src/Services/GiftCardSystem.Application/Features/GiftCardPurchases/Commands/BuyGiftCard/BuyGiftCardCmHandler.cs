using AutoMapper;
using GiftCardSystem.Application.Contracts;
using GiftCardSystem.Application.Dtoes;
using GiftCardSystem.Application.Exceptions;
using GiftCardSystem.Application.Models;
using GiftCardSystem.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GiftCardSystem.Application.Features.GiftCardPurchases.Commands.BuyGiftCard
{
    public class BuyGiftCardCmHandler : IRequestHandler<BuyGiftCardCm, ResponseModel>
    {
        private readonly IGiftCardPurchaseRepository _giftCardPurchaseRepository;
        private readonly IMapper _mapper;
        private readonly IAddressRepository _addressRepository;
        private readonly IGiftCardRepository _giftCardRepository;

        public BuyGiftCardCmHandler(IGiftCardPurchaseRepository giftCardPurchaseRepository, 
                                    IMapper mapper, 
                                    IAddressRepository addressRepository, 
                                    IGiftCardRepository giftCardRepository
                                     )
        {
            _giftCardPurchaseRepository = giftCardPurchaseRepository;
            _mapper = mapper;
            _addressRepository = addressRepository;
            _giftCardRepository = giftCardRepository;
        }

        public async Task<ResponseModel> Handle(BuyGiftCardCm request, CancellationToken cancellationToken)
        {
            var giftCardPurchase = _mapper.Map<GiftCardPurchase>(request.Model);
            var address = await _addressRepository.GetQuery(x=> x.Id == request.Model.AddressId && !x.IsDeleted)
                                                  .FirstOrDefaultAsync();
            if (address == null)
                throw new CustomException(nameof(Address), request.Model.AddressId);

            var giftCard = await _giftCardRepository.GetByIdAsNoTrackingAsync(request.Model.GiftCardId);
            if (giftCard == null)
                throw new CustomException(nameof(Domain.Entities.GiftCard), request.Model.GiftCardId);

            if(Math.Round(request.Model.Amount,1) < Math.Round(giftCard.Amount,1))
                throw new CustomException("Amount should be greater than or equal to gift card amount");


            giftCardPurchase.Balance = giftCard.Amount;
            giftCardPurchase.ExpirationDate = DateTime.UtcNow.AddMonths(giftCard.ExpirationMonthPeriod);
            giftCardPurchase = await _giftCardPurchaseRepository.AddAsync(giftCardPurchase);
            return new ResponseModel(_mapper.Map<GiftCardPurchaseDto>(giftCardPurchase));
        }
    }
}
