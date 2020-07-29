using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1DAL;
using ClassLibrary1DAL.sampleDataSetTableAdapters;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonTableAdapter adapter = new PersonTableAdapter();
            sampleDataSet.PersonDataTable table = adapter.GetData();
            //получение коллекции объектов
            var enumTable = table.AsEnumerable(); 
            Console.WriteLine("Список всех:");
            foreach (var el in enumTable)
                Console.WriteLine($"Имя: {el.Name} возраст: {el.Age}");
            //пример проецирования нового типа данных
            var pers20 = table.AsEnumerable().Where(p => p.Age == 20).Select(p => new { p.Fam, p.Name });
            Console.WriteLine("Все кому 20 лет:");
            foreach (var el in pers20)
                Console.WriteLine($"{el.Fam} {el.Name}");
            //пример безопасного проецирования нового типа данных
            var pers20safety = table.AsEnumerable().Where(p => p.Field<int>("Age") == 21).Select(p => new { Fam = p.Field<string>("Fam"), Name = p.Field<string>("Name") });
            Console.WriteLine("Все кому 21 год:");
            foreach (var el in pers20)
                Console.WriteLine($"{el.Fam} {el.Name}");
            //создание нового объекта DataTable
            var personsNew = table.AsEnumerable().Where(p => p.Id > 5);
            DataTable table2 = personsNew.CopyToDataTable();
            Console.WriteLine("Новая таблица:");
            var reader = table2.CreateDataReader();
            while (reader.Read())
                Console.WriteLine($"Фамилия: {reader.GetValue(1).ToString().Trim()}");

            Console.ReadKey();
        }
    }
}
