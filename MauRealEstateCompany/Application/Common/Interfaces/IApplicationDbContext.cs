using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Property> Properties { get; }
        public DbSet<Owner> Owners { get; }
        public DbSet<PropertyImage> PropertyImages{ get; }
        public DbSet<PropertyTrace> PropertyTraces { get; }
        public DbSet<Address> Addresses { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
