using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrowserGame.Logging.Internal
{
    public class BatchingLoggerOptions
    {
        private int? _batchSize;
        private int? _backgroundQueueSize = 1000;
        private TimeSpan _flushPeriod = TimeSpan.FromSeconds(1);

        /// <summary>
        /// Возвращает или задает время периода, по истечении которого журналы будут сброшены в хранилище.
        /// </summary>
        public TimeSpan FlushPeriod
        {
            get { return _flushPeriod; }
            set
            {
                if (value <= TimeSpan.Zero)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), $"{nameof(FlushPeriod)} must be positive.");
                }
                _flushPeriod = value;
            }
        }

        /// <summary>
        /// Получает или задает максимальный размер очереди сообщений фонового журнала или ноль без ограничений.
        /// После достижения максимального размера очереди приемник событий журнала начнет блокироваться.
        /// По умолчанию <c>1000</c>.
        /// </summary>
        public int? BackgroundQueueSize
        {
            get { return _backgroundQueueSize; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), $"{nameof(BackgroundQueueSize)} must be non-negative.");
                }
                _backgroundQueueSize = value;
            }
        }

        /// <summary>
        /// Получает или задает максимальное количество событий, включаемых в один пакет, или значение NULL без ограничений.
        /// </summary>
        /// По умолчанию <c>null</c>.
        public int? BatchSize
        {
            get { return _batchSize; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), $"{nameof(BatchSize)} must be positive.");
                }
                _batchSize = value;
            }
        }

        /// <summary>
        /// Получает или задает значение, указывающее, принимает ли регистратор и записывает в очередь.
        /// </summary>
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Получает или задает значение, указывающее, следует ли включать области в сообщение.
        /// По умолчанию  <c>false</c>.
        /// </summary>
        public bool IncludeScopes { get; set; } = false;
    }
}
