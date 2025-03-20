using AutoMapper;
using GiftCardSystem.Application.Contracts;
using GiftCardSystem.Application.Dtoes;
using GiftCardSystem.Application.Exceptions;
using GiftCardSystem.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftCardSystem.Application.Features.GiftCards.Queries.GetGiftCardById
{
    public class GetGiftCardByIdQueryHandler : IRequestHandler<GetGiftCardByIdQuery, ResponseModel>
    {
        private readonly IGiftCardRepository _giftCardRepository;
        private readonly IMapper _mapper;

        public GetGiftCardByIdQueryHandler(IGiftCardRepository giftCardRepository, IMapper mapper)
        {
            _giftCardRepository = giftCardRepository;
            _mapper = mapper;
        }

        public async Task<ResponseModel> Handle(GetGiftCardByIdQuery request, CancellationToken cancellationToken)
        {
            var giftCard = await _giftCardRepository.GetByIdAsNoTrackingAsync(request.Id);
            if (giftCard == null)
                throw new CustomException(nameof(GiftCard), request.Id);
            return new ResponseModel(_mapper.Map<GiftCardDto>(giftCard));
        }
    }
}
