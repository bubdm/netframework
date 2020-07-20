using System;
using System.IO;
using ConsoleApp1.DataAccessObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleApp1.Tests
{
    class FileManagerOverTest : FileManager
    {
        protected override IDataAccess CreateDataAccess()
        {
            return new StubFileDataObject(); //переопределение на заглушку
        }
    }
    [TestClass]
    public class FileManagerTests
    {
        [TestMethod]
        public void FindFile_DI_True()
        {
            FileManager fileManager = new FileManagerOverTest();
            string filename = "file1.txt";

            bool actual = fileManager.FindFile(filename);

            Assert.IsTrue(actual);
        }
    }
}
