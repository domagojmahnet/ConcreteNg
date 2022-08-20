using ConcreteNg.Shared.Enums;
using ConcreteNg.Shared.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
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

        public class JsonIgnoreAttributeIgnorerContractResolver : DefaultContractResolver
        {
            protected override Newtonsoft.Json.Serialization.JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            {
                var property = base.CreateProperty(member, memberSerialization);
                property.Ignored = false; // Here is the magic
                return property;
            }
        }
    }
}
