using GiftCardSystem.Application.Dtoes;
using GiftCardSystem.Application.Models;
using MediatR;

namespace GiftCardSystem.Application.Features.Clients.Commands.UpdateClient
{
    public class UpdateClientCm : IRequest<ResponseModel>
    {
        public ClientDto ClientDto { get; set; }

        public UpdateClientCm(ClientDto clientDto)
        {
            ClientDto = clientDto;
        }
    }
}
