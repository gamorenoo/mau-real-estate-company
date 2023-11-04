using Application.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
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
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Property> Properties => Set<Property>();

        public DbSet<Owner> Owners => Set<Owner>();

        public DbSet<PropertyImage> PropertyImages => Set<PropertyImage>();

        public DbSet<PropertyTrace> PropertyTraces => Set<PropertyTrace>();

        public DbSet<Address> Addresses => Set<Address>();

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return 0;
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
