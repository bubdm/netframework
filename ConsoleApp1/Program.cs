using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {

        static void Main(string[] args)
        {
            DataSet dataSet = new DataSet("Sample");
            dataSet.ExtendedProperties["TimeStamp"] = DateTime.Now; //время создания
            dataSet.ExtendedProperties["DataSetId"] = Guid.NewGuid(); //уникальный идентификтор
            dataSet.ExtendedProperties["Company"] = "Пример";

            FillDataSet(dataSet);
            PrintDataSet(dataSet);
            Console.WriteLine("Нажмите любую кнопку ...");
            Console.ReadKey();
        }

        private static void FillDataSet(DataSet dataSet)
        {
            var personIdColumn = new DataColumn("Id", typeof(int))
            {
                Caption = "Id №",
                ReadOnly = true,
                AllowDBNull = false,
                Unique = true,
                AutoIncrement = true, //автоинкремент
                AutoIncrementSeed = 1,
                AutoIncrementStep = 1,
            };
            var personFamColumn = new DataColumn("Fam", typeof(string));
            var personNameColumn = new DataColumn("Name", typeof(string));
            var personAgeColumn = new DataColumn("Age", typeof(int));
            var personTable = new DataTable("Person");
            personTable.Columns.AddRange(new[] {personIdColumn, personFamColumn, personNameColumn, personAgeColumn});



        }

        private static void PrintDataSet(DataSet dataSet)
        {
            
        }
    }
}
