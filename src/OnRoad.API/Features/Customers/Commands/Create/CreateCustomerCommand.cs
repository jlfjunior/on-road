using MediatR;

namespace OnRoad.API.Features.Customers.Commands.Create;

public record CreateCustomerCommand(string FullName, DateOnly BirthDate, string DocumentTax) : IRequest<CreateCustomerResponse>;