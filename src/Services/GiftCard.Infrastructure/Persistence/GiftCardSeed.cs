using GiftCardSystem.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GiftCardSystem.Infrastructure.Persistence
{
    public class GiftCardSeed
    {
        public static async Task SeedAsync(GiftCardDbContext context)
        {
            if (!context.Set<Client>().Any())
            {
                var partner = context.Set<Client>().Add(new Client
                {
                    //Name = "Test",
                    //CurrencyId = "USD",
                    //SiteUrls = string.Empty,
                    //AdminUrl = string.Empty,
                    //CreatedBy = 1,
                    //LastModifiedBy = 1,
                    //CreatedDate = DateTime.UtcNow,
                    //LastModifiedDate = DateTime.UtcNow,
                    ////IsDeleted = false,
                });
                await context.SaveChangesAsync();

                //var user = context.Set<User>().Add(new User
                //{
                //    UserName = "test3",
                //    LanguageId = "en",
                //    PhoneNumber = string.Empty,
                //    CurrencyId = "USD",
                //    PartnerId = partner.Entity.Id,
                //    Email = "Test@mail.com",
                //    Password = "3cHGnZO6AHNvVaRyLJ5PTrYDtDq0+NLythweYiHqe2EwgnYRsJo0HpOH0QScSUJzGZI=",
                //    Salt = "5i6momst0faNXxTnUMrdYfN16A9uBUJQDLT1XUms8XdRflGIGqTVaJ+WxfwFnszsgtw=",
                //    CreatedBy = 1,
                //    LastModifiedBy = 1,
                //    CreatedDate = DateTime.UtcNow,
                //    LastModifiedDate = DateTime.UtcNow,
                //    IsDeleted = false,
                //});

            
            }
        }
    }
}
    