using AutoMapper;
using GiftCardSystem.Application.Contracts;
using GiftCardSystem.Application.Dtoes;
using GiftCardSystem.Application.Exceptions;
using GiftCardSystem.Application.Models;
using GiftCardSystem.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GiftCardSystem.Application.Features.GiftCardPurchases.Queries.GetGiftCardPurchaseById
{
    public class GetGiftCardPurchaseByIdQueryHandler : IRequestHandler<GetGiftCardPurchaseByIdQuery, ResponseModel>
    {
        private readonly IGiftCardPurchaseRepository _giftCardPurchaseRepository;
        private readonly IMapper _mapper;

        public GetGiftCardPurchaseByIdQueryHandler(IGiftCardPurchaseRepository giftCardPurchaseRepository, IMapper mapper)
        {
            _giftCardPurchaseRepository = giftCardPurchaseRepository;
            _mapper = mapper;
        }

        public async Task<ResponseModel> Handle(GetGiftCardPurchaseByIdQuery request, CancellationToken cancellationToken)
        {
            var giftCardPurchase = await _giftCardPurchaseRepository.GetQuery()
                                                              .Include(x=>x.GiftCardTransactions)
                                                              .Include(x => x.GiftCard)
                                                              .FirstOrDefaultAsync(x => x.Id == request.Id);
            if (giftCardPurchase == null)
                throw new CustomException(nameof(GiftCardPurchase), request.Id);
            return new ResponseModel(_mapper.Map<GiftCardPurchaseDto>(giftCardPurchase));
        }
    }
}
