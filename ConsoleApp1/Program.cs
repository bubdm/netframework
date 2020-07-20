using ConsoleApp1.DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "sample.txt";

            FileManager manager = new FileManager();

            if (manager.FindFile(filename, new FileDataObject()))
                Console.WriteLine("Файл найден!");
            else
                Console.WriteLine("Файл не найден!");

            Console.ReadKey();
        }
    }
}
