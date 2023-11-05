using Domain.Owners;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    public class OwnerConfiguration : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> builder)
        {
            builder.ToTable("Owner");

            builder.HasKey("IdOwner");

            builder.Property(p => p.RowVersion)
               .IsConcurrencyToken()
               .ValueGeneratedOnAddOrUpdate();

            builder.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.Property(e => e.Photo)
                .HasMaxLength(200)
                .IsUnicode(false);

        }
    }
}
