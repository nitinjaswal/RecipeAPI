using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using RecipeAPI.Errors;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace RecipeAPI.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        readonly ILogger<ExceptionMiddleware> _logger;
        readonly IHostEnvironment _env;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger,
          IHostEnvironment env)
        {
            _env = env;
            _logger = logger;
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
                _logger.LogError(ex, ex.Message);
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = _env.IsDevelopment()
                                ? new ApiException(context.Response.StatusCode, ex.Message, ex.StackTrace?.ToString())
                                : new ApiException(context.Response.StatusCode, "Internal server error");

                var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

                var json = JsonSerializer.Serialize(response, options);

                await context.Response.WriteAsync(json);
            }
        }
    }

    //// Extension method used to add the middleware to the HTTP request pipeline.
    //public static class ExceptionMiddlewareExtensions
    //{
    //    public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
    //    {
    //        return builder.UseMiddleware<ExceptionMiddleware>();
    //    }
    //}
}
