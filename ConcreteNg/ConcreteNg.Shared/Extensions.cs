using ConcreteNg.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcreteNg.Shared
{
    public static class Extensions
    {
        public static IEnumerable<TSource> SortBy<TSource, TKey>(
            this IEnumerable<TSource> source,
            SortDirectionEnum sortDirection,
            Func<TSource, TKey> keySelector
        )
        {
            switch (sortDirection)
            {
                case SortDirectionEnum.Ascending:
                    return source.OrderBy(keySelector);
                case SortDirectionEnum.Descending:
                    return source.OrderByDescending(keySelector);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
