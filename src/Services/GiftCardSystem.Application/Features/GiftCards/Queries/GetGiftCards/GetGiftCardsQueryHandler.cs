using AutoMapper;
using GiftCardSystem.Application.Contracts;
using GiftCardSystem.Application.Dtoes;
using GiftCardSystem.Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GiftCardSystem.Application.Features.GiftCards.Queries.GetGiftCards
{
    public class GetGiftCardsQueryHandler : IRequestHandler<GetGiftCardsQuery, ResponseModel>
    {
        private readonly IGiftCardRepository _giftCardRepository;
        private readonly IMapper _mapper;

        public GetGiftCardsQueryHandler(IGiftCardRepository giftCardRepository, IMapper mapper)
        {
            _giftCardRepository = giftCardRepository;
            _mapper = mapper;
        }

        public async Task<ResponseModel> Handle(GetGiftCardsQuery request, CancellationToken cancellationToken)
        {
            var giftCards = await _giftCardRepository.GetQuery()
                                                     .OrderByDescending(x => x.Id)
                                                     .Skip(request.Request.SkipCount * request.Request.TakeCount)
                                                     .Take(request.Request.TakeCount)
                                                     .ToListAsync();
            var response = new ResponseModel<GiftCardDto>();
            response.Entities = _mapper.Map<List<GiftCardDto>>(giftCards);
            response.TotalCount = await _giftCardRepository.GetQuery().CountAsync();
            response.Count = response.Entities.Count();
            return new ResponseModel(response);
        }
    }
}
