namespace OnRoad.API.Domain;

public class DomainException : Exception
{
    public DomainException(string message) 
        : base(message)
            { }
}