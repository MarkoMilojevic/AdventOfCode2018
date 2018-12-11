using System.Collections.Generic;
using System.Linq;

namespace Day4
{
    public static class LogEntriesExtensions
    {
        public static IEnumerable<IReadOnlyList<LogEntry>> MidnightShifts(this IEnumerable<LogEntry> logEntries) =>
            logEntries?
                .Select(entry => entry.StartingAtMidnightHour())
                .GroupBy(entry => entry.Timestamp.Date)
                .Select(group => group.ToList())
         ?? Enumerable.Empty<IReadOnlyList<LogEntry>>();

        public static Dictionary<int, List<LogEntry>> GroupLogsByGuardId(this IReadOnlyList<LogEntry> logEntries)
        {
            var logsByGuardId = new Dictionary<int, List<LogEntry>>();

            logEntries = logEntries
                         .OrderBy(logEntry => logEntry.Timestamp)
                         .ToList();

            int runningGuardId = logEntries.First().ExtractGuardId();

            foreach (LogEntry log in logEntries)
            {
                if (log.IsBeginsShift())
                {
                    runningGuardId = log.ExtractGuardId();
                    if (!logsByGuardId.ContainsKey(runningGuardId))
                    {
                        logsByGuardId[runningGuardId] = new List<LogEntry>();
                    }
                }

                logsByGuardId[runningGuardId].Add(log);
            }

            return logsByGuardId;
        }

        public static int TotalMinutesAsleep(this IReadOnlyList<LogEntry> logs) =>
            Enumerable
                .Range(0, logs.Count)
                .Where(i => i % 2 == 1 && i < logs.Count - 1)
                .Sum(i => (int)(logs[i + 1].Timestamp - logs[i].Timestamp).TotalMinutes);

        public static (int Minute, int TimeAsleep) MostTimeAsleepOnMinute(this IEnumerable<LogEntry> logEntries)
        {
            Dictionary<int, int> minutesAsleepByMinute = Enumerable
                                                         .Range(0, 60)
                                                         .ToDictionary(i => i, _ => 0);

            IEnumerable<IReadOnlyList<LogEntry>> shifts = logEntries.MidnightShifts();
            foreach (IReadOnlyList<LogEntry> logs in shifts)
            {
                for (int i = 1; i < logs.Count - 1; i += 2)
                {
                    int startMinute = logs[i].Timestamp.Minute;
                    int endMinute = logs[i + 1].Timestamp.Minute;

                    for (int j = startMinute; j < endMinute; j++)
                        minutesAsleepByMinute[j] = minutesAsleepByMinute[j] + 1;
                }
            }

            KeyValuePair<int, int> minutMostAsleepOn = minutesAsleepByMinute
                                                       .OrderByDescending(kvp => kvp.Value)
                                                       .First();

            return (minutMostAsleepOn.Key, minutMostAsleepOn.Value);
        }
    }
}
