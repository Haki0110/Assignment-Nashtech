using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.WebUtilities;
using System.Threading.Tasks;

namespace Assignment3.Website.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            string logMessage = $"[{DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")}] ";
            logMessage += $"Schema: {httpContext.Request.Scheme}, ";
            logMessage += $"Host: {httpContext.Request.Host}, ";
            logMessage += $"Path: {httpContext.Request.Path}, ";
            logMessage += $"QueryString: {httpContext.Request.QueryString}";

            if(httpContext.Request.ContentLength.HasValue &&  httpContext.Request.ContentLength > 0)
            {
                httpContext.Request.EnableBuffering();
                var reqBodyStr = new StreamReader(httpContext.Request.Body);
                var reqBody = await reqBodyStr.ReadToEndAsync();
                logMessage += $", RequestBody: \n{reqBody}";
                httpContext.Request.Body.Position = 0;
            }

            string filePath = "requests.txt";
            await File.AppendAllTextAsync(filePath, logMessage + Environment.NewLine);

            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggingMiddleware>();
        }
    }
}
//requestPost - API ost