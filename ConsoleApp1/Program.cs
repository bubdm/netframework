using System;
using System.Data.SqlClient;
using System.Linq;
using AutoLotDAL.DataOperations;
using AutoLotDAL.Modes;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            InventoryDAL inventory = new InventoryDAL();
            Console.WriteLine("Все:");
            var list = inventory.GetAllInventory();
            Console.WriteLine("Ид\tМарка\tЦвет\tНазвание");
            foreach(var el in list)
                Console.WriteLine($"{el.CarId}\t{el.Make}\t{el.Color}\t{el.Name}");
            Console.WriteLine();
            try
            {
                var count = inventory.DeleteCar(5);
                if (count != 0)
                    Console.WriteLine("Автомобиль удален");
                else
                    Console.WriteLine("Автомобиль не удален, так как не найден!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Автомобиль не удален");
                Console.WriteLine(ex.Message);
            }
            var car = inventory.GetCar(1);
            Console.WriteLine($"Один автомобиль: {car.Make} {car.Name} {car.Color}");
            inventory.InsertCar(new Car {Make = "One", Color = "Gray", Name = "Test"});
            list = inventory.GetAllInventory();
            var newCar = list.First(l => l.Name == "Test").CarId;
            inventory.UpdateCarName(newCar, "Новое имя");
            Console.WriteLine("После добавления и изменения:");
            list = inventory.GetAllInventory();
            Console.WriteLine("Ид\tМарка\tЦвет\tНазвание");
            foreach(var el in list)
                Console.WriteLine($"{el.CarId}\t{el.Make}\t{el.Color}\t{el.Name}");
            Console.WriteLine();
            var Name = inventory.GetCarName(newCar);
            Console.WriteLine($"Имя автомобиля: {Name}");
            inventory.DeleteCar(newCar);
            Console.WriteLine("После удаления:");
            list = inventory.GetAllInventory(); 
            Console.WriteLine("Ид\tМарка\tЦвет\tНазвание");
            foreach(var el in list)
                Console.WriteLine($"{el.CarId}\t{el.Make}\t{el.Color}\t{el.Name}");
            Console.ReadKey();
        }
    }
}
