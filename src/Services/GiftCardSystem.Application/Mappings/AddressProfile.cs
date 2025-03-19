using AutoMapper;
using GiftCardSystem.Application.Dtoes;
using GiftCardSystem.Domain.Entities;

namespace GiftCardSystem.Application.Mappings
{
    class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressDto>().ReverseMap();
        }
    }
}
