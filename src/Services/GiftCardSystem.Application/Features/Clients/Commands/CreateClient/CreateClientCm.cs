using GiftCardSystem.Application.Dtoes;
using GiftCardSystem.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftCardSystem.Application.Features.Clients.Commands.CreateClient
{
    public class CreateClientCm : IRequest<ResponseModel>
    {
        public RegisterClientDto RegisterClientDto { get; set; }

        public CreateClientCm(RegisterClientDto registerClientDto)
        {
            RegisterClientDto = registerClientDto;
        }
    }
}
