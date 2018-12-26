using System.Collections.Generic;
using System.Linq;

namespace FunctionalExtensions
{
    public static class EnumerableExtensions
    {
        public static Option<T> SingleOrNone<T>(this IEnumerable<T> source) =>
            source?.ToArray().SingleOrNone() ?? None.Value;

        public static Option<T> SingleOrNone<T>(this T[] source) =>
            source?.Length == 1 ? (Option<T>) source[0] : None.Value;
    }
}
