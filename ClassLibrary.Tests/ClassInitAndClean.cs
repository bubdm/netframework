using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace ClassLibrary1.Tests
{

    [TestClass]
    public class ClassInitAndClean
    {
        private static MyCalc myCalc;
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            Debug.WriteLine("ClassInitialize");
            myCalc = new MyCalc();
            int item = 10;
            myCalc.Add(item);
        }
        [ClassCleanup]
        public static void ClassCleanup()
        {
            Debug.WriteLine("ClassCleanup");
            myCalc.Dispose();
        }
        [TestMethod]
        public void MyCalc_AddItem()
        {
            int expected = myCalc.Count + 1;

            myCalc.Add(10);

            Assert.AreEqual(expected, myCalc.Count);
        }
        [TestMethod]
        public void MyCalc_DeleteItem()
        {
            int expected = myCalc.Count - 1;

            myCalc.Remove(0);

            Assert.AreEqual(expected, myCalc.Count);
        }
    }
}
