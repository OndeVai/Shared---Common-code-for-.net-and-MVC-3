#region

using NLog;

#endregion

namespace Shared.Diagnostics
{
    public interface ILoggerAdapter
    {
        void Trace(string message);
        void Debug(string message);
        void Info(string message);
        void Warn(string message);
        void Error(string message);
        void Fatal(string message);
    }

    public class NLogLoggerAdapter : ILoggerAdapter
    {
        private readonly Logger _logger;

        public NLogLoggerAdapter(string className)
        {
            _logger = LogManager.GetLogger(className);
        }

        #region Implementation of ILoggerAdapter

        public void Trace(string message)
        {
            _logger.Trace(message);
        }

        public void Debug(string message)
        {
            _logger.Debug(message);
        }

        public void Info(string message)
        {
            _logger.Info(message);
        }

        public void Warn(string message)
        {
            _logger.Warn(message);
        }

        public void Error(string message)
        {
            _logger.Error(message);
        }

        public void Fatal(string message)
        {
            _logger.Fatal(message);
        }

        #endregion
    }
}