using GiftCardSystem.Application.Contracts;
using GiftCardSystem.Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories
{
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        public ClientRepository(GiftCardDbContext context) : base(context)
        {
        }
    }
}
