using System.Net;
using System.Net.Http.Json;
using Microsoft.Extensions.DependencyInjection;
using OnRoad.Domain;
using OnRoad.Domain.Entities;
using OnRoad.Features.Contracts.Locations.Commands.Finish;
using OnRoad.SharedKernel;

namespace OnRoad.Tests.Locations;

public class FinishLocationTest : BaseTest
{
    public FinishLocationTest(CustomWebApplicationFactory<Program> factory) 
        : base(factory) 
            { }

    [Fact]
    public async Task FinishLocation_SuccessfullyAsync()
    {
        var planRepository = Factory.Services.GetRequiredService<IPlanRepository>();
        var vehicleRepository = Factory.Services.GetRequiredService<IRepository<Vehicle>>();
        var customerRepository = Factory.Services.GetRequiredService<IRepository<Customer>>();
        var locationRepository = Factory.Services.GetRequiredService<IRepository<Location>>();
        
        var plan = new Plan("Seven Days", 7, 20, 20, 20);
        var vehicle = new Vehicle("Honda");
        var customer = new Customer("Jose", "123", new DateOnly(2025, 01, 01));

        var startDate = DateOnly.Parse("2025, 01, 01");
        var location = new Location(customer.Id, vehicle.Id, startDate);
        location.WithPlan(plan.Id, plan.Version, plan.DurationInDays, plan.DailyRate);
        
        await planRepository.StoreAsync(plan);
        await vehicleRepository.StoreAsync(vehicle);
        await customerRepository.StoreAsync(customer);
        await locationRepository.StoreAsync(location);
        
        var command = new FinishLocationCommand(location.Id, startDate.AddDays(plan.DurationInDays));
        
        var response = await HttpClient.PostAsJsonAsync($"/locations/{location.Id}/finish", command);
        
        Assert.NotNull(location);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}