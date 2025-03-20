using AutoMapper;
using GiftCardSystem.Application.Contracts;
using GiftCardSystem.Application.Features.GiftCards.Queries.GetGiftCardById;
using GiftCardSystem.Application.Models;
using MediatR;

namespace GiftCardSystem.Application.Features.GiftCards.Commands.CreateGiftCard
{
    public class CreateGiftCardCmHandler : IRequestHandler<CreateGiftCardCm, ResponseModel>
    {
        private readonly IGiftCardRepository _giftCardRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreateGiftCardCmHandler(IGiftCardRepository giftCardRepository, 
                                       IMapper mapper, 
                                       IMediator mediator)
        {
            _giftCardRepository = giftCardRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ResponseModel> Handle(CreateGiftCardCm request, CancellationToken cancellationToken)
        {
            var giftCard = _mapper.Map<Domain.Entities.GiftCard>(request.Model);
            giftCard = await _giftCardRepository.AddAsync(giftCard);
            return await _mediator.Send(new GetGiftCardByIdQuery(giftCard.Id));
        }
    }
}
