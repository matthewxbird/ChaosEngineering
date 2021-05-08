using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ChaosHost.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChaosHostController : ControllerBase
    {
        private readonly ILogger<ChaosHostController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public ChaosHostController(ILogger<ChaosHostController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Get");

            using (var httpClient = _httpClientFactory.CreateClient("ThirdPartyApi"))
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "weatherforecast");
                var httpResponseMessage = await httpClient.SendAsync(request);

                var content = await httpResponseMessage.Content.ReadAsStringAsync();

                return Ok(content);
            }
        }
    }
}
