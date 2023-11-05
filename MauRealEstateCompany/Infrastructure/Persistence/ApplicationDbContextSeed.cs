using Domain.Addresses;
using Domain.Owners;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContextSeed
    {
        public static async Task SeedSampleDataAsync(ApplicationDbContext context) 
        {
            if (!context.Owners.Any()) {
                context.Owners.AddRange(
                    new Owner { Name = "Owner 1 Test", Birthday = DateTime.Now.AddYears(-30),Photo = "Sin Foto" },
                    new Owner { Name = "DC Comics", Birthday = DateTime.Now.AddYears(-60), Photo = "Sin Foto" },
                    new Owner { Name = "George Lucas", Birthday = DateTime.Now.AddYears(-30), Photo = "Sin Foto" },
                    new Owner { Name = "Icon Comics", Birthday = DateTime.Now.AddYears(-35), Photo = "Sin Foto" },
                    new Owner { Name = "J. K. Rowling", Birthday = DateTime.Now.AddYears(-40), Photo = "Sin Foto" },
                    new Owner { Name = "Marvel Comics", Birthday = DateTime.Now.AddYears(-50), Photo = "Sin Foto" }
                );

                await context.SaveChangesAsync();

                context.Addresses.AddRange(
                    new Address { Street = "Street 1", City = "New York", Country = "USA", State = "New York", ZipCode ="10001",OwnerId = 1 },
                    new Address { Street = "Street 2", City = "New York", Country = "USA", State = "New York", ZipCode = "10002", OwnerId = 2 },
                    new Address { Street = "Street 3", City = "New York", Country = "USA", State = "New York", ZipCode = "10003", OwnerId = 3 },
                    new Address { Street = "Street 4", City = "New York", Country = "USA", State = "New York", ZipCode = "10004", OwnerId = 4 },
                    new Address { Street = "Street 5", City = "New York", Country = "USA", State = "New York", ZipCode = "10005", OwnerId = 5 },
                    new Address { Street = "Street 6", City = "New York", Country = "USA", State = "New York", ZipCode = "10006", OwnerId = 6 }
                    );
                await context.SaveChangesAsync();
            }
        }
    }
}
