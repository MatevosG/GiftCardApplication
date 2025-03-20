using AutoMapper;
using GiftCardSystem.Application.Contracts;
using GiftCardSystem.Application.Exceptions;
using GiftCardSystem.Application.Features.Clients.Queries.GetClientById;
using GiftCardSystem.Application.Models;
using GiftCardSystem.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GiftCardSystem.Application.Features.Clients.Commands.UpdateClient
{
    public class UpdateClientCmHandler : IRequestHandler<UpdateClientCm, ResponseModel>
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;
        private readonly IAddressRepository _addressRepository;
        private readonly IMediator _mediator;

        public UpdateClientCmHandler(IClientRepository clientRepository, 
                                     IMapper mapper,
                                     IAddressRepository addressRepository,
                                     IMediator mediator)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
            _addressRepository = addressRepository;
            _mediator = mediator;
        }

        public async Task<ResponseModel> Handle(UpdateClientCm request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.GetQuery().AsNoTracking()
                                                .FirstOrDefaultAsync(x=>x.Id == request.ClientDto.Id.Value);
            if (client == null)
                throw new CustomException(nameof(Client), request.ClientDto.Id.Value);
            string salt = client.Salt;
            string password = client.Password;
            string email = client.Email;

            var clientAddresses = await _addressRepository.GetQuery(x=>!x.IsDeleted)
                                                          .Where(x=>x.ClientId == client.Id)
                                                          .AsNoTracking()
                                                          .ToListAsync();

            foreach (var item in request.ClientDto.Addresses)
            {
                if (item.Id.HasValue)
                {
                    var address = clientAddresses.FirstOrDefault(x => x.Id == item.Id);
                    if (address != null)
                    {
                        address = _mapper.Map<Address>(item);
                        address.ClientId = client.Id;
                        await _addressRepository.UpdateAsync(address);
                    }
                }
                else
                {
                    var address = _mapper.Map<Address>(item);
                    address.ClientId = client.Id;
                    await _addressRepository.AddAsync(address);
                }
            }
            var addresForDelete = clientAddresses.Where(x => !request.ClientDto.Addresses.Select(s=>s.Id).Contains(x.Id)).ToList();
            if (addresForDelete != null && addresForDelete.Count() > 0)
            {
                foreach (var address in addresForDelete)
                    address.IsDeleted = true;
                await _addressRepository.UpdateRangeAsync(addresForDelete);
            }
            request.ClientDto.Addresses = null;
            client = _mapper.Map(request.ClientDto, client);
            client.Salt = salt;
            client.Password = password;
            client.Email = email;
            await _clientRepository.UpdateAsync(client);
            return await _mediator.Send(new GetClientByIdQuery(client.Id)); 
        }
    }
}
