using MediatR;
using OnRoad.Application.Contracts.Locations.Responses;

namespace OnRoad.Application.Contracts.Locations.Queries;

public class ListContractsHandler : IRequestHandler<ListContractsQuery, IEnumerable<LocationResponse>>
{
    public Task<IEnumerable<LocationResponse>> Handle(ListContractsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}