using ConcreteNg.Shared.Enums;
using ConcreteNg.Shared.Models;
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
            bool isAscending,
            Func<TSource, TKey> keySelector
        )
        {
            if (isAscending)
            {
                return source.OrderBy(keySelector);
            }
            else
            {
                return source.OrderByDescending(keySelector);
            }
        }
    }
}
