using System.Net.Http.Json;
using Microsoft.Extensions.DependencyInjection;
using OnRoad.API.Features.Contracts.Locations.Commands.Create;
using OnRoad.API.Features.Contracts.Locations.Responses;
using OnRoad.Domain.Entities;
using OnRoad.Infrastructure.Repositories;

namespace OnRoad.Tests.Locations;

public class CreateLocationTest : BaseTest
{
    public CreateLocationTest(CustomWebApplicationFactory<Program> factory) 
        : base(factory) 
            { }

    [Fact]
    public async Task CreateLocation_SuccessfullyAsync()
    {
        var planRepository = Factory.Services.GetRequiredService<IPlanRepository>();
        var vehicleRepository = Factory.Services.GetRequiredService<IRepository<Vehicle>>();
        var customerRepository = Factory.Services.GetRequiredService<IRepository<Customer>>();
        
        var plan = new Plan("Seven Days", 7, 20, 20, 20);
        var vehicle = new Vehicle("Honda");
        var customer = new Customer("Jose", "123", new DateOnly(2025, 01, 01));
        
        await planRepository.StoreAsync(plan);
        await vehicleRepository.StoreAsync(vehicle);
        await customerRepository.StoreAsync(customer);
        
        var command = new CreateLocationCommand(customer.Id, vehicle.Id, plan.Id, DateOnly.FromDateTime(DateTime.UtcNow));
        
        var response = await HttpClient.PostAsJsonAsync("/locations", command);
        var location = await response.Content.ReadFromJsonAsync<LocationResponse>();
        
        Assert.NotNull(location);
    }
}