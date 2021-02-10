using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Tellurium.StableElements
{
    internal class StatelessWait : DefaultWait<object>
    {
        public StatelessWait(TimeSpan timeout)
            : this(new SystemClock(), timeout, DefaultSleepTimeout)
        {
        }

        private static TimeSpan DefaultSleepTimeout { get; } = TimeSpan.FromMilliseconds(500.0);
        
        private StatelessWait(
            IClock clock,
            TimeSpan timeout,
            TimeSpan sleepInterval)
            : base(new object(), clock)
        {
            this.Timeout = timeout;
            this.PollingInterval = sleepInterval;
            this.IgnoreExceptionTypes(new Type[1]
            {
                typeof (NotFoundException)
            });
        }
    }
}