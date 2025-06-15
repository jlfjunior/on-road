using System.Net;
using System.Net.Http.Json;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using OnRoad.Vehicles.API.Domain;

namespace OnRoad.Vehicles.Tests;

public class VehicleTest : IClassFixture<ServerFactory>
{
    private readonly HttpClient _httpClient;
    private readonly IServiceProvider _serviceProvider;

    public VehicleTest(ServerFactory factory)
    {
        _httpClient = factory.CreateClient();
        _serviceProvider = factory.Services.CreateScope().ServiceProvider;
    }
    
    [Fact]
    public async Task AddVehicle_ShouldAddVehicle_WhenBodyIdValidAsync()
    {
        var body = new
        {
            Model = "Ford"
        };
        var response = await _httpClient.PostAsJsonAsync("vehicles", body);
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task GetVehicle_ShouldReturnVehicles_WhenParamsIdValidAsync()
    {
        var mongoCollection = _serviceProvider
            .GetRequiredService<IMongoDatabase>()
            .GetCollection<Vehicle>("vehicles");

        var honda = new Vehicle("Honda");
        var toyota = new Vehicle("Toyota");
        await mongoCollection.InsertManyAsync([honda, toyota]);
        var response = await _httpClient.GetAsync("vehicles");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    [Fact]
    public async Task DeleteVehicle_ShouldDelete_WhenVehicleIsFoundAsync()
    {
        var mongoCollection = _serviceProvider
            .GetRequiredService<IMongoDatabase>()
            .GetCollection<Vehicle>("vehicles");

        var honda = new Vehicle("Honda");
        await mongoCollection.InsertOneAsync(honda);
        var response = await _httpClient.DeleteAsync($"vehicles/{honda.Id}");
        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    }
}