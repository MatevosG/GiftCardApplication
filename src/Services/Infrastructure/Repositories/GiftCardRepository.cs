using GiftCardSystem.Application.Contracts;
using GiftCardSystem.Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories
{
    public class GiftCardRepository : GenericRepository<GiftCard>, IGiftCardRepository
    {
        public GiftCardRepository(GiftCardDbContext context) : base(context)
        {
        }
    }
}
