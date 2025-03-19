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
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        public AddressRepository(GiftCardDbContext context) : base(context)
        {
        }
    }
}
