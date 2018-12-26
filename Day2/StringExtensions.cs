using System.Collections.Generic;
using System.Linq;
using FunctionalExtensions;
using static System.Math;

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
            first.SingleOrNoneDifferingIndex(second).Map(index => first.Remove(index, 1));

        private static Option<int> SingleOrNoneDifferingIndex(this string first, string second) =>
            first.DifferingIndexes(second).ToArray().SingleOrNone();

        private static IEnumerable<int> DifferingIndexes(this string first, string second) =>
            Enumerable
                .Range(0, Min(first.Length, second.Length))
                .Where(index => first[index] != second[index]);
    }
}
