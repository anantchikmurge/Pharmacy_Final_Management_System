using System.Net;
using System.Text.Json;

namespace PharmacyManagementSystem.Middleware;

// Middleware that catches all unhandled exceptions
public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    //constructor
    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    // Handles request pipeline
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            // Continue processing request
            await _next(context);
        }
        catch (Exception ex)
        {
            
            await HandleExceptionAsync(context, ex);
        }
    }

    // Sends error response
    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var response = new
        {
            statusCode = context.Response.StatusCode,
            message = "Internal server error",
            details = exception.Message
        };

        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}