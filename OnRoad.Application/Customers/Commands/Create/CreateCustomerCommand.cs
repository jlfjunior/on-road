using MediatR;

namespace OnRoad.Application.Customers.Commands.Create;

public record CreateCustomerCommand(string FullName, DateOnly BirthDate, string DocumentTax) : IRequest<CreateCustomerResponse>;