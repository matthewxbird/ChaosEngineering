using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ChaosProvider
{
    public class ChaosHttpHandler : DelegatingHandler
    {
        private ILogger<ChaosHttpHandler> _logger;
        public ChaosHttpHandler(ILogger<ChaosHttpHandler> logger)
        {
            _logger = logger;
        }

        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Process request");
            var response = await base.SendAsync(request, cancellationToken);
            _logger.LogInformation("Process response");
            return response;
        }
    }
}
