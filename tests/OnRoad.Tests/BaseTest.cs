using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnRoad.Infrastructure;

namespace OnRoad.Tests;

public class BaseTest : IClassFixture<CustomWebApplicationFactory<Program>>, IAsyncLifetime
{
    protected readonly CustomWebApplicationFactory<Program> Factory;
    protected readonly HttpClient HttpClient;
    
    public BaseTest(CustomWebApplicationFactory<Program> factory)
    {
        Factory = factory;
        HttpClient = Factory.CreateClient();
    }

    public async Task InitializeAsync()
    {
        var database = Factory.Services.GetRequiredService<OnRoadContext>();
        await database.Database.MigrateAsync();
    }

    public async Task DisposeAsync()
    {
        var database = Factory.Services.GetRequiredService<OnRoadContext>();
        
        await database.Database.EnsureDeletedAsync();
    }
}