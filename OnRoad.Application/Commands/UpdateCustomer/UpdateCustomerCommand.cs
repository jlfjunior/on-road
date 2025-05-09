using MediatR;

namespace OnRoad.Application.Commands.UpdateCustomer;

public record UpdateCustomerCommand(Guid Id, string FullName) : IRequest<UpdateCustomerResponse>;