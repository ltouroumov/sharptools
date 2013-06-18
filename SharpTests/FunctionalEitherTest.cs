using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpTools.Functional.Either;

namespace SharpTests
{
    [TestClass]
    public class FunctionalEitherTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Either<string, int> leftValue = "Hello".AsLeft().WithRight<int>();
            Either<string, int> rightValue = 10.AsRight().WithLeft<string>();

            string leftString = null;
            int rightInt = 0;

            Assert.IsTrue(leftValue.Left(out leftString));
            Assert.IsTrue(rightValue.Right(out rightInt));

            Assert.IsFalse(leftValue.Right(out rightInt));
            Assert.IsFalse(rightValue.Left(out leftString));
        }
    }
}
