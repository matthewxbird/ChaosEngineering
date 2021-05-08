using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace ChaosHost.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChaosHostController : ControllerBase
    {
        private readonly ILogger<ChaosHostController> _logger;

        public ChaosHostController(ILogger<ChaosHostController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public int Get()
        {
            var rng = new Random();
            return rng.Next();
        }
    }
}
