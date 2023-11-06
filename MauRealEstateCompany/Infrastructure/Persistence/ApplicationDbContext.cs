using Application.Common.Interfaces;
using Domain.Addresses;
using Domain.Common;
using Domain.Owners;
using Domain.Properties;
using Domain.PropertyImages;
using Domain.PropertyTraces;
using Infrastructure.Persistence.Configurations;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public DbSet<Property> Properties => Set<Property>();

        public DbSet<Owner> Owners => Set<Owner>();

        public DbSet<PropertyImage> PropertyImages => Set<PropertyImage>();

        public DbSet<PropertyTrace> PropertyTraces => Set<PropertyTrace>();

        public DbSet<Address> Addresses => Set<Address>();

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var username = _httpContextAccessor?.HttpContext?.User?.Claims.FirstOrDefault()?.Value;
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = username ?? "gustavoamoreno@outlook.com";
                        entry.Entity.Created = DateTime.UtcNow;
                        entry.Entity.RowVersion = Guid.NewGuid();
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = username ?? "gustavoamoreno@outlook.com";
                        entry.Entity.LastModified = DateTime.UtcNow;
                        entry.Entity.RowVersion = Guid.NewGuid();
                        break;
                }
            }

            var result = 0;

            try
            {
                result = await base.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Update the values of the entity that failed to save from the store (https://docs.microsoft.com/es-es/ef/ef6/saving/concurrency)
                ex.Entries.Single().Reload();
            }

            return result;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.ApplyConfiguration(new AddressConfiguration());
            modelBuilder.ApplyConfiguration(new OwnerConfiguration());
            modelBuilder.ApplyConfiguration(new PropertyConfiguration());
            modelBuilder.ApplyConfiguration(new PropertyImageConfiguration());
            modelBuilder.ApplyConfiguration(new PropertyTraceConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
