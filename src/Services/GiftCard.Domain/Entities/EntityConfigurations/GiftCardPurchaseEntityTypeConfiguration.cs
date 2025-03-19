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
            builder.HasOne(m => m.Client)
                   .WithMany(x => x.GiftCardPurchases)
                   .HasForeignKey(m => m.ClientId);

            builder.HasOne(m => m.GiftCard)
                   .WithMany(x => x.GiftCardPurchases)
                   .HasForeignKey(m => m.GiftCardId);

            builder.Property(m => m.CreatedAt).IsRequired(true);
            builder.Property(m => m.UpdatedAt).IsRequired(true);
            builder.Property(m => m.Balance).HasPrecision(18, 12).IsRequired(true);
            builder.Property(m=>m.IsRedeemed).HasAnnotation("DefaultValue", false).IsRequired(true);
        }
    }
}
