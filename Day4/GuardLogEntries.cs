using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using FunctionalExtensions;

namespace Day4
{
    public class GuardLogEntries : ValueObject
    {
        public int Id { get; }
        public IReadOnlyList<GuardLogEntry> LogEntries { get; }

        public GuardLogEntries(int id, IEnumerable<GuardLogEntry> logEntries)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id));

            Id = id;
            LogEntries = logEntries?.ToList() ?? throw new ArgumentNullException(nameof(logEntries));
        }

        public int TotalMinutesAsleep() =>
            LogEntries
                .Select(entry => entry.Timestamp.Hour == 23 
                                     ? new GuardLogEntry(entry.Timestamp.Date.AddDays(1), entry.Log) 
                                     : entry)
                .GroupBy(entry => entry.Timestamp.Date)
                .Sum(shift => TotalMinutesAsleep(shift.ToList()));

        private static int TotalMinutesAsleep(IReadOnlyList<GuardLogEntry> shift) =>
            Enumerable
                .Range(0, shift.Count)
                .Where(i => i % 2 == 1)
                .Sum(i => (int) (shift[i + 1].Timestamp - shift[i].Timestamp).TotalMinutes);

        public int PuzzleOutput() =>
            Id * MinutMostAsleepOn();

        public int MinutMostAsleepOn()
        {
            var minutesAsleepByMinute = new Dictionary<int, int>();

            for (int i = 0; i < 60; i++)
                minutesAsleepByMinute[i] = 0;

            List<IGrouping<DateTime, GuardLogEntry>> shifts = LogEntries
                                                              .Select(entry => entry.Timestamp.Hour == 23
                                                                                   ? new GuardLogEntry(entry.Timestamp.Date.AddDays(1), entry.Log)
                                                                                   : entry)
                                                              .GroupBy(entry => entry.Timestamp.Date)
                                                              .ToList();

            foreach (IGrouping<DateTime, GuardLogEntry> shift in shifts)
            {
                List<GuardLogEntry> shiftEntries = shift.ToList();
                for (int i = 1; i < shiftEntries.Count - 1; i +=2)
                {
                    int startMinute = shiftEntries[i].Timestamp.Minute;
                    int endMinute = shiftEntries[i + 1].Timestamp.Minute;

                    for (int j = startMinute; j < endMinute; j++)
                        minutesAsleepByMinute[j] = minutesAsleepByMinute[j] + 1;
                }
            }

            return minutesAsleepByMinute
                   .ToList()
                   .OrderByDescending(kvp => kvp.Value)
                   .First()
                   .Key;
        }

        public int MostAsleepOnSameMinute()
        {
            var minutesAsleepByMinute = new Dictionary<int, int>();

            for (int i = 0; i < 60; i++)
                minutesAsleepByMinute[i] = 0;

            List<IGrouping<DateTime, GuardLogEntry>> shifts = LogEntries
                                                              .Select(entry => entry.Timestamp.Hour == 23
                                                                                   ? new GuardLogEntry(entry.Timestamp.Date.AddDays(1), entry.Log)
                                                                                   : entry)
                                                              .GroupBy(entry => entry.Timestamp.Date)
                                                              .ToList();

            foreach (IGrouping<DateTime, GuardLogEntry> shift in shifts)
            {
                List<GuardLogEntry> shiftEntries = shift.ToList();
                for (int i = 1; i < shiftEntries.Count - 1; i += 2)
                {
                    int startMinute = shiftEntries[i].Timestamp.Minute;
                    int endMinute = shiftEntries[i + 1].Timestamp.Minute;

                    for (int j = startMinute; j < endMinute; j++)
                        minutesAsleepByMinute[j] = minutesAsleepByMinute[j] + 1;
                }
            }

            return minutesAsleepByMinute
                   .ToList()
                   .OrderByDescending(kvp => kvp.Value)
                   .First()
                   .Value;
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Id;
        }

        public override string ToString() =>
            $"Guard #{Id}";
    }
}
