using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassLibrary1.Tests
{
    [TestClass]
    public class Class1Tests
    {
        public TestContext TestContext { get; set; }
        private Class1 class1 = new Class1();

        [DataTestMethod]
        [DataRow("Andrei", 18)]
        [DataRow("Maxim", 20)]
        [DataRow("Xianon", 22)]
        public void GoodDataTest_Data_Trues(string name, int age)
        {
            Assert.IsTrue(class1.Good(name, age));
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
            "testData.xml",
            "User",
            DataAccessMethod.Sequential)]
        public void Good_FromXML_Trues()
        {
            string name = Convert.ToString(TestContext.DataRow["name"]);
            int age = Convert.ToInt32(TestContext.DataRow["age"]);

            bool result = class1.Good(name, age);

            Assert.IsTrue(result);
        }




        [TestMethod]
        [DeploymentItem("Files\\ExamCreatedResult.txt")]
        [DeploymentItem("Files\\ExamCreatedTemplate.txt")]
        public void FromTemplate_PassTestValue_StringFromTemplateReturned()
        {
            Class1 class0 = new Class1();
            class0.TemplateFolder = "."; //текущая директория

            string expected = File.ReadAllText("ExamCreatedResult.txt");

            string actual = class0.FromTemplate("TestExam", "Beginer");

            Assert.AreEqual(expected, actual);
        }
    }
}
