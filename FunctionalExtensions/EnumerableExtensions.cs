namespace FunctionalExtensions
{
    public static class EnumerableExtensions
    {
        public static Option<T> SingleOrNone<T>(this T[] source) =>
            source?.Length == 1 ? (Option<T>) source[0] : None.Value;
    }
}
