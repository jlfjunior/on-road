using MediatR;
using Microsoft.EntityFrameworkCore;
using OnRoad.API;
using OnRoad.API.Features.Customers.Commands.Create;
using OnRoad.API.Features.Customers.Queries.List;
using OnRoad.API.Features.Customers.Update;
using OnRoad.API.Infrastructure;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR(options => options.RegisterServicesFromAssemblyContaining<Program>());

var connectionString = builder.Configuration.GetConnectionString("CustomersDb");

builder.Services.AddDbContext<CustomerDbContext>(options => options.UseNpgsql(connectionString));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

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

var group = app.MapGroup("customers")
    .WithTags("Customers");

group.MapGet("/", async (IMediator mediator) => 
    {
        var customers = await mediator.Send(new ListCustomersQuery());
        return Results.Ok(customers);
    })
    .WithName("GetCustomers")
    .WithSummary("Retrieves a list of customers.")
    .WithDescription("Returns an empty or populated list of customers registered in the system.");

group.MapPost("/", async (IMediator mediator, CreateCustomerCommand request) =>
    {
        var validator = new CreateCustomerValidator().Validate(request);
        
        if (!validator.IsValid)
            return Results.BadRequest(validator.Errors);
        
        var response = await mediator.Send(request);
        
        return Results.Created($"/customers/{response.Id}", response);
    })
    .WithName("CreateCustomer")
    .WithSummary("Creates a new customer.")
    .WithDescription("Registers a new customer and returns it with a 201 status.");

group.MapPut("/{Id}", async (IMediator mediator, Guid Id, UpdateCustomerRequest request) =>
    {
        var enrichedRequest = new UpdateCustomerCommand(Id, request.FullName);
        
        var validator = new UpdateCustomerValidator().Validate(enrichedRequest);

        if (!validator.IsValid)
            return Results.BadRequest(validator.Errors);

        var response = await mediator.Send(enrichedRequest);

        return Results.Ok(response);
    })
    .WithName("UpdateCustomer")
    .WithSummary("Updates an existing customer.")
    .WithDescription("Updates a customer and returns the updated data with a 200 status.");

app.Run();


public partial class Program { }