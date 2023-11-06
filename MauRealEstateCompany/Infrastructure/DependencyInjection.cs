using Application.Common.Interfaces;
using Infrastructure.Persistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Repositories.GenericRepository;
using Domain.Properties;
using Infrastructure.Repositories.PropertyRepository;
using Infrastructure.Repositories.GenericRepository.CommandRepository;
using Infrastructure.Repositories.GenericRepository.QueryRepository;
using Domain.Addresses;
using Infrastructure.Repositories.AddressRepository;
using Domain.PropertyImages;
using Infrastructure.Repositories.PropertyImageRepository;
using Application.Auth.Login;
using Infrastructure.Auth;
using Domain.Owners;
using Infrastructure.Repositories.OwnersRepository;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("RealStateConnection"),
                        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

            services.AddScoped<IAuthService, AuthService>();

            services.AddTransient(typeof(ICommandRepository<>), typeof(CommandRepository<>));
            services.AddTransient(typeof(IQueryRepository<>), typeof(QueryRepository<>));

            services.AddScoped<IPropertyQueryRepository, PropertyQueryRepository>();
            services.AddScoped<IPropertyCommandRepository, PropertyCommandRepository>();
            services.AddScoped<IAddressQueryRepository, AddressQueryRepository>();
            services.AddScoped<IAddressCommandRepository, AddressCommandRepository>();
            services.AddScoped<IPropertyImageCommandRepository, PropertyImageCommandRepository>();
            services.AddScoped<IOwnerQueryRepository, OwnerQueryRepository>();

            return services;
        }
    }
}
