using MediatR;
using OnRoad.API.Features.Contracts.Plans.Queries;
using OnRoad.Application.Contracts.Plans.Commands.Create;
using OnRoad.Application.Contracts.Plans.Commands.Update;

namespace OnRoad.API.Endpoints;

public static class PlanEndpoints
{
    public static void MapPlanEndpoins(this IEndpointRouteBuilder endpoints)
    {
        var group = endpoints.MapGroup("/plans")
            .WithTags("Plans");

        group.MapGet("/", async (IMediator mediator) =>
            {
                var result = await mediator.Send(new ListPlansQuery());
                return Results.Ok(result);
            })
            .WithSummary("List all plans")
            .WithDescription("Retrieves all available plans.");

        group.MapPost("/", async (IMediator mediator, CreatePlanCommand command) =>
            {
                var result = await mediator.Send(command);
                return Results.Created($"/plans/{result.Id}", result);
            })
            .WithSummary("Create a new plan")
            .WithDescription("Creates a new plan with the given configuration.");
        
        group.MapPut("/{Id}", async (IMediator mediator, Guid Id, UpdatePlanCommand command) =>
            {
                var x = command with { Id = Id };
                var result = await mediator.Send(x);
                return Results.Created($"/plans/{result.Id}", result);
            })
            .WithSummary("Update a plan")
            .WithDescription("Update a plan with the given configuration.");
    }
}
