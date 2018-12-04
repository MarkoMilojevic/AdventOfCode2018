using System.Collections.Generic;
using System.Linq;
using FunctionalExtensions;

namespace Day2
{
    public static class StringExtensions
    {
        public static bool ContainsAnyLetterExactNumberOfOccurrences(this string s, int numberOfOccurrences) =>
            s.Any(letter => s.Count(c => c == letter) == numberOfOccurrences);

        public static int Checksum(this string[] ids) =>
            ids.Count(id => id.ContainsAnyLetterExactNumberOfOccurrences(2)) *
            ids.Count(id => id.ContainsAnyLetterExactNumberOfOccurrences(3));

        public static Option<string> CommonAfterRemovingDifferingCharacter(this string first, string second) =>
            first.DifferingIndex(second).Map(index => first.Remove(index, 1));

        private static Option<int> DifferingIndex(this string first, string second) =>
            first.DifferingIndexes(second).ToArray().SingleOrNone();

        private static IEnumerable<int> DifferingIndexes(this string first, string second) =>
            first
                .Select((_, index) => index < second.Length && first[index] != second[index] ? index : -1)
                .Where(index => index != -1);
    }
}
