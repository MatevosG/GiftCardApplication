using AutoMapper;
using GiftCardSystem.Application.Dtoes;
using GiftCardSystem.Domain.Entities;

namespace GiftCardSystem.Application.Mappings
{
    public class GiftCardPurchasProfile : Profile
    {
        public GiftCardPurchasProfile()
        {
            CreateMap<GiftCardPurchase, GiftCardPurchaseDto>().ReverseMap()
                .ForMember(x => x.GiftCardTransactions, y => y.MapFrom(c => c.GiftCardTransactions));
        }
    }
}
