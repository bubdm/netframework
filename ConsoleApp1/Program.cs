using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

using AutoLotDAL.EF;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Database.SetInitializer(new MyDataInitializer());
            Console.WriteLine("Список:");
            using (var context = new AutoLotEntities())
            {
                foreach (var el in context.Inventories)
                    Console.WriteLine(el);
            }
            Console.WriteLine("Нажмите любую кнопку ...");
            Console.ReadKey();
        }
    }
}
