using System.Net;
using ZipLink.API.Models;

namespace ZipLink.API.Extensions
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomMiddleware> _logger;
        private readonly IConfiguration _config;

        public CustomMiddleware(RequestDelegate next, ILogger<CustomMiddleware> logger, IConfiguration config)
        {
            _next = next;
            _logger = logger;
            _config = config;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                _logger.LogError($"Error Message: {ex}\n Error Detail: {ex.InnerException?.ToString()}");
                await context.Response.WriteAsJsonAsync(new Response()
                {
                    Status = false,
                    StatusCode = context.Response.StatusCode,
                    Message = "Internal Server Error."
                });
            }
        }
    }
}
