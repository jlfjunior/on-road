using OnRoad.Domain;
using OnRoad.Domain.Exceptions;

namespace OnRoad.API;

public class RequestMiddleware
{
    readonly ILogger<RequestMiddleware> _logger;
    readonly RequestDelegate _next;

    public RequestMiddleware(ILogger<RequestMiddleware> logger, RequestDelegate next)
    {
        _logger = logger;
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (DomainException ex)
        {
            _logger.LogError(ex, ex.Message);
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsync(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await context.Response.WriteAsync("An internal server error has occurred.");
        }
    }
}