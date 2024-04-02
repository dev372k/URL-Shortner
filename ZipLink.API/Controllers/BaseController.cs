using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Net;
using ZipLink.Infrastructure.Implementation;
using ZipLink.Infrastructure.Interfaces;

namespace ZipLink.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private readonly ILogger<BaseController> _logger;
        private readonly HealthCheckService _service;

        public BaseController(ILogger<BaseController> logger, HealthCheckService service)
        {
            _logger = logger;
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Ping()
        {
            var report = await _service.CheckHealthAsync();

            _logger.LogInformation($"Get Health Information: {report}");

            return report.Status == HealthStatus.Healthy ? Ok(report) : StatusCode((int)HttpStatusCode.ServiceUnavailable, report);
        }
    }

}
