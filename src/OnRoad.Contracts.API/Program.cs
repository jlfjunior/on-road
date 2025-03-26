using MediatR;
using Microsoft.EntityFrameworkCore;
using OnRoad.Contracts.API.Application;
using OnRoad.Contracts.API.Domain;
using OnRoad.Contracts.API.Infrastructure;
using Plan = OnRoad.Contracts.API.Domain.Plan;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<PlanService>();
builder.Services.AddScoped<ContractService>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddDbContext<ContractsDbContext>(opt => opt.UseNpgsql("EventStore"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapPost("/plans", (AddPlanRequest request, IMediator mediator) =>
    {
        mediator.Send(request);
        
        return Results.Ok();
    })
    .WithName("AddPlan")
    .WithOpenApi();

app.MapGet("/plans", async (ContractsDbContext context) =>
    {
        var plans = await context.Set<Plan>().ToListAsync();

        return Results.Ok(plans);
    })
    .WithName("GetPlans")
    .WithOpenApi();

app.MapPost("/contracts", (AddContractRequest request, IMediator mediator) =>
    {
        mediator.Send(request);
        
        return Results.Ok();
    })
    .WithName("AddContract")
    .WithOpenApi();

app.MapPost("/contracts{id}/finish", (FinishContractRequest request, IMediator mediator) =>
    {
        mediator.Send(request);
        
        return Results.Ok();
    })
    .WithName("FinishContract")
    .WithOpenApi();

app.MapGet("/contracts", async(ContractsDbContext context) =>
    {
        var contracts = await context.Set<Contract>().ToListAsync();
        
        return Results.Ok(contracts);
    })
    .WithName("GetContract")
    .WithOpenApi();

app.Run();