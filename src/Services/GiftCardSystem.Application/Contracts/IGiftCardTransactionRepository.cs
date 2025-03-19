using GiftCardSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftCardSystem.Application.Contracts
{
    public interface IGiftCardTransactionRepository : IGenericRepository<GiftCardTransaction>
    {
    }
}
