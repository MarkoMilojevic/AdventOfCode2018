using System;
using System.Collections.Generic;
using Xunit;
using static Day4.LogEntryReaderExtensions;

namespace Day4.UnitTests
{
    public class LogBookTests
    {
        [Theory]
        [MemberData(nameof(PuzzleOutput1TestsParams))]
        public void PuzzleOutput1Tests(LogBook logBook, int expected) =>
            Assert.Equal(expected, logBook.PuzzleOutput1());

        public static IEnumerable<object[]> PuzzleOutput1TestsParams() =>
            new[] { new object[] { CreateLogBook(), 240 } };

        [Theory]
        [MemberData(nameof(PuzzleOutput2TestsParams))]
        public void PuzzleOutput2Tests(LogBook logBook, int expected) =>
            Assert.Equal(expected, logBook.PuzzleOutput2());

        public static IEnumerable<object[]> PuzzleOutput2TestsParams() =>
            new[] { new object[] { CreateLogBook(), 4455 } };

        private static LogBook CreateLogBook() =>
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
            });

        [Fact]
        public void IntegrationTestPartOne() =>
            Assert.Equal(84636, ReadLogBookFromFile("day4.txt").PuzzleOutput1());

        [Fact]
        public void IntegrationTestPartTwo() =>
            Assert.Equal(91679, ReadLogBookFromFile("day4.txt").PuzzleOutput2());
    }
}
