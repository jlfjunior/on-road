namespace OnRoad.Features.Customers.Queries.List;

public record CustomerResponse(Guid Id, string FullName, DateOnly BirthDate, string DocumentTax);