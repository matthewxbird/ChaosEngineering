using System.Collections.Generic;

namespace ChaosProvider
{
    public interface IChaosSettings
    {
        IEnumerable<ChaosPolicy> Get();
    }

    public class ChaosSettings : IChaosSettings
    {
        private IEnumerable<ChaosPolicy> _policies;

        public ChaosSettings(IEnumerable<ChaosPolicy> policies)
        {
            _policies = policies;
        }

        public IEnumerable<ChaosPolicy> Get()
        {
            return _policies;
        }
    }
}
