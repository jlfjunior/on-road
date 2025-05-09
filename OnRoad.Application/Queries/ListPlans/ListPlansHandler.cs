using MediatR;
using OnRoad.Application.Models.Responses;
using OnRoad.Domain.Entities;
using OnRoad.SharedKernel;

namespace OnRoad.API.Features.Contracts.Plans.Queries;

public class ListPlansHandler : IRequestHandler<ListPlansQuery, IEnumerable<PlanResponse>>
{
    readonly IRepository<Plan> _planRepository;

    public ListPlansHandler(IRepository<Plan> planRepository)
    {
        _planRepository = planRepository;
    }
    
    public async Task<IEnumerable<PlanResponse>> Handle(ListPlansQuery request, CancellationToken cancellationToken)
    {
        var plans = await _planRepository.GetAllAsync();
        var response = plans.Select(plan => new PlanResponse(plan.Id, plan.Description, plan.DurationInDays, plan.Version));
        return response;
    }
}