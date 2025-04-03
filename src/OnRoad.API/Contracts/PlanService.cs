using MediatR;
using OnRoad.API.Domain;
using OnRoad.API.Infrastructure;

namespace OnRoad.API.Contracts;

public class PlanService : IRequestHandler<AddPlanRequest>
{
    readonly Context _context;

    public PlanService(Context context)
    {
        _context = context;
    }

    public async Task Handle(AddPlanRequest request, CancellationToken token)
    {
        Plan plan = new(request.Description, request.Days, request.DailyValue, request.Penalty);

        _context.Set<Plan>().Add(plan);
        await _context.SaveChangesAsync(token);
    }
}

public class AddPlanRequest : IRequest
{
    public string Description { get; set; }
    public int Days { get; set; }
    public decimal DailyValue { get; set; }
    public decimal Penalty { get; set; }
}