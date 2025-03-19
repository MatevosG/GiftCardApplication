using GiftCardSystem.Application.Contracts;
using GiftCardSystem.Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories
{
    public class GiftCardPurchaseRepository : GenericRepository<GiftCardPurchase>, IGiftCardPurchaseRepository
    {
        public GiftCardPurchaseRepository(GiftCardDbContext context) : base(context)
        {
        }
    }
}
