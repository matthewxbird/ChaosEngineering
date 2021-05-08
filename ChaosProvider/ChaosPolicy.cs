using System;

namespace ChaosProvider
{
    public class ChaosPolicy
    {
        public Exception Fault { get; private set; }
        public double Rate { get; private set; }
        public bool Enabled { get; private set; }

        public static ChaosPolicy InjectFault(Exception ex, double rate, bool enabled)
        {
            return new ChaosPolicy
            {
                Fault = ex,
                Rate = rate,
                Enabled = enabled
            };
        }
    }
}
