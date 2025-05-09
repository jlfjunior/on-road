namespace OnRoad.Application.Models.Responses;

public record CreateCustomerResponse(Guid Id, string FullName, DateOnly BirthDate, string DocumentTax);