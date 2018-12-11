using System;
using System.Collections.Generic;
using Xunit;
using static Day4.LogEntryReaderExtensions;

namespace Day4.UnitTests
{
    public class LogEntryReaderExtensionsTests
    {
        [Theory]
        [MemberData(nameof(ReadLogEntriesFromFileTestsParams))]
        public void ReadLogEntriesFromFileTests(string input, LogEntry expected) =>
            Assert.Equal(expected, ParseLogEntry(input));

        public static IEnumerable<object[]> ReadLogEntriesFromFileTestsParams()
        {
            yield return new object[]
            {
                "[1518-11-01 00:00] Guard #10 begins shift",
                new LogEntry(new DateTime(1518, 11, 01, 0, 0, 0), "Guard #10 begins shift")
            };

            yield return new object[]
            {
                "[1518-11-01 00:05] falls asleep",
                new LogEntry(new DateTime(1518, 11, 01, 00, 05, 00), "falls asleep")
            };

            yield return new object[]
            {
                "[1518-11-01 00:25] wakes up",
                new LogEntry(new DateTime(1518, 11, 01, 00, 25, 00), "wakes up")
            };
        }
    }
}
