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
            
            services.AddTransient(typeof(ICommandRepository<>), typeof(CommandRepository<>));
            services.AddTransient(typeof(IQueryRepository<>), typeof(QueryRepository<>));
            services.AddScoped<IPropertyQueryRepository, PropertyQueryRepository>();
            services.AddScoped<IPropertyCommandRepository, PropertyCommandRepository>();

            return services;
        }
    }
}
