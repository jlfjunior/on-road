using OnRoad.Vehicles.API;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<IVehicleService, VehicleService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.MapGet("/vehicles", async (IVehicleService service) =>
    {
        var vehicles = await service.AllAsync();
        return Results.Ok(vehicles);
    })
    .WithName("Vehicles")
    .WithName("GetVehicles");

app.MapPost("/vehicles", async (VehicleRequest request, IVehicleService service) =>
    {
        var vehicle = await service.AddAsync(request.Model);
        return Results.Ok(VehicleResponse.Map(vehicle));
    })
    .WithTags("Vehicles")
    .WithName("AddVehicle");

app.MapDelete("/vehicles/{Id}", async (Guid Id, IVehicleService service) =>
    {
        await service.DeleteAsync(Id);
        return Results.NoContent();
    })
    .WithTags("Vehicles")
    .WithName("DeleteVehicle");

app.MapGet("health", () => Results.Ok("Service is running"));

app.Run();


public partial class Program { }