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
            IDataAccess access = new StubFileDataObject();
            FileManager fileManager = new FileManager(access);
            string filename = "file1.txt";

            bool actual = fileManager.FindFile(filename);

            Assert.IsTrue(actual);
        }
    }
}
