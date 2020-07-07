using System;
using AutoLotDAL.EF;
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
            Console.WriteLine("Нажмите любую кнопку ...");
            Console.ReadKey();
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
