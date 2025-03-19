using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftCardSystem.Domain.Entities.EntityConfigurations
{
    public class GiftCardTransactionEntityTypeConfiguration : IEntityTypeConfiguration<GiftCardTransaction>
    {
        public void Configure(EntityTypeBuilder<GiftCardTransaction> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd().IsRequired();

            builder.HasOne(m => m.GiftCardPurchase)
                   .WithMany(x => x.GiftCardTransactions)
                   .HasForeignKey(m => m.GiftCardPurchaseId);
            builder.Property(m => m.CreatedAt).IsRequired(true);
            builder.Property(m => m.UpdatedAt).IsRequired(true);
            builder.Property(m => m.Type).IsRequired(true);
            builder.Property(m => m.Amount).HasPrecision(18, 12).IsRequired(true);
        }
    }
}
