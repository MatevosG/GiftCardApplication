using GiftCardSystem.Application.Models;
using MediatR;

namespace GiftCardSystem.Application.Features.Clients.Commands.DeleteClient
{
    public class DeleteClientCm : IRequest<ResponseModel>
    {
        public int ClientId { get; set; }

        public DeleteClientCm(int clientId)
        {
            ClientId = clientId;
        }
    }
}
