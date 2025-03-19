using GiftCardSystem.Application.Contracts;
using GiftCardSystem.Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        public AddressRepository(GiftCardDbContext context) : base(context)
        {
        }
    }
}
