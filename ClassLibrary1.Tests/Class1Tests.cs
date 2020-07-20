using System;
using System.IO;
using ConsoleApp1.DataAccessObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleApp1.Tests
{
    [TestClass]
    public class FileManagerTests
    {
        [TestMethod]
        public void FindFile_DI_True()
        {
            DataAccessFactory.SetDataAccessObject(new StubFileDataObject());
            FileManager fileManager = new FileManager();
            string filename = "file1.txt";

            bool actual = fileManager.FindFile(filename);

            Assert.IsTrue(actual);
        }
    }
}
