using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassLibrary1.Tests
{
    [TestClass]
    public class Class1Tests
    {
        public TestContext TestContext { get; set; }
        private Class1 class1 = new Class1();

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
            "testData.xml",
            "User",
            DataAccessMethod.Sequential)]
        [TestMethod]
        public void Good_FromXML_Trues()
        {
            string name = Convert.ToString(TestContext.DataRow["name"]);
            int age = Convert.ToInt32(TestContext.DataRow["age"]);

            bool result = class1.Good(name, age);

            Assert.IsTrue(result);
        }
    }
}
