using GiftCardSystem.Application.Contracts;
using GiftCardSystem.Domain.Entities;
using GiftCardSystem.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftCardSystem.Infrastructure.Repositories
{
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        public ClientRepository(GiftCardDbContext context) : base(context)
        {
        }
    }
}
