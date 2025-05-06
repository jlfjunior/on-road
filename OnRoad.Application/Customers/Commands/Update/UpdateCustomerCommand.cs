using MediatR;

namespace OnRoad.Application.Customers.Commands.Update;

public record UpdateCustomerCommand(Guid Id, string FullName) : IRequest<UpdateCustomerResponse>;