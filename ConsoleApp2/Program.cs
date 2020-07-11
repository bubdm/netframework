using System;
using SampleDAL.EF;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Database.SetInitializer(new SampleDataInitializer()); //удаление, создание и заполнение базы данных
            using (var context = new SampleEntities())
            {
                foreach (var el in context.Persons)
                    Console.WriteLine(el + " - " + el.Department.Name);
            }
            Console.WriteLine("Нажмите кнопку ...");
            Console.ReadKey();
        }
    }
}
