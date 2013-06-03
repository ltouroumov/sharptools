using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpTools.Functional;

namespace SharpTests
{
    [TestClass]
    public class FunctionalCompositionTest
    {
        [TestMethod]
        public void SimpleCompose()
        {
            Func<int, int> func1 = (a) => a + 1;
            Func<int, int> func2 = (a) => a * 2;

            var func3 = func1.Compose(func2);
            var func4 = func2.Compose(func1);

            Assert.AreEqual((10 * 2) + 1, func3(10));
            Assert.AreEqual((10 + 1) * 2, func4(10));
        }

        [TestMethod]
        public void SimpleAndThen()
        {
            Func<int, int> func1 = (a) => a + 1;
            Func<int, int> func2 = (a) => a * 2;

            var func3 = func1.AndThen(func2);
            var func4 = func2.AndThen(func1);

            Assert.AreEqual((10 + 1) * 2, func3(10));
            Assert.AreEqual((10 * 2) + 1, func4(10));
        }
    }
}
