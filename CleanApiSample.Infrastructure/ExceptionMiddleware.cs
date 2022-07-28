using System.Text.Json;

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
            catch(Exception ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = 400;
                var response = Response.Error<string>(ex.Message);

                _logger.LogError(
                    ex.GetType().Name + ": " + ex.Message +
                    "\nHost: " + context.Request.Host +
                    " | Path: " + context.Request.Path + 
                    " | Method: " + context.Request.Method);

                if (ex is not CleanApiSampleException)
                {
                    context.Response.StatusCode = 500;

                    _logger.LogError(ex.StackTrace);
                    if (ex.InnerException is not null)
                    {
                        _logger.LogError("Inner Message: " + ex.InnerException.Message);
                        _logger.LogError("Inner Stacktrace: " + ex.InnerException.StackTrace);
                    }
                    response = Response.Error<string>("An internal server error occured.");
                }

                var json = JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(json);
            }
        }
    }
}
