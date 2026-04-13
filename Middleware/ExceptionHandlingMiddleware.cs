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
            InvalidOperationException => StatusCodes.Status400BadRequest,
            _ => StatusCodes.Status500InternalServerError
        };

        response.StatusCode = statusCode;

        var responseObj = new
        {
            message = ex is TruckNotFoundException ex1
                ? ex1.UserMessage
                : "An error occurred",

            details = ex.Message
        };

        return response.WriteAsJsonAsync(responseObj);
    }
}