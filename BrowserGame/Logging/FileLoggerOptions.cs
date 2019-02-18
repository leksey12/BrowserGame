using BrowserGame.Logging.Internal;
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
    public class FileLoggerOptions : BatchingLoggerOptions
    {
        private int? _fileSizeLimit = 10 * 1024 * 1024;
        private int? _retainedFileCountLimit = 2;
        private string _fileName = "FileLogger-";


        /// <summary>
        /// Получает или задает строго положительное значение, представляющее максимальный размер журнала в байтах или ноль без ограничений.
        /// Когда журнал заполнится, больше сообщений не будет добавлено.
        /// По умолчанию <c>10MB</c>.
        /// </summary>
        public int? FileSizeLimit
        {
            get { return _fileSizeLimit; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), $"{nameof(FileSizeLimit)} must be positive.");
                }
                _fileSizeLimit = value;
            }
        }

        /// <summary>
        /// Получает или задает строго положительное значение, представляющее максимальное количество сохраненных файлов, или значение NULL без ограничений.
          /// По умолчанию <c>2</c>.
        /// </summary>
        public int? RetainedFileCountLimit
        {
            get { return _retainedFileCountLimit; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), $"{nameof(RetainedFileCountLimit)} must be positive.");
                }
                _retainedFileCountLimit = value;
            }
        }

        /// <summary>
        /// Получает или задает префикс имени файла, который будет использоваться для файлов журнала.
          /// По умолчанию <c>FileLogger-</c>.
        /// </summary>
        public string FileName
        {
            get { return _fileName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(nameof(value));
                }
                _fileName = value;
            }
        }

        /// <summary>
        /// Каталог, в который будут записываться файлы журнала, относительно процесса приложения.
        /// По умолчанию <c>Logging</c>
        /// </summary>
        /// <returns></returns>
        public string LogDirectory { get; set; } = "C:/Users/Aleksey/source/repos/BrowserGame/Logging";
    }
}