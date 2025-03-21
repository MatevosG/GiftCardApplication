using GiftCardSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class GiftCardSeed
    {
        public static async Task SeedAsync(GiftCardDbContext context)
        {
            if (!context.Set<Client>().Any() && !context.Set<GiftCardSystem.Domain.Entities.GiftCard>().Any())
            {
                var client = context.Set<Client>().Add(new Client
                {
                    Email = "test@gmail.com",
                    Addresses = new List<Address> { new Address { Street = "1234 Main St", City = "Yerevan", Country = "Armenia", PostalCode = "0020" } },
                    CreatedAt = DateTime.UtcNow,
                    FirstName = "Test",
                    LastName = "Testyan",
                    PhoneNumber = "+374 454545",
                    UpdatedAt = DateTime.UtcNow,
                    Password = "3cHGnZO6AHNvVaRyLJ5PTrYDtDq0+NLythweYiHqe2EwgnYRsJo0HpOH0QScSUJzGZI=", //test
                    Salt = "5i6momst0faNXxTnUMrdYfN16A9uBUJQDLT1XUms8XdRflGIGqTVaJ+WxfwFnszsgtw=",
                });

                var giftCard = context.Set<GiftCardSystem.Domain.Entities.GiftCard>().Add(new GiftCardSystem.Domain.Entities.GiftCard
                {
                    Name = "Test Gift Card",
                    Description = "Test Gift Card Description",
                    Amount = 100,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    Code = "1234567890",
                    ExpirationMonthPeriod = 3,
                });

                await context.SaveChangesAsync();
            }
        }
    }
}

