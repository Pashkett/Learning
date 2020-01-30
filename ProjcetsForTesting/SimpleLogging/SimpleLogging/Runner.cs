using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLog.Extensions.Logging;

namespace SimpleLogging
{
    public class Runner
    {
        private readonly ILogger<Runner> logger;
        public Runner(ILogger<Runner> logger) => 
            this.logger = logger;

        public void DoAction(string name) =>
            logger.LogDebug(20, "Doing hard work! {Action}", name);
    }
}
