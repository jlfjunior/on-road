using System.Net.Http.Json;
using Bogus;
using Microsoft.Extensions.DependencyInjection;
using OnRoad.API.Features.Contracts.Plans.Responses;
using OnRoad.Domain.Entities;
using OnRoad.Infrastructure.Repositories;

namespace OnRoad.Tests.Plans;

public class ListPlansTest : BaseTest
{
    public ListPlansTest(CustomWebApplicationFactory<Program> factory) 
        : base(factory) 
            { }

    [Fact]
    public async Task ShouldListPlans_SuccessfullyAsync()
    {
        var planRepository = Factory.Services.GetRequiredService<IPlanRepository>();

        var fakerPlans = new Faker<Plan>()
            .CustomInstantiator(faker => 
                new Plan(faker.Lorem.Text(), 
                    faker.Random.Number(100), 
                    faker.Random.Decimal(),
                    faker.Random.Decimal(),
                    faker.Random.Decimal()))
            .Generate(3);
        
        foreach (var plan in fakerPlans)
            await planRepository.StoreAsync(plan);
        
        var response = await HttpClient.GetAsync("/plans");
        
        var plans = await response.Content.ReadFromJsonAsync<List<PlanResponse>>();
        
        Assert.Equal(3, plans.Count);
        
    }
}