using Domain.Addresses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    public class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("Address");

            builder.HasKey("IdAddres");

            builder.Property(e => e.Street)
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.State)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Country)
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.ZipCode)
                .HasMaxLength(10)
                .IsUnicode(false);

            builder.Property(e => e.OwnerId).IsRequired(false);
            builder.Property(e => e.IdProperty).IsRequired(false);

            builder.HasOne(a => a.Owner).WithOne().HasForeignKey<Address>(b => b.OwnerId);
            builder.HasOne(a => a.Property).WithOne().HasForeignKey<Address>(b => b.IdProperty);

        }
    }
}
