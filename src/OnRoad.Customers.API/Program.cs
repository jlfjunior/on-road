using OnRoad.Customers.API;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<ICustomerService, CustomerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.MapGet("/customers", async (ICustomerService service) =>
    {
        var customers = await service.AllAsync();
        return Results.Ok(customers);
    })
    .WithName("Customers")
    .WithName("GetCustomers");

app.MapPost("/customers", async (CustomerRequest request, ICustomerService service) =>
    {
        var customer = await service.AddAsync(request.FullName, request.DocumentTax, request.BirthDate);
        return Results.Ok(CustomerResponse.Map(customer));
    })
    .WithTags("Customers")
    .WithName("AddCustomer");

app.MapDelete("/customers/{Id}", async (Guid Id, ICustomerService service) =>
    {
        await service.DeleteAsync(Id);
        return Results.NoContent();
    })
    .WithTags("Customers")
    .WithName("DeleteCustomer");

app.Run();

public partial class Program { }