using System.Net;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using OnRoad.Contracts.API.Domain;

namespace OnRoad.Contracts.Tests;

public class ContractTest : IClassFixture<ServerFactory>
{
    private readonly HttpClient _httpClient;
    private readonly IServiceProvider _serviceProvider;

    public ContractTest(ServerFactory factory)
    {
        _httpClient = factory.CreateClient();
        _serviceProvider = factory.Services.CreateScope().ServiceProvider;
    }
    
    [Fact]
    public async Task GetContracts_ShouldReturnContracts_WhenParamsIdValidAsync()
    {
        var mongoCollection = _serviceProvider
            .GetRequiredService<IMongoDatabase>()
            .GetCollection<Contract>("contracts");

        var contract1 = new Contract(
            customerId: Guid.NewGuid(),
            vehicleId: Guid.NewGuid(),
            startDate: DateOnly.FromDateTime(DateTime.Today)
        );

        var contract2 = new Contract(
            customerId: Guid.NewGuid(),
            vehicleId: Guid.NewGuid(),
            startDate: DateOnly.FromDateTime(DateTime.Today.AddDays(3))
        );

        var contract3 = new Contract(
            customerId: Guid.NewGuid(),
            vehicleId: Guid.NewGuid(),
            startDate: DateOnly.FromDateTime(DateTime.Today.AddDays(7))
        );

        await mongoCollection.InsertManyAsync([contract1, contract2, contract3]);
        var response = await _httpClient.GetAsync("contracts");
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}