using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassLibrary1.Tests
{
    [TestClass]
    public class TestInitAndClean
    {
        private MyCalc myCalc;
        private int item;
        [TestInitialize]
        public void TestInitialize()
        {
            Debug.WriteLine("TestInitialize");
            item = 10;
            myCalc = new MyCalc();
            myCalc.Add(item);
        }
        [TestCleanup]
        public void TestCleanup()
        {
            Debug.WriteLine("TestCleanup");
            myCalc.Dispose();
        }
        [TestMethod]
        public void MyCalc_Check_ConstainsItem()
        {
            CollectionAssert.Contains(myCalc.Items, item);
        }
        [TestMethod]
        public void MyCalc_RemoveItem_Empty()
        {
            int expected = 0;

            myCalc.Remove(0);

            Assert.AreEqual(expected, myCalc.Count);
        }
    }
}
