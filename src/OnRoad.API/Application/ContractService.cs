using MediatR;
using OnRoad.API.Domain;
using OnRoad.API.Infrastructure;

namespace OnRoad.API.Application;

public class ContractService : 
    IRequestHandler<AddContractRequest>,
    IRequestHandler<FinishContractRequest>
{
    readonly Context _context;

    public ContractService(Context context)
    {
        _context = context;
    }

    public async Task Handle(AddContractRequest request, CancellationToken token)
    {
        var contract = new Contract(request.CustomerId, request.VehicleId, request.StartDate);
        
        _context.Set<Contract>().Add(contract);
        
        await _context.SaveChangesAsync(token);
    }

    public async Task Handle(FinishContractRequest request, CancellationToken cancellationToken)
    {
        var contract = _context.Set<Contract>().FirstOrDefault(c => c.Id == request.Id);
        
        if (contract is null)
            throw new Exception("Contract not found");
        
        var plan = _context.Set<Plan>().FirstOrDefault(p => p.Id == contract.PlanId);
        
        if (plan is null) 
            throw new Exception("Plan not found");

        contract.Finish(request.FinishedAt, plan.DailyValue, plan.Penalty);
        
        await _context.SaveChangesAsync(cancellationToken);
    }
}

public class FinishContractRequest : IRequest
{
    public Guid Id { get; set; }
    public DateTime FinishedAt { get; set; }
}

public class AddContractRequest : IRequest
{
    public Guid CustomerId { get; set; }
    public Guid PlanId { get; set; }
    public Guid VehicleId { get; set; }
    public DateTime StartDate { get; set; }
}