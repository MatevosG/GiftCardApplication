using GiftCardSystem.Application.Dtoes;
using GiftCardSystem.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftCardSystem.Application.Features.GiftCardPurchases.Queries.GetGiftCardPurchaseById
{
    public class GetGiftCardPurchaseByIdQuery : IRequest<ResponseModel>
    {
        public int Id { get; set; }
        public GetGiftCardPurchaseByIdQuery(int id)
        {
            Id = id;
        }
    }
}
