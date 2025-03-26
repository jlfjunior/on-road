using MediatR;
using Microsoft.EntityFrameworkCore;
using OnRoad.API.Application;
using OnRoad.API.Domain;
using OnRoad.API.Infrastructure;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<PlanService>();
builder.Services.AddScoped<ContractService>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddDbContext<Context>(opt => opt.UseNpgsql("OnRoad"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.MapPost("/plans", (AddPlanRequest request, IMediator mediator) =>
    {
        mediator.Send(request);
        
        return Results.Ok();
    })
    .WithName("AddPlan")
    .WithOpenApi();

app.MapGet("/plans", async (Context context) =>
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

app.MapGet("/contracts", async(Context context) =>
    {
        var contracts = await context.Set<Contract>().ToListAsync();
        
        return Results.Ok(contracts);
    })
    .WithName("GetContract")
    .WithOpenApi();

app.Run();