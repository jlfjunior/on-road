using System.Net;
using System.Net.Http.Json;
using Bogus;
using Microsoft.Extensions.DependencyInjection;
using OnRoad.Domain.Entities;
using OnRoad.Features.Customers.Queries.List;
using OnRoad.SharedKernel;

namespace OnRoad.Tests.Vehicles;

public class ListVehiclesTest : BaseTest
{
    public ListVehiclesTest(CustomWebApplicationFactory<Program> factory) 
        : base(factory)
    {
    }
    
    [Fact]
    public async Task ListVehicles_SuccessfullyAsync()
    {
        var repository = Factory.Services.GetRequiredService<IRepository<Vehicle>>();

        var faker = new Faker<Vehicle>()
            .CustomInstantiator(v 
                => new Vehicle(v.Vehicle.Model())
            ).Generate(3);

        foreach (var vehicle in faker)
            await repository.StoreAsync(vehicle);
        
        var response = await HttpClient.GetAsync("/vehicles");
        var vehicles = await response.Content.ReadFromJsonAsync<List<CustomerResponse>>();
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(3, vehicles.Count);
    }
}