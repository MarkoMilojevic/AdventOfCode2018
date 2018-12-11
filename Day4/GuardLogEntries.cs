using System;
using System.Collections.Generic;
using System.Linq;

namespace Day4
{
    public class GuardLogEntries
    {
        private int Id { get; }
        private IReadOnlyList<LogEntry> LogEntries { get; }

        public GuardLogEntries(int id, IEnumerable<LogEntry> logEntries)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id));

            Id = id;
            LogEntries = logEntries?.ToList() ?? throw new ArgumentNullException(nameof(logEntries));
        }

        public int TotalMinutesAsleep() =>
            LogEntries
                .MidnightShifts()
                .Sum(LogEntriesExtensions.TotalMinutesAsleep);

        public int MinutMostAsleepOn() =>
            LogEntries.MostTimeAsleepOnMinute().Minute;

        public int MostAsleepOnSameMinute() =>
            LogEntries.MostTimeAsleepOnMinute().TimeAsleep;

        public int PuzzleOutput() =>
            Id * MinutMostAsleepOn();
    }
}
