using System.Linq;

namespace Day2
{
    public static class StringExtensions
    {
        public static bool ContainsAnyLetterExactNumberOfOccurrences(this string s, int numberOfOccurrences) => 
            s.Any(letter => s.Count(c => c == letter) == numberOfOccurrences);

        public static int Checksum(this string[] ids) =>
            ids.Count(id => id.ContainsAnyLetterExactNumberOfOccurrences(2)) * 
            ids.Count(id => id.ContainsAnyLetterExactNumberOfOccurrences(3));
    }
}
