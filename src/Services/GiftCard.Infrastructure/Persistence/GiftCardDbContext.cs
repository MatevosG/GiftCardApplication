using GiftCardSystem.Domain.Entities.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GiftCardSystem.Infrastructure.Persistence
{
    public class GiftCardDbContext : DbContext
    {
        public GiftCardDbContext(DbContextOptions<GiftCardDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var entityConfigurationsAssembly = typeof(ClientEntityTypeConfiguration).GetTypeInfo().Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(entityConfigurationsAssembly);
        }
    }
}
