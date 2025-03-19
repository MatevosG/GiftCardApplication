using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GiftCardSystem.Domain.Entities.EntityConfigurations
{
    public class GiftCardEntityTypeCofiguration : IEntityTypeConfiguration<GiftCard>
    {
        public void Configure(EntityTypeBuilder<GiftCard> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();

            builder.HasMany(x=>x.GiftCardPurchases)
                   .WithOne(x => x.GiftCard)
                   .HasForeignKey(x => x.GiftCardId);

            builder.Property(x => x.CreatedAt).IsRequired(true);
            builder.Property(x => x.UpdatedAt).IsRequired(true);
            builder.Property(x => x.Amount).HasPrecision(18,12).IsRequired(true);
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired(true);
            builder.Property(x => x.Description).HasMaxLength(500).IsRequired(true);
            builder.Property(x => x.Code).HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.ExpirationMonthPeriod).IsRequired(true);
        }
    }
}
