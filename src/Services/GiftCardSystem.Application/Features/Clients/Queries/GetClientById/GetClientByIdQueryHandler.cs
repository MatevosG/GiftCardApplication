using AutoMapper;
using GiftCardSystem.Application.Contracts;
using GiftCardSystem.Application.Dtoes;
using GiftCardSystem.Application.Exceptions;
using GiftCardSystem.Application.Models;
using GiftCardSystem.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GiftCardSystem.Application.Features.Clients.Queries.GetClientById
{
    public class GetClientByIdQueryHandler : IRequestHandler<GetClientByIdQuery, ResponseModel>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public GetClientByIdQueryHandler(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<ResponseModel> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.GetQuery()
                                                .Include(x=>x.Addresses)
                                                .FirstOrDefaultAsync(x=>x.Id == request.Id);
            if (client == null)
                throw new CustomException(nameof(Client), request.Id);
            client.Addresses = client.Addresses.Where(a => !a.IsDeleted).ToList();
            return new ResponseModel(_mapper.Map<ClientDto>(client));
        }
    }
}
