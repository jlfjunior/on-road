using System.Net.Http.Json;
using Bogus;
using Microsoft.Extensions.DependencyInjection;
using OnRoad.Domain;
using OnRoad.Domain.Entities;
using OnRoad.Features.Contracts.Plans.Commands.Update;
using OnRoad.Features.Contracts.Plans.Responses;

namespace OnRoad.Tests.Plans;

public class UpdatePlanTest : BaseTest
{
    public UpdatePlanTest(CustomWebApplicationFactory<Program> factory) 
        : base(factory)
            { }

    [Fact]
    public async Task UpdatePlan_SuccessfullyAsync()
    {
        var planRepository = Factory.Services.GetRequiredService<IPlanRepository>();
        var plan = new Faker<Plan>()
            .CustomInstantiator(faker => 
                new Plan(faker.Lorem.Text(), 
                    faker.Random.Number(100), 
                    faker.Random.Decimal(),
                    faker.Random.Decimal(),
                    faker.Random.Decimal()))
            .Generate();

        await planRepository.StoreAsync(plan);
        
        var command = new UpdatePlanCommand(plan.Id, 20, 20,20);
        
        var response = await HttpClient.PutAsJsonAsync($"plans/{plan.Id}", command);
        var planResponse = await response.Content.ReadFromJsonAsync<PlanResponse>();
        
        var plans = await planRepository.GetAllAsync(p => p.Id == plan.Id);
        
        Assert.Equal(2, plans.Count());
        
        Assert.Equal(plan.Id, planResponse.Id);
        Assert.Equal(plan.Description, planResponse.Description);
        Assert.Equal(plan.DurationInDays, planResponse.DurationInDays);
        Assert.Equal(2, planResponse.Version);
    }
}