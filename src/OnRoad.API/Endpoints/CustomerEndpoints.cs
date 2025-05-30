using MediatR;
using OnRoad.Application.Commands.CreateCustomer;
using OnRoad.Application.Commands.UpdateCustomer;
using OnRoad.Application.Customers.Queries.List;

namespace OnRoad.API.Endpoints;

public static class CustomerEndpoints
{
    public static void MapCustomerEndpoints(this IEndpointRouteBuilder app)
    {
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
    }
}