using AccountSerivice.Domain.Interfaces;

namespace AccountService.Api.Middlewares;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandlerMiddleware> _logger;

    public ErrorHandlerMiddleware(RequestDelegate next, ILogger<ErrorHandlerMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            context.Response.ContentType = "application/json";

            if (ex is IDomainError error)
            {
                context.Response.StatusCode = error.Code;
                var response = new ErrorResponse(error.Message, error.Action);
                await context.Response.WriteAsJsonAsync(response);
            }
            else
            {
                _logger.LogError(ex.Message);
                context.Response.StatusCode = 500;
                var response = new ErrorResponse("Internal Server Error", "Please check the request data and try again.");
                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}

record ErrorResponse(string Message, string Action);