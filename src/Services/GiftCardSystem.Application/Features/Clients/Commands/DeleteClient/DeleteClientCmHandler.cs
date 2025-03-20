using GiftCardSystem.Application.Contracts;
using GiftCardSystem.Application.Exceptions;
using GiftCardSystem.Application.Models;
using GiftCardSystem.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftCardSystem.Application.Features.Clients.Commands.DeleteClient
{
    public class DeleteClientCmHandler : IRequestHandler<DeleteClientCm, ResponseModel>
    {
        private readonly IClientRepository _clientRepository;

        public DeleteClientCmHandler(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<ResponseModel> Handle(DeleteClientCm request, CancellationToken cancellationToken)
        {
            var client = await _clientRepository.GetByIdAsNoTrackingAsync(request.ClientId);
            if (client == null)
                throw new CustomException(nameof(Client), request.ClientId);
            await _clientRepository.DeleteAsync(client);
            return new ResponseModel("Client deleted successfully");
        }
    }
}
