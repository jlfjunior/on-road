using System.Net;
using Bogus;
using Microsoft.Extensions.DependencyInjection;
using OnRoad.Domain.Entities;
using OnRoad.SharedKernel;

namespace OnRoad.Tests.Vehicles;

public class DeleteVehicleTest : BaseTest
{
    public DeleteVehicleTest(CustomWebApplicationFactory<Program> factory) 
        : base(factory)
            { }

    [Fact]
    public async Task DeleteVehicle_SuccessfullyAsync()
    {
        var repository = Factory.Services.GetRequiredService<IRepository<Vehicle>>();
        
        var vehicle = new Faker<Vehicle>()
            .CustomInstantiator(f => new Vehicle(f.Vehicle.Model()))
            .Generate();
        
        await repository.StoreAsync(vehicle);
        
        var response = await HttpClient.DeleteAsync($"/vehicles/{vehicle.Id}");

        Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
    }
}