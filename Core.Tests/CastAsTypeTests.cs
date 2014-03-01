using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VanFosson.EnumerableExtensions.Core.Tests
{
    [TestClass]
    public class CastAsTypeTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void When_the_source_is_null_an_exception_is_thrown()
        {
            IEnumerable<object> source = null;

            source.CastAsType(typeof(string));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void When_the_type_is_null_an_exception_is_thrown()
        {
            IEnumerable<object> source = new List<object>();

            source.CastAsType(null);
        }

        [TestMethod]
        public void When_the_type_can_be_cast_the_list_is_converted()
        {
            IEnumerable<object> source = new List<string> { "test" , "more" };

            var enumerable = source.CastAsType(typeof(string));

            foreach (var obj in enumerable)
            {
                Assert.IsInstanceOfType(obj, typeof(string));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public void When_the_type_cannot_be_cast_an_exception_is_thrown_when_enumerated()
        {
            IEnumerable<object> source = new List<string> { "test", "more" };

            var enumerable = source.CastAsType(typeof(int));

            foreach (var obj in enumerable)
            {
                Assert.Fail("Type {0} could be cast", obj.GetType());
            }
        }
    }
}
