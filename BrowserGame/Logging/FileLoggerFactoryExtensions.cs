using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrowserGame
{

    public static class FileLoggerFactoryExtensions
    {
        /// <summary>
        /// Добавляет регистр файлов с именем «Файл» in Fabrica.
        /// </summary>
        public static ILoggingBuilder AddFile(this ILoggingBuilder builder)
        {
            builder.Services.AddSingleton<ILoggerProvider, FileLoggerProvider>();
            return builder;
        }

        public static ILoggingBuilder AddFile(this ILoggingBuilder builder, string filename)
        {
            builder.AddFile(options => options.FileName = "FileLogger-");
            return builder;
        }

        public static ILoggingBuilder AddFile(this ILoggingBuilder builder, Action<FileLoggerOptions> configure)
        {
            if (configure == null)
            {
                throw new ArgumentNullException(nameof(configure));
            }
            builder.AddFile();
            builder.Services.Configure(configure);

            return builder;
        }
    }
}