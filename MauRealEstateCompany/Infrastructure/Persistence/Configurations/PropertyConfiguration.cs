using Domain.Addresses;
using Domain.Properties;
using Domain.PropertyImages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    public class PropertyConfiguration : IEntityTypeConfiguration<Property>
    {
        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.ToTable("Property");

            builder.HasKey("IdProperty");

            builder.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.CodeInternal)
                .HasMaxLength(30)
                .IsUnicode(false);

            builder.HasOne(a => a.Owner)
                .WithMany().HasForeignKey(b => b.IdOwner);
            
            builder.HasOne(a => a.Address)
                .WithOne(c => c.Property)
                .HasForeignKey<Address>(b => b.IdProperty);

        }
    }
}
