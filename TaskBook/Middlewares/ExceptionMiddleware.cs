using System.Net;
using TaskBook.Exceptions;
using TaskBook.Models;

namespace TaskBook.Middlewares
{
    public class ExceptionMiddleware : IMiddleware
    {
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {

                _logger.LogError($"Something went wrong");
                await HandleException(context, ex);
            }
        }

        private static Task HandleException(HttpContext context, Exception ex)
        {
            string? track="";
            int statusCode = StatusCodes.Status500InternalServerError;
            switch (ex)
            {
                case NotFoundException :
                    statusCode = StatusCodes.Status404NotFound;
                    track = ex.StackTrace;
                    break;
                case BadRequestException:
                    statusCode = StatusCodes.Status400BadRequest;
                    track = ex.StackTrace;
                    break;
                default:
                    break;
            }
            var errorResponse = new ErrorResponse()
            {
                StatusCode = statusCode,
                Response = ex.Message,
                StackTrace = track
                
            };
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            return context.Response.WriteAsync(errorResponse.ToString());
        }
    }

    //extension method

    public static class ExceptionMiddlewareExtension
    {
        public static void ConfigureExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
