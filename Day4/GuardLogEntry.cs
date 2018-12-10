using System;
using System.Collections.Generic;
using FunctionalExtensions;

namespace Day4
{
    public class GuardLogEntry : ValueObject
    {
        public DateTime Timestamp { get; }
        public string Log { get; }
        public EventType EventType { get; }

        public GuardLogEntry(DateTime timestamp, string log)
        {
            Timestamp = timestamp;
            Log = log ?? throw new ArgumentNullException(nameof(log));
            EventType = ParseEventType(log);
        }

        private static EventType ParseEventType(string log) =>
            log.EndsWith("begins shift")
              ? EventType.BeginsShift
          : log == "wakes up"
              ? EventType.WakesUp
          : log == "falls asleep"
              ? EventType.FallsAsleep
          : throw new ArgumentException(nameof(log));

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Timestamp;
            yield return Log;
        }

        public override string ToString() =>
            $"[{Timestamp:yyyy-MM-dd HH:mm}] {Log}";
    }
}
