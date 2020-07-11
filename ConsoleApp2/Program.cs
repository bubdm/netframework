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
                Console.WriteLine("Persons:");
                foreach (var per in context.Persons)
                    Console.WriteLine(per + " - " + per.Department.Name);
                Console.WriteLine("Departments:");
                foreach (var dep in context.Departments)
                {
                    Console.WriteLine(dep + ":");
                    foreach (var per in dep.Persons)
                        Console.WriteLine(per);
                }
            }
            Console.WriteLine("Нажмите кнопку ...");
            Console.ReadKey();
        }
    }
}
