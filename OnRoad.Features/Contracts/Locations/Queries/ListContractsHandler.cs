using MediatR;
using OnRoad.Features.Contracts.Locations.Responses;

namespace OnRoad.Features.Contracts.Locations.Queries;

public class ListContractsHandler : IRequestHandler<ListContractsQuery, IEnumerable<LocationResponse>>
{
    public Task<IEnumerable<LocationResponse>> Handle(ListContractsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}