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
            try
            {
                _logger.LogInformation("Get");

                using (var httpClient = _httpClientFactory.CreateClient("ThirdPartyApi"))
                {
                    var request = new HttpRequestMessage(HttpMethod.Get, "weatherforecast");
                    var httpResponseMessage = await httpClient.SendAsync(request);

                    var content = await httpResponseMessage.Content.ReadAsStringAsync();
                    if (httpResponseMessage.IsSuccessStatusCode)
                        return Ok(content);

                    return StatusCode(500, "A third party request was not successful");
                    
                }
            }catch(Exception e)
            {
                return StatusCode(500, $"An error occured!");
            }
            
        }
    }
}
