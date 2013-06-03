using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpTools.Functional.Option;

namespace SharpTests
{
    [TestClass]
    public class FunctionalOptionTest
    {
        [TestMethod]
        public void SomeAndSome()
        {
            var opt1 = Some.New("Hello");
            var opt2 = Some.New("World");

            var opt3 = opt1.Bind(o1 =>
                       opt2.Bind(o2 => Some.New(o1 + o2)));

            Assert.IsInstanceOfType(opt3, typeof(Some<string>));
            Assert.AreEqual("HelloWorld", (opt3 as Some<string>).Value);
        }

        [TestMethod]
        public void SomeAndNothing()
        {
            var opt1 = Some.New("Hello");
            var opt2 = Nothing.New<string>();

            var opt3 = opt1.Bind(o1 =>
                       opt2.Bind(o2 => {
                           Assert.Fail();
                           return Some.New(o1+o2);
                       }));

            Assert.IsInstanceOfType(opt3, typeof(Nothing<string>));
        }

        [TestMethod]
        public void SomeAndNothingWithAction()
        {
            var opt1 = Some.New("Hello");
            var opt2 = Nothing.New<string>();

            var opt3 = opt1.Bind(o1 =>
                       opt2.Bind(o2 => {
                           Assert.Fail();
                       }));

            Assert.IsInstanceOfType(opt3, typeof(Nothing<string>));
        }

        [TestMethod]
        public void ValueConversion()
        {
            var some = Some.New("HelloWorld");
            var nothing = Nothing.New<string>();

            Assert.AreEqual("HelloWorld", some.ToValue());
            Assert.AreEqual(null, nothing.ToValue());
        }

        [TestMethod]
        public void SomeAndSomeWithAction()
        {
            var opt1 = Some.New("Hello");
            var opt2 = Some.New("World");

            var opt3 = opt1.Bind(o1 => 
                       opt2.Bind(o2 => {
                           Assert.IsTrue(true);
                       }));
        }

        [TestMethod]
        public void NothingWhenNothing()
        {
            var opt1 = Nothing.New<bool>();

            opt1.WhenNothing(() => {
                Assert.IsTrue(true);
            });
        }

        [TestMethod]
        public void SomeWhenNothing()
        {
            var opt1 = Some.New(true);

            opt1.WhenNothing(() =>
            {
                Assert.Fail();
            });

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void DoubleBind()
        {
            var opt1 = Some.New("Hello");
            var opt2 = Some.New("World");

            var opt3 = opt1.BindWith(opt2, (o1, o2) =>
                            Some.New(o1 + o2));

            Assert.IsInstanceOfType(opt3, typeof(Some<string>));
            Assert.AreEqual("HelloWorld", (opt3 as Some<string>).Value);
        }

    }
}
