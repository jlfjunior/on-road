using MediatR;
using OnRoad.Application.Commands.CreateLocation;
using OnRoad.Application.Commands.FinishLocation;
using OnRoad.Application.Contracts.Locations.Queries;

namespace OnRoad.API.Endpoints;

public static class LocationsEndpoints
{
    public static void MapLocationEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/locations")
            .WithTags("Locations");

        group.MapGet("/", async (IMediator mediator) =>
            {
                var response = await mediator.Send(new ListContractsQuery());
                return Results.Ok(response);
            })
            .WithSummary("Get all contracts")
            .WithDescription("Lists all contracts");

        group.MapPost("/", async (IMediator mediator, CreateLocationCommand command) =>
            {
                var result = await mediator.Send(command);
                return Results.Created($"/locations/{result.Id}", result);
            })
            .WithSummary("Create a contract")
            .WithDescription("Adds a new contract.");

        group.MapPost("/{Id}/finish", async (IMediator mediator, Guid Id, FinishLocationCommand request) =>
            {
                var command = request with { Id = Id };
                var result = await mediator.Send(command);
                return Results.Ok(result);
            })
            .WithSummary("Finish contract")
            .WithDescription("Marks the contract as finished.");
    }
}