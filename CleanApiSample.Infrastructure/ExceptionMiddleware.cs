using System.Text.Json;

using CleanApiSample.Infrastructure.Data.Exceptions;
using CleanApiSample.Shared;
using CleanApiSample.Shared.Abstractions.Common;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace CleanApiSample.Infrastructure
{
    internal class ExceptionMiddleware : IMiddleware
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
            catch (NotFoundException ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                
                var json = JsonSerializer.Serialize(LogAndSerialize(context.Request, ex));
                await context.Response.WriteAsync(json);
            }
            catch (CleanApiSampleException ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status404NotFound;

                await context.Response.WriteAsync(LogAndSerialize(context.Request, ex));
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                _logger.LogError(
                    ex.GetType().Name + ": " + ex.Message +
                    "\nHost: " + context.Request.Host +
                    " | Path: " + context.Request.Path +
                    " | Method: " + context.Request.Method);


                _logger.LogError(ex.StackTrace);
                if (ex.InnerException is not null)
                {
                    _logger.LogError("Inner Message: " + ex.InnerException.Message);
                    _logger.LogError("Inner StackTrace: " + ex.InnerException.StackTrace);
                }
                var response = Response.Error<string>("An internal server error occured.");

                var json = JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(json);
            }
        }

        string LogAndSerialize(HttpRequest request, Exception ex)
        {
            _logger.LogError(
                    ex.GetType().Name + ": " + ex.Message +
                    "\nHost: " + request.Host +
                    " | Path: " + request.Path +
                    " | Method: " + request.Method);

            return JsonSerializer.Serialize(Response.Error<string>(ex.Message));
        }
    }
}
