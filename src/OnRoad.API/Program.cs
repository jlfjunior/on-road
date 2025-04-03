using MediatR;
using Microsoft.EntityFrameworkCore;
using OnRoad.API.Contracts;
using OnRoad.API.Customers;
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

app.MapCustomerEndpoints();
app.Run();