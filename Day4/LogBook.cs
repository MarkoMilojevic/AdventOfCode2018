using System;
using System.Linq;
using System.Collections.Generic;

namespace Day4
{
    public class LogBook
    {
        private IReadOnlyList<GuardLogEntries> GuardLogEntries { get; }

        public LogBook(IEnumerable<LogEntry> logEntries)
        {
            List<LogEntry> logEntriesList = logEntries?.ToList() ?? throw new ArgumentNullException(nameof(logEntries));

            GuardLogEntries = ToGuardLogEntries(logEntriesList);
        }

        private static IReadOnlyList<GuardLogEntries> ToGuardLogEntries(IReadOnlyList<LogEntry> logEntries)
        {
            if (logEntries.Count == 0)
                return new List<GuardLogEntries>();

            return logEntries
                   .GroupLogsByGuardId()
                   .Select(logsByGuardId => new GuardLogEntries(logsByGuardId.Key, logsByGuardId.Value))
                   .ToList();
        }

        public int PuzzleOutput1()
        {
            if (GuardLogEntries.Count == 0)
                return 0;

            return GuardLogEntries
                   .OrderByDescending(log => log.TotalMinutesAsleep())
                   .First()
                   .PuzzleOutput();
        }

        public int PuzzleOutput2()
        {
            if (GuardLogEntries.Count == 0)
                return 0;

            return GuardLogEntries
                   .OrderByDescending(log => log.MostAsleepOnSameMinute())
                   .First()
                   .PuzzleOutput();
        }
    }
}
