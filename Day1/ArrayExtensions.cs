using System.Collections.Generic;

namespace Day1
{
    public static class ArrayExtensions
    {
        public static IEnumerable<T> Circular<T>(this T[] array)
        {
            while (true)
            {
                foreach (T item in array)
                {
                    yield return item;
                }
            }
        }
    }
}
