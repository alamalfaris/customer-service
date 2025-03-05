using Microsoft.AspNetCore.Diagnostics;

namespace customer_service.Helpers
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            _logger.LogError(exception, "Request ID: {Id}; Exception occurred: {Message}", httpContext.TraceIdentifier, exception.Message);

            var response = ApiResponse<string>.Failure("Internal Server Error", StatusCodes.Status500InternalServerError, httpContext.TraceIdentifier);
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            await httpContext.Response.WriteAsJsonAsync(response, cancellationToken);

            return true;
        }
    }
}
