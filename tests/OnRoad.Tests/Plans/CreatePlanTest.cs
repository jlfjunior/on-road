using System.Net.Http.Json;
using Bogus;
using OnRoad.API.Features.Contracts.Plans.Commands.Create;
using OnRoad.API.Features.Contracts.Plans.Responses;

namespace OnRoad.Tests.Plans;

public class CreatePlanTest : BaseTest
{
    public CreatePlanTest(CustomWebApplicationFactory<Program> factory) 
        : base(factory) { }

    [Fact]
    public async Task CreatePlan_SuccessfullyAsync()
    {
        var command = new Faker<CreatePlanCommand>()
            .CustomInstantiator(faker => new CreatePlanCommand(
                Description: faker.Lorem.Text(),
                DurationInDays: faker.Random.Int(1, 100),
                DailyRate: faker.Random.Decimal(1, 100),
                ExtraDayRate: faker.Random.Decimal(1, 100),
                PenaltyFee: faker.Random.Decimal(1, 100))
            ).Generate();
        
        var response = await HttpClient.PostAsJsonAsync("/plans", command);
        var plan = await response.Content.ReadFromJsonAsync<PlanResponse>();
        
        Assert.NotNull(plan);
        Assert.Equal(command.Description, plan.Description);
        Assert.Equal(1, plan.Version);
    }
}