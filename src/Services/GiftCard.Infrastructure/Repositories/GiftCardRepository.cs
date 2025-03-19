using GiftCardSystem.Application.Contracts;
using GiftCardSystem.Infrastructure.Persistence;

namespace GiftCardSystem.Infrastructure.Repositories
{
    public class GiftCardRepository : GenericRepository<Domain.Entities.GiftCard>, IGiftCardRepository
    {
        public GiftCardRepository(GiftCardDbContext context) : base(context)
        {
        }
    }
}
