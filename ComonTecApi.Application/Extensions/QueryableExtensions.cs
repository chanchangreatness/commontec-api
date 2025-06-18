namespace ComonTecApi.Application.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<TSource> Page<TSource>(this IQueryable<TSource> source, int page, int pageSize)
        {
            return source.Skip((page - 1) * pageSize).Take(pageSize);
        }
    }
}
