using MediatR;
using OnRoad.Application.Contracts.Locations.Queries;
using OnRoad.Application.Models.Responses;

namespace OnRoad.Application.Queries.ListContracts;

public class ListContractsHandler : IRequestHandler<ListContractsQuery, IEnumerable<LocationResponse>>
{
    public Task<IEnumerable<LocationResponse>> Handle(ListContractsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}