using System;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AutoLotDAL.Models;
using AutoLotDAL.Repos;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var repo = new InventoryRepo())
            {
                foreach (var el in repo.GetAll())
                {
                    Console.WriteLine(el);
                }
            }
            TestConcurrency();
            Console.WriteLine("Нажмите любую кнопку ...");
            Console.ReadKey();
        }

        /// <summary> Тест параллелизма </summary>
        private static void TestConcurrency()
        {
            var repo1 = new InventoryRepo();
            var repo2 = new InventoryRepo();
            var car1 = repo1.GetOne(1);
            var car2 = repo2.GetOne(1);
            car1.Name = "NewName";
            repo1.Save(car1);
            car2.Name = "OtherName";
            try
            {
                repo2.Save(car2);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var entry = ex.Entries.Single();
                var current = entry.CurrentValues;
                var original = entry.OriginalValues;
                var baseVal = entry.GetDatabaseValues();
                Console.WriteLine("Exception");
                Console.WriteLine($"Current: {current[nameof(Inventory.Name)]}");
                Console.WriteLine($"Orig: {original[nameof(Inventory.Name)]}");
                Console.WriteLine($"base: {baseVal[nameof(Inventory.Name)]}");
            }
        }

        /// <summary> Добавление </summary>
        private static void AddNewRecord(Inventory inventory)
        {
            using (var repo = new InventoryRepo())
            {
                repo.Add(inventory);
            }
        }
        /// <summary> Изменение </summary>
        private static void UpdateRecord(int carId)
        {
            using (var repo = new InventoryRepo())
            {
                var updateInv = repo.GetOne(carId);
                if (updateInv == null) return;
                updateInv.Color = "Blue";
                repo.Save(updateInv);
            }
        }
        /// <summary> Удаление </summary>
        private static void RemoveInv(Inventory deleteInventory)
        {
            using (var repo = new InventoryRepo())
            {
                repo.Delete(deleteInventory);
            }
        }
        /// <summary> Удаление по свойствам ключа </summary>
        private static void RemoveInv(int carId, byte[] timeStamp)
        {
            using (var repo = new InventoryRepo())
            {
                repo.Delete(carId, timeStamp);
            }
        }
    }
}
