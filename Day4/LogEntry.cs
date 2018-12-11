using System;
using System.Collections.Generic;
using FunctionalExtensions;

namespace Day4
{
    public sealed class LogEntry : ValueObject
    {
        public DateTime Timestamp { get; }
        public string Log { get; }

        public LogEntry(DateTime timestamp, string log)
        {
            Timestamp = timestamp;
            Log = log ?? throw new ArgumentNullException(nameof(log));
        }

        public bool IsBeginsShift() =>
            Log.EndsWith("begins shift");

        public LogEntry StartingAtMidnightHour() =>
            Timestamp.Hour == 23
                ? new LogEntry(Timestamp.Date.AddDays(1), Log)
                : this;

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Timestamp;
            yield return Log;
        }

        public override string ToString() =>
            $"[{Timestamp:yyyy-MM-dd HH:mm}] {Log}";

        public int ExtractGuardId() =>
            int.Parse(Log
                      .Replace("Guard #", string.Empty)
                      .Replace(" begins shift", string.Empty));
    }
}
