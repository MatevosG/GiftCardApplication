using GiftCardSystem.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftCardSystem.Application.Features.Clients.Queries.GetClients
{
    public class GetClientsQuery : IRequest<ResponseModel>
    {
        public RequestModel model { get; set; }

        public GetClientsQuery(RequestModel model)
        {
            this.model = model;
        }
    }
}
