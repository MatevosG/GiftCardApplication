using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GiftCardSystem.Domain.Entities.EntityConfigurations
{
    public class AddressEntityTypeConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).ValueGeneratedOnAdd().IsRequired();

            builder.HasOne(m => m.Client)
                   .WithMany(x => x.Addresses)
                   .HasForeignKey(m => m.ClientId);

            builder.HasMany(m => m.GiftCardPurchases)
                   .WithOne(x => x.Address)
                   .HasForeignKey(m => m.AddressId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.Property(m => m.CreatedAt).IsRequired(true);
            builder.Property(m => m.UpdatedAt).IsRequired(true);
            builder.Property(m => m.City).IsRequired(true).HasMaxLength(100);
            builder.Property(m => m.Country).IsRequired(true).HasMaxLength(100);
            builder.Property(m => m.PostalCode).IsRequired(false).HasMaxLength(20);
            builder.Property(m => m.Street).IsRequired(true).HasMaxLength(100);
            builder.Property(m => m.IsDeleted).HasDefaultValue(0).IsRequired(true);
        }
    }
}
