using AutoMapper;
using GiftCardSystem.Application.Dtoes;
using GiftCardSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftCardSystem.Application.Mappings
{
    public class GiftCardTransactionProfile : Profile
    {
        public GiftCardTransactionProfile()
        {
            CreateMap<GiftCardTransaction, GiftCardTransactionDto>().ReverseMap();
        }
    }
}
