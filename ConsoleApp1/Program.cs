using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using ConsoleApp1.EF;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int carId = AddNewRecord();
            Console.WriteLine(carId);
            Car[] cars =
            {
                new Car{Make = "Test1", Color = "Bl1", TopName = "HotName1"},
                new Car{Make = "Test2", Color = "Bl2", TopName = "HotName2"},
            };
            AddNewRecords(cars);
            Console.ReadKey();
        }

        private static int AddNewRecord()
        {
            using (var context = new AutoLotEntities())
            {
                try
                {
                    var car = new Car() {Make = "Yugo", Color = "White", TopName = "Green"};
                    context.Cars.Add(car);
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

        private static void AddNewRecords(IEnumerable<Car> cars)
        {
            using (var context = new AutoLotEntities())
            {
                context.Cars.AddRange(cars);
                context.SaveChanges();
            }
        }
    }
}
