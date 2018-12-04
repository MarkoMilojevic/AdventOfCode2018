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

        public static Option<string> CommonAfterRemovingDifferingCharacter(this string s1, string s2) =>
            s1.DifferingIndex(s2).Map(index => s1.Remove(index, 1));

        private static Option<int> DifferingIndex(this string s1, string s2) =>
            s1.DifferingIndexes(s2).ToArray().SingleOrNone();

        private static IEnumerable<int> DifferingIndexes(this string s1, string s2)
        {
            string first = s1.Length <= s2.Length ? s1 : s2;
            string second = s1.Length <= s2.Length ? s2 : s1;

            return first
                   .Select((_, index) => first[index] != second[index] ? index : -1)
                   .Where(index => index != -1);
        }
    }
}
