using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.ExceptionServices;

namespace VanFosson.EnumerableExtensions.Core
{
    public static class EnumerableExtensions
    {
        private static readonly Type _enumerableType = typeof(Enumerable);

        public static IEnumerable CastAsType<T>(this IEnumerable<T> source, Type targetType)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            var typedArray = Array.CreateInstance(targetType, source.Count());

            var index = 0;
            foreach (var elem in source)
            {
                typedArray.SetValue(elem, index++);
            }
            
            return typedArray;
        }

        public static IList ToListOfType<T>(this IEnumerable<T> source, Type targetType)
        {
            return (IList)CastAsType(source, targetType);
        } 
    }
}
