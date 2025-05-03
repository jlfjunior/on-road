using Microsoft.EntityFrameworkCore;
using OnRoad.API;
using OnRoad.API.Endpoints;
using OnRoad.API.Infrastructure;
using OnRoad.Features;
using OnRoad.Infrastructure;
using OnRoad.Infrastructure.Repositories;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR(options => options.RegisterServicesFromAssemblyContaining<IFeatureAssembly>());

var connectionString = builder.Configuration.GetConnectionString("OnRoad");

builder.Services.AddDbContext<CustomerDbContext>(options => options.UseNpgsql(connectionString));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IPlanRepository, PlanRepository>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseMiddleware<RequestMiddleware>();

app.UseHttpsRedirection();

app.MapCustomerEndpoints();
app.MapVehicleEndpoints();
app.MapLocationEndpoints();
app.MapPlanEndpoins();

app.Run();


public partial class Program { }