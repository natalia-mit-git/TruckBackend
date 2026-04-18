using TruckBackend.Models.Exceptions;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        var response = context.Response;
        response.ContentType = "application/json";
        Console.WriteLine($"Exception caught: {ex.GetType().Name} - {ex.Message}");
        var statusCode = ex switch
        {
            TruckNotFoundException => StatusCodes.Status404NotFound,
            ValidationException => StatusCodes.Status400BadRequest,
            KeyNotFoundException => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError
        };

        response.StatusCode = statusCode;

        string message = "An error occurred.";
        if (ex is TruckNotFoundException nf)
            message = nf.UserMessage;
        else if (ex is ValidationException ve)
            message = ve.UserMessage;
        var responseObj = new
        {
            message,
            details = ex.Message
        };

        return response.WriteAsJsonAsync(responseObj);
    }
}