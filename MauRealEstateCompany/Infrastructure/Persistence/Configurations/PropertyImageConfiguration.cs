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
    public class PropertyImageConfiguration : IEntityTypeConfiguration<PropertyImage>
    {
        public void Configure(EntityTypeBuilder<PropertyImage> builder)
        {
            builder.ToTable("PropertyImage");

            builder.HasKey("IdPropertyImage");

            builder.Property(p => p.RowVersion)
               .IsConcurrencyToken()
               .ValueGeneratedOnAddOrUpdate();

            builder.Property(e => e.File)
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.HasOne(a => a.Property).WithMany().HasForeignKey(b => b.IdProperty);
        }
    }
}
