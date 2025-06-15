using System.Net;
using System.Net.Http.Json;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using OnRoad.Customers.API.Domain;

namespace OnRoad.Customers.Tests;

public class CustomerTest : IClassFixture<ServerFactory>
{
    private readonly HttpClient _httpClient;
    private readonly IServiceProvider _serviceProvider;

    public CustomerTest(ServerFactory factory)
    {
        _httpClient = factory.CreateClient();
        _serviceProvider = factory.Services.CreateScope().ServiceProvider;
    }
    
    [Fact]
    public async Task AddCustomer_ShouldAddCustomer_WhenBodyIdValidAsync()
    {
        var body = new
        {
            FullName = "Tom Ford"
        };
        var response = await _httpClient.PostAsJsonAsync("customers", body);
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task GetCustomers_ShouldReturnCustomers_WhenParamsIdValidAsync()
    {
        var mongoCollection = _serviceProvider
            .GetRequiredService<IMongoDatabase>()
            .GetCollection<Customer>("vehicles");

        var tom = new Customer("Tom Ford", "", new DateOnly(2025, 01, 01));
        var bob = new Customer("Bob For", "", new DateOnly(2024, 01, 01));
        await mongoCollection.InsertManyAsync([tom, bob]);
        var response = await _httpClient.GetAsync("customers");
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
    
    [Fact]
    public async Task DeleteCustomer_ShouldDelete_WhenVehicleIsFoundAsync()
    {
        var mongoCollection = _serviceProvider
            .GetRequiredService<IMongoDatabase>()
            .GetCollection<Customer>("customers");

        var tom = new Customer("Tom Ford", "", new DateOnly(2025, 01, 01));
        await mongoCollection.InsertOneAsync(tom);
        var response = await _httpClient.DeleteAsync($"customers/{tom.Id}");
        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    }
}