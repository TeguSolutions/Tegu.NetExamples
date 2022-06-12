using Microsoft.EntityFrameworkCore.Query;

namespace Tegu.Net.Backend.Data.SQL.Utils;

public static class EfExtensions
{
    public static IQueryable<T> If<T>(this IQueryable<T> source, bool condition, Func<IQueryable<T>, IQueryable<T>> transform)
    {
        return condition ? transform(source) : source;
    }

    public static IQueryable<T> If<T, P>(this IIncludableQueryable<T, P> source, bool condition, Func<IIncludableQueryable<T, P>, IQueryable<T>> transform) where T : class
    {
        return condition ? transform(source) : source;
    }

    public static IQueryable<T> If<T, P>(this IIncludableQueryable<T, IEnumerable<P>> source, bool condition, Func<IIncludableQueryable<T, IEnumerable<P>>, IQueryable<T>> transform) where T : class
    {
        return condition ? transform(source) : source;
    }
}