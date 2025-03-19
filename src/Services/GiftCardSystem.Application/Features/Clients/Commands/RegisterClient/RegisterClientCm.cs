using GiftCardSystem.Application.Dtoes;
using GiftCardSystem.Application.Models;
using MediatR;

namespace GiftCardSystem.Application.Features.Clients.Commands.RegisterClient
{
    public class RegisterClientCm : IRequest<ResponseModel>
    {
        public RegisterClientDto ClientDto { get; set; }

        public RegisterClientCm(RegisterClientDto clientDto)
        {
            ClientDto = clientDto;
        }
    }
}
