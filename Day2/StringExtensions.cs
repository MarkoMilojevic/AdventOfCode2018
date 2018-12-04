using System.Linq;

namespace Day2
{
    public static class StringExtensions
    {
        public static bool ContainsLetter(this string s, int numberOfOccurrences) => 
            s.Any(@char => s.Count(c => c == @char) == numberOfOccurrences);

        public static int Checksum(this string[] ids)
        {
            int twos = 0;
            int threes = 0;

            foreach (string id in ids)
            {
                if (id.ContainsLetter(2))
                    twos += 1;

                if (id.ContainsLetter(3))
                    threes += 1;
            }

            return twos * threes;
        }
    }
}
