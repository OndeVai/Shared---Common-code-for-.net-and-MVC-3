﻿namespace Shared.Diagnostics
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
}