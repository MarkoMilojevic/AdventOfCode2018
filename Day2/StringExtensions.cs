using System.Collections.Generic;
using System.Linq;
using FunctionalExtensions;
using static System.Math;

namespace Day2
{
    public static class StringExtensions
    {
        public static int Checksum(this string[] ids)
        {
            int twos = ids.Count(id => id.ContainsAnyLetterExactNumberOfOccurrences(2));
            int threes = ids.Count(id => id.ContainsAnyLetterExactNumberOfOccurrences(3));

            return twos * threes;
        }

        public static bool ContainsAnyLetterExactNumberOfOccurrences(this string s, int numberOfOccurrences) =>
            s.Any(letter => s.Count(c => c == letter) == numberOfOccurrences);

        public static Option<string> CommonAfterRemovingDifferingCharacter(this string first, string second) =>
            first
                .DifferingIndexes(second)
                .SingleOrNone()
                .Map(index => first.Remove(index, 1));

        private static IEnumerable<int> DifferingIndexes(this string first, string second) =>
            Enumerable
                .Range(0, Min(first.Length, second.Length))
                .Where(index => first[index] != second[index]);
    }
}
