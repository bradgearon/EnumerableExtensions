using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using System.Runtime.ExceptionServices;

namespace VanFosson.EnumerableExtensions.Core
{
    public static class EnumerableExtensions
    {
        private static readonly Type _enumerableType = typeof(Enumerable);

        public static IEnumerable CastAsType(this IEnumerable source, Type targetType)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            var castMethod = _enumerableType.GetMethod("Cast").MakeGenericMethod(targetType);

            return (IEnumerable)castMethod.Invoke(null, new object[] { source });
        } 

        public static IList ToListOfType(this IEnumerable source, Type targetType)
        {
            var enumerable = CastAsType(source, targetType);

            var listMethod = _enumerableType.GetMethod("ToList").MakeGenericMethod(targetType);

            try
            {
                return (IList)listMethod.Invoke(null, new object[] { enumerable });
            }
            catch (TargetInvocationException e)
            {
                ExceptionDispatchInfo.Capture(e.InnerException).Throw();
                return null; // to satisfy the compiler, never reached
            }
        } 
    }
}
