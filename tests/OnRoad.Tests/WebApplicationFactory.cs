using System.Data.Common;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnRoad.Infrastructure;

namespace OnRoad.Tests;

public class CustomWebApplicationFactory<TProgram> 
    : WebApplicationFactory<TProgram> 
    where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var dbContextDescriptor = services.SingleOrDefault(
                d => d.ServiceType == 
                     typeof(IDbContextOptionsConfiguration<CustomerDbContext>));

            services.Remove(dbContextDescriptor);

            var dbConnectionDescriptor = services.SingleOrDefault(
                d => d.ServiceType ==
                     typeof(DbConnection));

            services.Remove(dbConnectionDescriptor);
            
            var tempProvider = services.BuildServiceProvider();
            var configuration = tempProvider.GetRequiredService<IConfiguration>();
            var connectionString = configuration.GetConnectionString("OnRoad");

            var builderString = new Npgsql.NpgsqlConnectionStringBuilder(connectionString)
            {
                Database = $"OnRoadTestDb_{Guid.NewGuid():N}"
            };
            
            services.AddDbContext<CustomerDbContext>(options =>
                options.UseNpgsql(builderString.ConnectionString), ServiceLifetime.Singleton);
        });

        builder.UseEnvironment("Testing");
    }
}