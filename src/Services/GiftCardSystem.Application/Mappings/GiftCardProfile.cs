using AutoMapper;
using GiftCardSystem.Application.Dtoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftCardSystem.Application.Mappings
{
    public class GiftCardProfile : Profile
    {
        public GiftCardProfile()
        {
            CreateMap<Domain.Entities.GiftCard, GiftCardDto>().ReverseMap();
        }
    }
}
