using GiftCardSystem.Application.Contracts;
using Infrastructure.Persistence;


namespace Infrastructure.Repositories
{
    public class GiftCardRepository : GenericRepository<GiftCardSystem.Domain.Entities.GiftCard>, IGiftCardRepository
    {
        public GiftCardRepository(GiftCardDbContext context) : base(context)
        {
        }
    }
}
