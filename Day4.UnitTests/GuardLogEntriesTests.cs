using System;
using System.Collections.Generic;
using Xunit;

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
            yield return new object[]
            {
                new GuardLogEntries(10, new[]
                {
                    new LogEntry(new DateTime(1518, 11, 01, 00, 00, 00), "Guard #10 begins shift"),
                    new LogEntry(new DateTime(1518, 11, 01, 00, 05, 00), "falls asleep"),
                    new LogEntry(new DateTime(1518, 11, 01, 00, 25, 00), "wakes up"),
                    new LogEntry(new DateTime(1518, 11, 01, 00, 30, 00), "falls asleep"),
                    new LogEntry(new DateTime(1518, 11, 01, 00, 55, 00), "wakes up"),
                    new LogEntry(new DateTime(1518, 11, 03, 00, 05, 00), "Guard #10 begins shift"),
                    new LogEntry(new DateTime(1518, 11, 03, 00, 24, 00), "falls asleep"),
                    new LogEntry(new DateTime(1518, 11, 03, 00, 29, 00), "wakes up"),
                }),
                50
            };

            yield return new object[]
            {
                new GuardLogEntries(99, new[]
                {
                    new LogEntry(new DateTime(1518, 11, 01, 23, 58, 00), "Guard #99 begins shift"),
                    new LogEntry(new DateTime(1518, 11, 02, 00, 40, 00), "falls asleep"),
                    new LogEntry(new DateTime(1518, 11, 02, 00, 50, 00), "wakes up"),
                    new LogEntry(new DateTime(1518, 11, 04, 00, 02, 00), "Guard #99 begins shift"),
                    new LogEntry(new DateTime(1518, 11, 04, 00, 36, 00), "falls asleep"),
                    new LogEntry(new DateTime(1518, 11, 04, 00, 46, 00), "wakes up"),
                    new LogEntry(new DateTime(1518, 11, 05, 00, 03, 00), "Guard #99 begins shift"),
                    new LogEntry(new DateTime(1518, 11, 05, 00, 45, 00), "falls asleep"),
                    new LogEntry(new DateTime(1518, 11, 05, 00, 55, 00), "wakes up")
                }),
                30
            };
        }

        [Theory]
        [MemberData(nameof(MinutMostAsleepOnTestsParams))]
        public void MinutMostAsleepOnTests(GuardLogEntries input, int expected) =>
            Assert.Equal(expected, input.MinutMostAsleepOn());

        public static IEnumerable<object[]> MinutMostAsleepOnTestsParams()
        {
            yield return new object[]
            {
                new GuardLogEntries(10, new[]
                {
                    new LogEntry(new DateTime(1518, 11, 01, 00, 00, 00), "Guard #10 begins shift"),
                    new LogEntry(new DateTime(1518, 11, 01, 00, 05, 00), "falls asleep"),
                    new LogEntry(new DateTime(1518, 11, 01, 00, 25, 00), "wakes up"),
                    new LogEntry(new DateTime(1518, 11, 01, 00, 30, 00), "falls asleep"),
                    new LogEntry(new DateTime(1518, 11, 01, 00, 55, 00), "wakes up"),
                    new LogEntry(new DateTime(1518, 11, 03, 00, 05, 00), "Guard #10 begins shift"),
                    new LogEntry(new DateTime(1518, 11, 03, 00, 24, 00), "falls asleep"),
                    new LogEntry(new DateTime(1518, 11, 03, 00, 29, 00), "wakes up"),
                }),
                24
            };

            yield return new object[]
            {
                new GuardLogEntries(99, new[]
                {
                    new LogEntry(new DateTime(1518, 11, 01, 23, 58, 00), "Guard #99 begins shift"),
                    new LogEntry(new DateTime(1518, 11, 02, 00, 40, 00), "falls asleep"),
                    new LogEntry(new DateTime(1518, 11, 02, 00, 50, 00), "wakes up"),
                    new LogEntry(new DateTime(1518, 11, 04, 00, 02, 00), "Guard #99 begins shift"),
                    new LogEntry(new DateTime(1518, 11, 04, 00, 36, 00), "falls asleep"),
                    new LogEntry(new DateTime(1518, 11, 04, 00, 46, 00), "wakes up"),
                    new LogEntry(new DateTime(1518, 11, 05, 00, 03, 00), "Guard #99 begins shift"),
                    new LogEntry(new DateTime(1518, 11, 05, 00, 45, 00), "falls asleep"),
                    new LogEntry(new DateTime(1518, 11, 05, 00, 55, 00), "wakes up")
                }),
                45
            };
        }
    }
}
