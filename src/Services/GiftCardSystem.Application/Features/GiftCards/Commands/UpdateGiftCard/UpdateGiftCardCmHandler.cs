using AutoMapper;
using GiftCardSystem.Application.Contracts;
using GiftCardSystem.Application.Dtoes;
using GiftCardSystem.Application.Exceptions;
using GiftCardSystem.Application.Features.GiftCards.Queries.GetGiftCardById;
using GiftCardSystem.Application.Models;
using MediatR;

namespace GiftCardSystem.Application.Features.GiftCards.Commands.UpdateGiftCard
{
    public class UpdateGiftCardCmHandler : IRequestHandler<UpdateGiftCardCm, ResponseModel>
    {
        private readonly IGiftCardRepository _giftCardRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UpdateGiftCardCmHandler(IGiftCardRepository giftCardRepository, 
                                       IMapper mapper,
                                       IMediator mediator)
        {
            _giftCardRepository = giftCardRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<ResponseModel> Handle(UpdateGiftCardCm request, CancellationToken cancellationToken)
        {
            var giftCard = await _giftCardRepository.GetByIdAsNoTrackingAsync(request.Model.Id.Value);
            if (giftCard == null)
                throw new CustomException(nameof(Domain.Entities.GiftCard), request.Model.Id);
            giftCard = _mapper.Map(request.Model, giftCard);
            await _giftCardRepository.UpdateAsync(giftCard);
            return await _mediator.Send(new GetGiftCardByIdQuery(giftCard.Id));
        }
    }
}
