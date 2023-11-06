using Application;
using Application.Auth.Login;
using Domain.Properties;
using Infrastructure;
using Infrastructure.Auth;
using Infrastructure.Persistence;
using Infrastructure.Repositories.GenericRepository.CommandRepository;
using Infrastructure.Repositories.GenericRepository.QueryRepository;
using Infrastructure.Repositories.PropertyRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauRealEstateCompany.ApplicationTest
{
    public class BaseTest
    {
        protected IServiceProvider serviceProvider { get; set; }
        protected ServiceCollection servicesCollection { get; set; }
        protected SqliteConnection sqliteConnection { get; set; }

        [SetUp]
        public void Setup()
        {
            servicesCollection = new ServiceCollection();
            servicesCollection.AddMvc();
            servicesCollection.AddHttpContextAccessor();
            servicesCollection.AddApplication();

            serviceProvider = servicesCollection.BuildServiceProvider();

            sqliteConnection = new SqliteConnection("DataSource=:memory:");
            sqliteConnection.Open();

            var dbContextOptionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlite(sqliteConnection);
            var options = dbContextOptionsBuilder.Options;

            var context = new ApplicationDbContext(options, serviceProvider.GetRequiredService<IHttpContextAccessor>());
            context.Database.EnsureCreated();

            servicesCollection.AddSingleton<ApplicationDbContext>(context);

            servicesCollection.AddDbContext<ApplicationDbContext>(op => { op.UseSqlite(sqliteConnection); });

            servicesCollection.AddScoped<IAuthService, AuthService>();

            servicesCollection.AddTransient(typeof(ICommandRepository<>), typeof(CommandRepository<>));
            servicesCollection.AddTransient(typeof(IQueryRepository<>), typeof(QueryRepository<>));

            servicesCollection.AddAuthenticationCore();
            servicesCollection.AddAuthorizationCore();
            servicesCollection.AddLogging();

            servicesCollection.Configure<IdentityOptions>(op =>
            {
                // Password setting
                op.Password.RequireDigit = false;
                op.Password.RequiredLength = 5;
                op.Password.RequireNonAlphanumeric = false;
                op.Password.RequireUppercase = false;
                op.Password.RequireLowercase = false;
                op.Password.RequiredUniqueChars = 3;


                // Lockout settings

                op.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                op.Lockout.MaxFailedAccessAttempts = 5;
                op.Lockout.AllowedForNewUsers = true;

                // User Settings
                op.User.RequireUniqueEmail = false;
            });

            var configurationBuilder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            var configuration = configurationBuilder.Build();

            servicesCollection.AddSingleton<IConfiguration>(configuration);

            servicesCollection.AddInfrastructure(configuration);

            serviceProvider = servicesCollection.BuildServiceProvider();

        }

        public void ResetDbContext()
        {
            serviceProvider = serviceProvider.CreateScope().ServiceProvider;
        }

        public void InitDataSql(string file)
        {
            var patch = Environment.ProcessPath;
            patch = patch.Replace("\\bin\\Debug\\net6.0\\testhost.exe", string.Format(@"\Scripts\{0}.sql", file));
            string script = File.ReadAllText(patch);
            var dbContext = serviceProvider.GetService<ApplicationDbContext>();
            dbContext.Database.ExecuteSqlRaw(script);
        }
    }
}
