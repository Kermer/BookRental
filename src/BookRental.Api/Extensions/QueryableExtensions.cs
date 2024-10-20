using System.Linq.Expressions;

namespace BookRental.Api.Extensions;

public static class QueryableExtensions
{
    public static IQueryable<TSource> OrderBy<TSource, TKey>(this IQueryable<TSource> query, bool isDescending,  Expression<Func<TSource, TKey>> keySelector)
    {
        return isDescending ? query.OrderByDescending(keySelector) : query.OrderBy(keySelector);
    }
}
