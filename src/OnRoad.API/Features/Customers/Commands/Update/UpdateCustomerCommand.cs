using MediatR;

namespace OnRoad.API.Features.Customers.Update;

public record UpdateCustomerCommand(Guid Id, string FullName) : IRequest<UpdateCustomerResponse>;