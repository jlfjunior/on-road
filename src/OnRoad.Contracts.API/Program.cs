using OnRoad.Contracts.API;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<IPlanService, PlanService>();
builder.Services.AddScoped<IContractService, ContractService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.MapGet("/plans", async (IPlanService service) =>
    {
        var plans = await service.AllAsync();
        
        return Results.Ok(plans);
    })
    .WithTags("Plans")
    .WithName("GetPlans");

app.MapPost("/plans", async (PlanRequest request, IPlanService service) =>
    {
        var plan = await service.AddAsync(request.Description, request.DurationInDays, request.DailyRate, request.ExtraDayRate, request.PenaltyFee);
        return Results.Ok(plan);
    })
    .WithTags("Plans")
    .WithName("AddPlan");

app.MapGet("/contracts", async (IContractService service) =>
    {
        var services = await service.AllAsync();
        
        return Results.Ok(services);
    })
    .WithTags("Contracts")
    .WithName("GetContracts");

app.MapPost("/contracts", async (ContractRequest request, IContractService service) =>
    {
        var contract = await service.AddAsync(request.CustomerId, request.VehicleId, request.StartDate);
        
        return Results.Ok(contract);
    })
    .WithTags("Contracts")
    .WithName("AddContract");

app.Run();

public partial class Program { }