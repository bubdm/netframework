using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassLibrary1.Tests
{
    [TestClass]
    public class Class1Tests
    {
        [TestMethod]
        public void GetSqrt_4_return2()
        {
            const double x = 4.0;
            const double expected = 2.0;

            double actual = Class1.GetSqrt(x);

            Assert.AreEqual(expected, actual, $"Sqrt {x} должен быть = {expected}, а не {actual}");
        }
        [TestMethod]
        public void GetSqrt_10_return3_1_d_0_1()
        {
            const double expected = 3.1;
            const double delta = 0.1;

            double actual = Class1.GetSqrt(10);

            Assert.AreEqual(expected, actual, delta, "ошибка!");
        }
        [TestMethod]
        public void StringAreEqual()
        {
            const string inp = "hello";
            const string expected = "HELLO";
            //игнорирование регистра
            Assert.AreEqual(expected, inp, true);
        }
        [TestMethod]
        public void StringsAreSame()
        {
            string a = "hello";
            string b = "hello";
            //равенство ссылок
            Assert.AreSame(a, b);
        }
    }
}
