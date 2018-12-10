using System;
using System.Collections.Generic;
using FunctionalExtensions;

namespace Day4
{
    public class LogEntry : ValueObject
    {
        public DateTime Timestamp { get; }
        public string Log { get; }

        public LogEntry(DateTime timestamp, string log)
        {
            Timestamp = timestamp;
            Log = log ?? throw new ArgumentNullException(nameof(log));
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Timestamp;
            yield return Log;
        }

        public override string ToString() =>
            $"[{Timestamp:yyyy-MM-dd HH:mm}] {Log}";
    }
}
