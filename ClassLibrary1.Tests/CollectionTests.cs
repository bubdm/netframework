using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary1.Tests
{
    [TestClass]
    public class CollectionTests
    {
        static List<string> employees;
        [ClassInitialize]
        public static void InitializeClass(TestContext context)
        {
            employees = new List<string>();
            employees.Add("Ivan");
            employees.Add("Segey");
            employees.Add("Anton");
            employees.Add("Roman");
        }
        [TestMethod]
        public void TestAreNoNull()
        {
            CollectionAssert.AllItemsAreNotNull(employees, "Ошибка NotNull");
        }
        [TestMethod]
        public void TestAreUnique()
        {
            CollectionAssert.AllItemsAreUnique(employees, "Ошибка уникальности");
        }
        [TestMethod]
        public void TestAreEqual()
        {
            var employees2 = new List<string>();
            employees2.Add("Ivan");
            employees2.Add("Segey");
            employees2.Add("Anton");
            employees2.Add("Roman");
            //равенство коллекций полное
            CollectionAssert.AreEqual(employees2, employees);
        }
        [TestMethod]
        public void TestAreEquivalent()
        {
            var employees2 = new List<string>();
            employees2.Add("Anton");
            employees2.Add("Roman");
            employees2.Add("Ivan");
            employees2.Add("Segey");
            //равенство элементов коллекций, порядок не важен
            CollectionAssert.AreEquivalent(employees2, employees);
        }
        [TestMethod]
        public void TestSubset()
        {
            var employees2 = new List<string>();
            employees2.Add(employees[1]);
            employees2.Add(employees[2]);
            //проверка нахождения элементов первой коллекции во второй
            CollectionAssert.IsSubsetOf(employees2, employees);
        }
    }
}
