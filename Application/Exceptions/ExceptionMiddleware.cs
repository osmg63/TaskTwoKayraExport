using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Application.Exceptions
{
    public class ExceptionMiddleware : IMiddleware
    {
        public readonly ILogger<ExceptionMiddleware> _logger;

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
               _logger.LogError(ex.ToString());
                await HandleExceptionAync(context, ex);

            }
        }

        private static Task HandleExceptionAync(HttpContext context, Exception ex)
        {
            int statusCode = ExceptionStatusCodeMapper.GetStatusCode(ex);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;

            List<string> errors = new()
            {
                ex.Message,
                $"{ex.InnerException?.ToString()}"
            };

            return context.Response.WriteAsync(new ExceptionModel
            {
                Errors = errors,
                StatusCode = statusCode

            }.ToString());
        }
    }


}
