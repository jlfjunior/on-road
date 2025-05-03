using MediatR;

namespace OnRoad.Features.Customers.Commands.Update;

public record UpdateCustomerCommand(Guid Id, string FullName) : IRequest<UpdateCustomerResponse>;