using MediatR;
using OnRoad.API.Features.Vehicles.Queries.List;
using OnRoad.Application.Commands.CreateVehicle;
using OnRoad.Application.Commands.DeleteVehicle;

namespace OnRoad.API.Endpoints;

public static class VehicleEndpoints
{
    public static void MapVehicleEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("vehicles")
            .WithTags("Vehicles");

        group.MapGet("/", async (IMediator mediator) =>
        {
            var response = await mediator.Send(new ListVehiclesQuery());
            
            return Results.Ok(response);
        })
            .WithName("ListVehicles")
            .WithSummary("Retrieves a list of vehicles.")
            .WithDescription("Returns an empty or populated list of vehicles registered in the system.");

        group.MapPost("/", async (IMediator mediator, CreateVehicleCommand request) =>
        {
            var response = await mediator.Send(request);
            
            return Results.Created($"/vehicles/{response.Id}", response);
        
        })
            .WithName("CreateVehicle")
            .WithSummary("Creates a new vehicle.")
            .WithDescription("Registers a new vehicle and returns it with a 201 status.");
        
        group.MapDelete("/{Id}", async (IMediator mediator, Guid Id) =>
            {
                await mediator.Send(new DeleteVehicleCommand(Id));
            
                return Results.NoContent();

            })
            .WithName("DeleteVehicle")
            .WithSummary("Delete a vehicle.")
            .WithDescription("Removes a vehicle.");
    }
}