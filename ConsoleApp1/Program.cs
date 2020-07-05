using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Linq.Expressions;
using ConsoleApp1.EF;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //int carId = AddNewRecord();
            //Console.WriteLine(carId);
            //Inventory[] inventories =
            //{
            //    new Inventory{Make = "Test1", Color = "Bl1", Name = "HotName1"},
            //    new Inventory{Make = "Test2", Color = "Bl2", Name = "HotName2"},
            //};
            //AddNewRecords(inventories);
            //LINQPrintAllInventory();
            using (var context = new AutoLotEntities())
            {
                Console.WriteLine(context.Inventories.Find(9));
            }
            Console.ReadKey();
        }

        private static int AddNewRecord()
        {
            using (var context = new AutoLotEntities())
            {
                try
                {
                    var car = new Inventory() {Make = "Yugo", Color = "White", Name = "Green"};
                    context.Inventories.Add(car);
                    context.SaveChanges();
                    return car.CarId;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException?.Message);
                    return 0;
                }
            }
        }

        private static void AddNewRecords(IEnumerable<Inventory> cars)
        {
            using (var context = new AutoLotEntities())
            {
                context.Inventories.AddRange(cars);
                context.SaveChanges();
            }
        }

        private static void PrintAllInventory()
        {
            using (var context = new AutoLotEntities())
            {
                foreach (var el in context.Inventories)
                    Console.WriteLine(el);
            }
        }
        private static void SqlPrintAllInventory()
        {
            using (var context = new AutoLotEntities())
            {
                foreach (var el in context.Inventories.SqlQuery("SELECT CarId, Make, Color, Name FROM Inventory WHERE Make=@p0", "BMW"))
                    Console.WriteLine(el);
            }
        }

        public class ShortCar
        {
            public int CarId { get; set; }
            public string Make { get; set; }
            public override string ToString() => $"{this.Make} с Ид {this.CarId}";
        }

        private static void ShortPrintAllInventory()
        {
            using (var context = new AutoLotEntities())
            {
                foreach (var el in context.Database.SqlQuery(typeof(ShortCar),"SELECT CarId, Make FROM Inventory"))
                    Console.WriteLine(el);
            }
        }

        private static void LINQPrintAllInventory()
        {
            using (var context = new AutoLotEntities())
            {
                foreach (var el in context.Inventories.Where(i => i.Make == "BMW"))
                    Console.WriteLine(el);
                Console.WriteLine("новые данные:");
                var colorMakes = context.Inventories.Select(i => new {i.Color, i.Make});
                foreach (var el in colorMakes)
                    Console.WriteLine(el);
                var colorBlack = context.Inventories.Where(i => i.Color == "Black");
                foreach (var el in colorBlack)
                    Console.WriteLine(el);
            }
        }
}
}
