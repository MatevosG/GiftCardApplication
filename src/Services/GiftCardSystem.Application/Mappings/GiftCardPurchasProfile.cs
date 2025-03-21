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
                .ForMember(x => x.GiftCardTransactions, y => y.MapFrom(c => c.GiftCardTransactions.OrderByDescending(o=>o.Id)))
                .ForPath(x => x.GiftCard.Name, y => y.MapFrom(c => c.GiftCardName))
                .ForPath(x => x.Client.Email, y => y.MapFrom(c => c.ClientEmail));
            CreateMap<GiftCardPurchase,BuyGiftCardDto>().ReverseMap();
        }
    }
}
