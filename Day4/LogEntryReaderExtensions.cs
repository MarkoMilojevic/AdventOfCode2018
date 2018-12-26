using System;
using System.Collections.Generic;
using System.Linq;
using static System.Globalization.CultureInfo;
using static FileExtensions.FileExtensions;

namespace Day4
{
    public static class LogEntryReaderExtensions
    {
        private const string TimestampFormat = "yyyy-MM-dd HH:mm";

        public static LogBook ReadLogBookFromFile(string filePath) =>
            new LogBook(ReadLogEntriesFromFile(filePath));

        public static IEnumerable<LogEntry> ReadLogEntriesFromFile(string filePath) =>
            ReadStringArrayFromFile(filePath).Select(ParseLogEntry);

        public static LogEntry ParseLogEntry(string line) =>
            new LogEntry(ExtractTimestamp(line), ExtractLog(line));

        public static DateTime ExtractTimestamp(string line) =>
            DateTime.ParseExact(line.Substring(1, TimestampFormat.Length), TimestampFormat, InvariantCulture);

        public static string ExtractLog(string line) =>
            line.Substring($"[{TimestampFormat}] ".Length);
    }
}
