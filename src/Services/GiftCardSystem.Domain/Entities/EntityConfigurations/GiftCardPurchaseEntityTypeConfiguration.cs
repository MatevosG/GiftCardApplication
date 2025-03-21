using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GiftCardSystem.Domain.Entities.EntityConfigurations
{
    public class GiftCardPurchaseEntityTypeConfiguration : IEntityTypeConfiguration<GiftCardPurchase>
    {
        public void Configure(EntityTypeBuilder<GiftCardPurchase> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd().IsRequired();
            builder.HasOne(g => g.Client)
                   .WithMany(c => c.GiftCardPurchases)
                   .HasForeignKey(g => g.ClientId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(m => m.GiftCard)
                   .WithMany(x => x.GiftCardPurchases)
                   .HasForeignKey(m => m.GiftCardId);

            builder.HasMany(m => m.GiftCardTransactions)
                   .WithOne(m => m.GiftCardPurchase)
                   .HasForeignKey(m => m.GiftCardPurchaseId);

            builder.HasOne(m => m.Address)
                   .WithMany(x => x.GiftCardPurchases)
                   .HasForeignKey(m => m.AddressId);

            builder.Property(m => m.CreatedAt).IsRequired(true);
            builder.Property(m => m.UpdatedAt).IsRequired(true);
            builder.Property(m => m.ExpirationDate).IsRequired(true);
            builder.Property(m => m.AddressId).IsRequired(true);
            builder.Property(m => m.Balance).HasPrecision(18, 12).IsRequired(true);
            builder.Property(m => m.IsRedeemed).HasDefaultValue(0).IsRequired(true);
        }
    }
}
