using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace ChaosProvider
{
    public class ChaosHttpHandler : DelegatingHandler
    {
        private ILogger<ChaosHttpHandler> _logger;
        private IEnumerable<ChaosPolicy> _chaosSettings;

        public ChaosHttpHandler(ILogger<ChaosHttpHandler> logger, IChaosSettings chaosSettings)
        {
            _logger = logger;
            _chaosSettings = chaosSettings.Get();
        }

        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            foreach(var policy in _chaosSettings)
            {
                if (!policy.Enabled)
                    continue;

                var rng = new Random().NextDouble();

                if (rng >= policy.Rate)
                    continue;

                if(policy.Fault != null)
                    throw policy.Fault;
            }

            _logger.LogInformation("Process request");
            var response = await base.SendAsync(request, cancellationToken);
            _logger.LogInformation("Process response");
            return response;
        }
    }
}
