namespace FunctionalExtensions
{
    public static class EnumerableExtensions
    {
        public static Option<T> SingleOrNone<T>(this T[] source)
        {
            if (source == null)
                return None.Value;

            return source.Length == 1
                       ? (Option<T>)source[0]
                       : None.Value;
        }
    }
}
