using AutoMapper;
using GiftCardSystem.Application.Contracts;
using GiftCardSystem.Application.Dtoes;
using GiftCardSystem.Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GiftCardSystem.Application.Features.GiftCardPurchases.Queries.GetGiftCardPurchases
{
    public class GetGiftCardPurchasesQueryHandler : IRequestHandler<GetGiftCardPurchasesQuery, ResponseModel>
    {
        private readonly IGiftCardPurchaseRepository _giftCardPurchaseRepository;
        private readonly IMapper _mapper;

        public GetGiftCardPurchasesQueryHandler(IGiftCardPurchaseRepository giftCardPurchaseRepository, IMapper mapper)
        {
            _giftCardPurchaseRepository = giftCardPurchaseRepository;
            _mapper = mapper;
        }

        public async Task<ResponseModel> Handle(GetGiftCardPurchasesQuery request, CancellationToken cancellationToken)
        {
            var giftCardPurchases = await  _giftCardPurchaseRepository.GetQuery()
                                                                      .Include(x => x.GiftCard)
                                                                      .OrderByDescending(x => x.Id)
                                                                      .Skip(request.Request.SkipCount * request.Request.TakeCount)
                                                                      .Take(request.Request.TakeCount)
                                                                      .ToListAsync();
            var response = new ResponseModel<GiftCardPurchaseDto>();
            response.Entities = _mapper.Map<List<GiftCardPurchaseDto>>(giftCardPurchases);
            response.TotalCount = await _giftCardPurchaseRepository.GetQuery().CountAsync();
            response.Count = response.Entities.Count();
            return new ResponseModel(response);
        }
    }
}
