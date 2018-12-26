using System.Collections.Generic;
using System.Linq;

namespace Day1
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Circular<T>(this IEnumerable<T> sequence)
        {
            List<T> list = sequence.ToList();

            while (true)
            {
                foreach (T item in list)
                {
                    yield return item;
                }
            }
        }
    }
}
