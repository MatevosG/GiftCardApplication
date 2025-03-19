using GiftCardSystem.Application.Contracts;
using GiftCardSystem.Domain.Entities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class GiftCardPurchaseRepository : GenericRepository<GiftCardPurchase>, IGiftCardPurchaseRepository
    {
        public GiftCardPurchaseRepository(GiftCardDbContext context) : base(context)
        {
        }
    }
}
