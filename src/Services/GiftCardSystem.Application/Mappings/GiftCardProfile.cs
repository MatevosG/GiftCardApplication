using AutoMapper;
using GiftCardSystem.Application.Dtoes;

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
