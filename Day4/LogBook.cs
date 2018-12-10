using System;
using System.Linq;
using System.Collections.Generic;

namespace Day4
{
    public class LogBook
    {
        public IReadOnlyList<GuardLogEntries> GuardLogEntrieses { get; }

        public LogBook(IEnumerable<LogEntry> logEntries)
        {
            List<LogEntry> logEntriesList = logEntries?.ToList() ?? throw new ArgumentNullException(nameof(logEntries));

            GuardLogEntrieses = logEntriesList.Count == 0
                                    ? new List<GuardLogEntries>()
                                    : ToGuardLogEntries(logEntriesList);
        }

        public int PuzzleOutput1() =>
            GuardLogEntrieses
                .OrderByDescending(entry => entry.TotalMinutesAsleep())
                .First()
                .PuzzleOutput();

        public int PuzzleOutput2() =>
            GuardLogEntrieses
                .OrderByDescending(entry => entry.MostAsleepOnSameMinute())
                .First()
                .PuzzleOutput();

        private static List<GuardLogEntries> ToGuardLogEntries(List<LogEntry> logEntriesList) =>
            GroupGuardLogEntriesByGuardId(logEntriesList)
                .Select(kvp => new GuardLogEntries(kvp.Key, kvp.Value))
                .ToList();

        private static Dictionary<int, List<GuardLogEntry>> GroupGuardLogEntriesByGuardId(List<LogEntry> logEntriesList)
        {
            var entriesByGuardId = new Dictionary<int, List<GuardLogEntry>>();

            logEntriesList = logEntriesList
                             .OrderBy(logEntry => logEntry.Timestamp)
                             .ToList();

            int runningGuardId = ExtractGuardId(logEntriesList.First().Log);

            foreach (LogEntry logEntry in logEntriesList)
            {
                var guardLogEntry = new GuardLogEntry(logEntry.Timestamp, logEntry.Log);

                if (guardLogEntry.EventType == EventType.BeginsShift)
                {
                    runningGuardId = ExtractGuardId(logEntry.Log);
                    if (!entriesByGuardId.ContainsKey(runningGuardId))
                    {
                        entriesByGuardId[runningGuardId] = new List<GuardLogEntry>();
                    }
                }

                entriesByGuardId[runningGuardId].Add(guardLogEntry);
            }

            return entriesByGuardId;
        }

        private static int ExtractGuardId(string line) =>
            int.Parse(line
                      .Substring(line.IndexOf("#", StringComparison.Ordinal) + 1)
                      .Replace(" begins shift", string.Empty));
    }
}
