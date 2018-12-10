using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using static Day4.LogEntryReaderExtensions;

namespace Day4.UnitTests
{
    public class GuardLogEntriesTests
    {
        [Theory]
        [MemberData(nameof(TotalMinutesAsleepTestsParams))]
        public void TotalMinutesAsleepTests(GuardLogEntries input, int expected) =>
            Assert.Equal(expected, input.TotalMinutesAsleep());

        public static IEnumerable<object[]> TotalMinutesAsleepTestsParams()
        {
            IEnumerable<object[]> tests = GuardLogEntriesParams().Zip(new[] { 50, 30 }, (x, y) => new object[] { x, y });

            foreach (object[] test in tests)
                yield return test;
        }

        [Theory]
        [MemberData(nameof(MinutMostAsleepOnTestsParams))]
        public void MinutMostAsleepOnTests(GuardLogEntries input, int expected) =>
            Assert.Equal(expected, input.MinutMostAsleepOn());

        public static IEnumerable<object[]> MinutMostAsleepOnTestsParams()
        {
            IEnumerable<object[]> tests = GuardLogEntriesParams().Zip(new[] { 24, 45 }, (x, y) => new object[] { x, y });

            foreach (object[] test in tests)
                yield return test;
        }

        private static IEnumerable<GuardLogEntries> GuardLogEntriesParams() =>
            new[]
            {
                new GuardLogEntries(10, new List<GuardLogEntry>
                {
                    new GuardLogEntry(new DateTime(1518, 11, 01, 00, 00, 00), "Guard #10 begins shift"),
                    new GuardLogEntry(new DateTime(1518, 11, 01, 00, 05, 00), "falls asleep"),
                    new GuardLogEntry(new DateTime(1518, 11, 01, 00, 25, 00), "wakes up"),
                    new GuardLogEntry(new DateTime(1518, 11, 01, 00, 30, 00), "falls asleep"),
                    new GuardLogEntry(new DateTime(1518, 11, 01, 00, 55, 00), "wakes up"),
                    new GuardLogEntry(new DateTime(1518, 11, 03, 00, 05, 00), "Guard #10 begins shift"),
                    new GuardLogEntry(new DateTime(1518, 11, 03, 00, 24, 00), "falls asleep"),
                    new GuardLogEntry(new DateTime(1518, 11, 03, 00, 29, 00), "wakes up"),
                }),
                new GuardLogEntries(99, new List<GuardLogEntry>
                {
                    new GuardLogEntry(new DateTime(1518, 11, 01, 23, 58, 00), "Guard #99 begins shift"),
                    new GuardLogEntry(new DateTime(1518, 11, 02, 00, 40, 00), "falls asleep"),
                    new GuardLogEntry(new DateTime(1518, 11, 02, 00, 50, 00), "wakes up"),
                    new GuardLogEntry(new DateTime(1518, 11, 04, 00, 02, 00), "Guard #99 begins shift"),
                    new GuardLogEntry(new DateTime(1518, 11, 04, 00, 36, 00), "falls asleep"),
                    new GuardLogEntry(new DateTime(1518, 11, 04, 00, 46, 00), "wakes up"),
                    new GuardLogEntry(new DateTime(1518, 11, 05, 00, 03, 00), "Guard #99 begins shift"),
                    new GuardLogEntry(new DateTime(1518, 11, 05, 00, 45, 00), "falls asleep"),
                    new GuardLogEntry(new DateTime(1518, 11, 05, 00, 55, 00), "wakes up")
                })
            };

        [Theory]
        [MemberData(nameof(PuzzleOutputTestsParams))]
        public void PuzzleOutputTests(LogBook logBook, int expected) =>
            Assert.Equal(expected, logBook.PuzzleOutput1());

        public static IEnumerable<object[]> PuzzleOutputTestsParams()
        {
            yield return new object[]
            {
                new LogBook(new List<LogEntry>
                {
                    new LogEntry(new DateTime(1518, 11, 01, 00, 00, 00), "Guard #10 begins shift"),
                    new LogEntry(new DateTime(1518, 11, 01, 00, 05, 00), "falls asleep"),
                    new LogEntry(new DateTime(1518, 11, 01, 00, 25, 00), "wakes up"),
                    new LogEntry(new DateTime(1518, 11, 01, 00, 30, 00), "falls asleep"),
                    new LogEntry(new DateTime(1518, 11, 01, 00, 55, 00), "wakes up"),
                    new LogEntry(new DateTime(1518, 11, 01, 23, 58, 00), "Guard #99 begins shift"),
                    new LogEntry(new DateTime(1518, 11, 02, 00, 40, 00), "falls asleep"),
                    new LogEntry(new DateTime(1518, 11, 02, 00, 50, 00), "wakes up"),
                    new LogEntry(new DateTime(1518, 11, 03, 00, 05, 00), "Guard #10 begins shift"),
                    new LogEntry(new DateTime(1518, 11, 03, 00, 24, 00), "falls asleep"),
                    new LogEntry(new DateTime(1518, 11, 03, 00, 29, 00), "wakes up"),
                    new LogEntry(new DateTime(1518, 11, 04, 00, 02, 00), "Guard #99 begins shift"),
                    new LogEntry(new DateTime(1518, 11, 04, 00, 36, 00), "falls asleep"),
                    new LogEntry(new DateTime(1518, 11, 04, 00, 46, 00), "wakes up"),
                    new LogEntry(new DateTime(1518, 11, 05, 00, 03, 00), "Guard #99 begins shift"),
                    new LogEntry(new DateTime(1518, 11, 05, 00, 45, 00), "falls asleep"),
                    new LogEntry(new DateTime(1518, 11, 05, 00, 55, 00), "wakes up")
                }),
                240
            };
        }

        [Fact]
        public void IntegrationTestPartOne()
        {
            IEnumerable<LogEntry> logEntries = ReadLogEntriesFromFile("day4_one.txt");
            var logBook = new LogBook(logEntries);

            Assert.Equal(84636, logBook.PuzzleOutput1());
        }

        [Fact]
        public void IntegrationTestPartTwo()
        {
            IEnumerable<LogEntry> logEntries = ReadLogEntriesFromFile("day4_one.txt");
            var logBook = new LogBook(logEntries);

            Assert.Equal(91679, logBook.PuzzleOutput2());
        }
    }
}
