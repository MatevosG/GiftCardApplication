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
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Client,ClientDto>().ReverseMap()
                .ForMember(x => x.GiftCardPurchases, y => y.MapFrom(c => c.GiftCardPurchases));
            CreateMap<Client, RegisterClientDto>().ReverseMap();
        }
    }
}
