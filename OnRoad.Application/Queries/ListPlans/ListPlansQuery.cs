using MediatR;
using OnRoad.Application.Models.Responses;

namespace OnRoad.API.Features.Contracts.Plans.Queries;

public class ListPlansQuery : IRequest<IEnumerable<PlanResponse>>;