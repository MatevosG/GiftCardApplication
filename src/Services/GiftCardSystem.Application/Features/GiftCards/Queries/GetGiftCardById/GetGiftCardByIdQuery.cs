using GiftCardSystem.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftCardSystem.Application.Features.GiftCards.Queries.GetGiftCardById
{
    public class GetGiftCardByIdQuery : IRequest<ResponseModel>
    {
        public int Id { get; set; }
        public GetGiftCardByIdQuery(int id)
        {
            Id = id;
        }
    }
}
