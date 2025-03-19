using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GiftCardSystem.Domain.Entities.EntityConfigurations
{
    public class ClientEntityTypeConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(m => m.Id);

            builder.HasMany(m => m.Addresses)
                   .WithOne(x=>x.Client)
                   .HasForeignKey(m => m.ClientId);

            builder.HasMany(m => m.GiftCardPurchases)
                   .WithOne(m => m.Client)
                   .HasForeignKey(m => m.ClientId);

            builder.Property(m => m.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(m => m.CreatedAt).IsRequired(true);
            builder.Property(m => m.UpdatedAt).IsRequired(true);

            builder.Property(m => m.Email).IsRequired(true).HasMaxLength(100);
            builder.Property(m => m.FirstName).IsRequired(true).HasMaxLength(50);
            builder.Property(m => m.LastName).IsRequired(true).HasMaxLength(100);
            builder.Property(m => m.PhoneNumber).IsRequired(false).HasMaxLength(70);
            builder.Property(m => m.Salt).HasMaxLength(200).IsUnicode(true).IsRequired(true);
            builder.Property(m => m.Password).IsRequired(true).HasMaxLength(200);
        }
    }
}
