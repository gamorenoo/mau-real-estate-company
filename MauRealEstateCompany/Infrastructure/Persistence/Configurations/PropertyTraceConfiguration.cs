using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations
{
    public class PropertyTraceConfiguration : IEntityTypeConfiguration<PropertyTrace>
    {
        public void Configure(EntityTypeBuilder<PropertyTrace> builder)
        {
            builder.ToTable("PropertyTrace");

            builder.HasKey("IdPropertyTrace");

            builder.Property(p => p.RowVersion)
               .IsConcurrencyToken()
               .ValueGeneratedOnAddOrUpdate();

            builder.Property(e => e.Name)
                .HasMaxLength(200)
                .IsUnicode(false);

            builder.HasOne(a => a.Property).WithMany().HasForeignKey(b => b.IdProperty);
        }
    }
}
