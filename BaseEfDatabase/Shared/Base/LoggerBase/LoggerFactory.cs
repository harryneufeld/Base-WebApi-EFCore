using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace LoggerBase
{
    public sealed class LoggerFactory
    {
        private readonly ILogger _logger;

        public LoggerFactory(ILogger logger)
        {
            _logger = logger;
        }

        public ILogger Logger => _logger;
    }
}
