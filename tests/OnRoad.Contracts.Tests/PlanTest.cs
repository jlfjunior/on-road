using System.Net;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using OnRoad.Contracts.API.Domain;

namespace OnRoad.Contracts.Tests;

public class PlanTest : IClassFixture<ServerFactory>
{
    private readonly HttpClient _httpClient;
    private readonly IServiceProvider _serviceProvider;

    public PlanTest(ServerFactory factory)
    {
        _httpClient = factory.CreateClient();
        _serviceProvider = factory.Services.CreateScope().ServiceProvider;
    }
    
    [Fact]
    public async Task GetPlans_ShouldReturnPlans_WhenParamsIdValidAsync()
    {
        var mongoCollection = _serviceProvider
            .GetRequiredService<IMongoDatabase>()
            .GetCollection<Plan>("plans");

        var basicPlan = new Plan(
            description: "Plano Básico",
            durationInDays: 7,
            dailyRate: 29.90m,
            extraDayRate: 39.90m,
            penaltyFee: 59.90m
        );

        var standardPlan = new Plan(
            description: "Plano Standard",
            durationInDays: 15,
            dailyRate: 24.90m,
            extraDayRate: 34.90m,
            penaltyFee: 79.90m
        );

        var premiumPlan = new Plan(
            description: "Plano Premium",
            durationInDays: 30,
            dailyRate: 19.90m,
            extraDayRate: 29.90m,
            penaltyFee: 99.90m
        );

        await mongoCollection.InsertManyAsync([basicPlan, standardPlan, premiumPlan]);
        var response = await _httpClient.GetAsync("plans");
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}