using System.Net.Http.Json;
using Bogus;
using OnRoad.Application.Vehicles.Commands.Create;
using OnRoad.Application.Vehicles.Responses;

namespace OnRoad.Tests.Vehicles;

public class CreateVehicleTest : BaseTest
{
    public CreateVehicleTest(CustomWebApplicationFactory<Program> factory) 
        : base(factory)
            { }

    [Fact]
    public async Task CreateVehicle_SuccessfullyAsync()
    {
        var command = new Faker<CreateVehicleCommand>()
            .CustomInstantiator(f => new CreateVehicleCommand(f.Vehicle.Model()))
            .Generate();
        
        var response = await HttpClient.PostAsJsonAsync("/vehicles", command);

        response.EnsureSuccessStatusCode();
        var vehicle = await response.Content.ReadFromJsonAsync<VehicleResponse>();
        
        Assert.Equal(201, (int)response.StatusCode);
        Assert.NotNull(vehicle);
        Assert.Equal(command.Model, vehicle.Model);
    }
}