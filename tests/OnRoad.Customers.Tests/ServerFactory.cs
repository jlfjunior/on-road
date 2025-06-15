using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Mongo2Go;
using MongoDB.Driver;

namespace OnRoad.Customers.Tests;

public class ServerFactory : WebApplicationFactory<Program>
{
    private readonly MongoDbRunner _mongoRunner;

    public ServerFactory() => _mongoRunner = MongoDbRunner.Start();

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Development");
        builder.ConfigureServices(services =>
        {
            var mongoClient = new MongoClient(_mongoRunner.ConnectionString);
            services.AddSingleton<IMongoClient>(mongoClient);
            services.AddScoped(sp =>
            {
                var client = sp.GetRequiredService<IMongoClient>();
                return client.GetDatabase("integration-tests-db");
            });
        });

    }
}