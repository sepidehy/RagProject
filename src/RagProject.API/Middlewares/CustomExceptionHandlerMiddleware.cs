using RagProject.API.Exceptions;
using System.Net;

namespace RagProject.API.Middlewares
{
    public class CustomExceptionHandlerMiddleware : IMiddleware
    {
        private readonly ILogger<CustomExceptionHandlerMiddleware> _logger;

        public CustomExceptionHandlerMiddleware(ILogger<CustomExceptionHandlerMiddleware> logger)
        {
            _logger = logger;
        }


        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (AppException exception)
            {
                _logger.LogWarning(
                    exception,
                    "Application error: {Message}",
                    exception.Message);

                context.Response.StatusCode = (int)exception.StatusCode;

                await context.Response.WriteAsJsonAsync(new
                {
                    statusCode = (int)exception.StatusCode,
                    message = exception.Message
                });
            }
            catch (Exception exception)
            {
                _logger.LogError(
                    exception,
                    "An unexpected error occurred.");

                context.Response.StatusCode =
                    (int)HttpStatusCode.InternalServerError;

                await context.Response.WriteAsJsonAsync(new
                {
                    statusCode = 500,
                    message = "An unexpected error occurred."
                });
            }

        }
    }

}
