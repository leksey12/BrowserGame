using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BrowserGame
{
    /// <summary>
    /// Варианты регистрации файлов.
    /// </summary>
    public class FileLoggerOptions : ILogger
    {
        private string filePath;
        private object _lock = new object();
        public FileLoggerOptions(string path)
        {
            filePath = path;
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
           
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (formatter != null)
            {
                string message = $"[{logLevel.ToString()}] {state.ToString()} {exception?.Message}" + Environment.NewLine;
                lock (_lock)
                {
                    File.AppendAllText(filePath, message);
                }
            }
        }
    }
}