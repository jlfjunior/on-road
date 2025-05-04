using MediatR;
using OnRoad.Features.Contracts.Plans.Responses;

namespace OnRoad.API.Features.Contracts.Plans.Queries;

public class ListPlansQuery : IRequest<IEnumerable<PlanResponse>>;