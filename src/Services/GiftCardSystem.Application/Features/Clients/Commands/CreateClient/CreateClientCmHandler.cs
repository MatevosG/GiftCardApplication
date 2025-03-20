using AutoMapper;
using GiftCardSystem.Application.Contracts;
using GiftCardSystem.Application.Features.Clients.Commands.RegisterClient;
using GiftCardSystem.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftCardSystem.Application.Features.Clients.Commands.CreateClient
{
    public class CreateClientCmHandler : IRequestHandler<CreateClientCm, ResponseModel>
    {
       
        private readonly IMediator _mediator;

        public CreateClientCmHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ResponseModel> Handle(CreateClientCm request, CancellationToken cancellationToken)
        {
            await _mediator.Send(new RegisterClientCm(request.RegisterClientDto));
            var response = new ResponseModel
            {
                IsSuccess = true,
                Response = "Client created successfully"
            };
            return response;
        }
    }
}
