using System.Net;
using Microsoft.Extensions.DependencyInjection;

namespace OnRoad.Vehicles.Tests;

public class HealthTests : IClassFixture<ServerFactory>
{
    private readonly HttpClient _httpClient;
    private readonly IServiceProvider _serviceProvider;

    public HealthTests(ServerFactory factory)
    {
        _httpClient = factory.CreateClient();
        _serviceProvider = factory.Services.CreateScope().ServiceProvider;
    }

    [Fact]
    public async Task GetHealth_ShouldReturnHealth_WhenServiceIsRunningAsync()
    {
        var response = await _httpClient.GetAsync("health");
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}