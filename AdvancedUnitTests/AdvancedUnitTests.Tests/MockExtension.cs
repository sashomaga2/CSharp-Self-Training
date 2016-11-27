using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedUnitTests.Tests
{
    public static class MockExtension
    {
        public static Mock<T> AsMock<T>(this T obj) where T: class
        {
            return Mock.Get(obj);
        }

        public static IEnumerable<bool> BothEquals<T> (this T sut, T other)
        {
            yield return sut.Equals((object)other);
            yield return sut.Equals(other);
        }


    }
}
