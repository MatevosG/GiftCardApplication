using GiftCardSystem.Application.Contracts;
using GiftCardSystem.Domain.Entities;
using GiftCardSystem.Infrastructure.Persistence;
using GiftCardSystem.Infrastructure.Repositories;

namespace GiftCardSystem.Infrastructure.Repositories
{
    public class GiftCardPurchaseRepository : GenericRepository<GiftCardPurchase>, IGiftCardPurchaseRepository
    {
        public GiftCardPurchaseRepository(GiftCardDbContext context) : base(context)
        {
        }
    }
}
