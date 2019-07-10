using System;
using Microsoft.Extensions.Logging;

namespace Service.Common
{
    public interface ILoggerAdapter<T>
    {
        void LogError(string message);
        void LogError(Exception ex, string message, params object[] args);
        void LogInformation(string message);
    }

    internal class LoggerAdapter<T> : ILoggerAdapter<T>
    {
        private readonly ILogger<T> _logger;

        public LoggerAdapter(ILogger<T> logger)
        {
            _logger = logger;
        }

        public void LogError(string message)
        {
            _logger.LogError(message);
        }

        public void LogError(Exception ex, string message, params object[] args)
        {
            _logger.LogError(ex, message, args);
        }

        public void LogInformation(string message)
        {
            _logger.LogInformation(message);
        }
    }
}