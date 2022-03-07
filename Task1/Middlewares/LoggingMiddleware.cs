using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task1.Middlewares
{
    /// <summary>
    /// 2.2.3 Логгирование
    /// </summary>
    public class LoggingMiddleware : IMiddleware
    {
        protected readonly ILogger logger;

        public LoggingMiddleware(ILoggerFactory loggerFactory) => logger = loggerFactory.CreateLogger<LoggingMiddleware>();

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            Object start = new object(), end = new object();
            try
            {
                start = DateTime.Now;
                await next(context);
                end = DateTime.Now;
            }
            catch (Exception ex) { logger.LogInformation(ex.Message); }
            finally
            {
                logger.LogInformation(
                    "Request {method} {url} => {starttime}-{finaltime}",
                    context.Request?.Method,
                    context.Request?.Path.Value,
                    start, end);        
            }
        }
    }
}
