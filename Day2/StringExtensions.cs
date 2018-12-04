using System.Linq;

namespace Day2
{
    public static class StringExtensions
    {
        public static bool ContainsAnyLetterExactNumberOfOccurences(this string s, int numberOfOccurrences) => 
            s.Any(letter => s.Count(c => c == letter) == numberOfOccurrences);

        public static int Checksum(this string[] ids) =>
            ids.Count(id => id.ContainsAnyLetterExactNumberOfOccurences(2)) * 
            ids.Count(id => id.ContainsAnyLetterExactNumberOfOccurences(3));
    }
}
