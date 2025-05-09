using MediatR;
using OnRoad.Application.Models.Responses;

namespace OnRoad.Application.Commands.CreateCustomer;

public record CreateCustomerCommand(string FullName, DateOnly BirthDate, string DocumentTax) : IRequest<CreateCustomerResponse>;