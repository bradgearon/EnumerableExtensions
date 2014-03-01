using System;
using System.Collections;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace VanFosson.EnumerableExtensions.Core.Tests
{
    [TestClass]
    public class ListOfTypeTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void When_the_source_is_null_an_exception_is_thrown()
        {
            IEnumerable<object> source = null;

            source.ToListOfType(typeof(string));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void When_the_type_is_null_an_exception_is_thrown()
        {
            IEnumerable<object> source = new List<object>();

            source.ToListOfType(null);
        }

        [TestMethod]
        public void When_the_type_can_be_cast_the_list_is_converted()
        {
            IEnumerable<object> source = new List<string> { "test", "more" };

            var enumerable = source.ToListOfType(typeof(string));

            foreach (var obj in enumerable)
            {
                Assert.IsInstanceOfType(obj, typeof(string));
            }
        }

        [TestMethod]
        public void When_the_type_can_be_cast_listastype_returns_an_ilist()
        {
            IEnumerable<object> source = new List<string> { "test", "more" };

            var enumerable = source.ToListOfType(typeof(string));

            Assert.IsInstanceOfType(enumerable, typeof(IList));
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public void When_the_type_cannot_be_cast_an_exception_is_thrown()
        {
            IEnumerable<object> source = new List<string> { "test", "more" };

            source.ToListOfType(typeof(int));
        }
    }
}
