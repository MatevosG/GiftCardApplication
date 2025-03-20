using AutoMapper;
using GiftCardSystem.Application.Contracts;
using GiftCardSystem.Application.Dtoes;
using GiftCardSystem.Application.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftCardSystem.Application.Features.Clients.Queries.GetClients
{
    public class GetClientsQueryHandler : IRequestHandler<GetClientsQuery, ResponseModel>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public GetClientsQueryHandler(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        public async Task<ResponseModel> Handle(GetClientsQuery request, CancellationToken cancellationToken)
        {
           var clients = await _clientRepository.GetQuery().OrderByDescending(x => x.Id)
                                                           .Skip(request.model.SkipCount * request.model.TakeCount)
                                                           .Take(request.model.TakeCount)
                                                           .AsNoTracking()
                                                           .ToListAsync();
            var response = new ResponseModel<ClientDto>();
            response.Entities = _mapper.Map<List<ClientDto>>(clients);
            response.TotalCount = await _clientRepository.GetQuery().CountAsync();
            response.Count = response.Entities.Count();
            return new ResponseModel(response);
        }
    }
}
