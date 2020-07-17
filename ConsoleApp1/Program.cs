using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
            SaveAndLoadAsXml(dataSet);
            SaveAndLoadAsBinary(dataSet);
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
            DataRow person1 = personTable.NewRow();
            person1["Fam"] = "Иванов";
            person1["Name"] = "Иван";
            person1["Age"] = 18;
            personTable.Rows.Add(person1);
            person1 = personTable.NewRow();
            person1[1] = "Петров";
            person1[2] = "Петр";
            person1[3] = 28;
            personTable.Rows.Add(person1);
            //установка первичного ключа таблицы
            personTable.PrimaryKey = new[] { personTable.Columns[0] };
            dataSet.Tables.Add(personTable); //установка таблицы в контейнер
        }
        private static void PrintDataSet(DataSet dataSet)
        {
            Console.WriteLine($"DataSet id named: {dataSet.DataSetName}");
            foreach (DictionaryEntry de in dataSet.ExtendedProperties)
                Console.WriteLine($"Ключ = {de.Key}, значение = {de.Value}");
            Console.WriteLine("*************************************************");
            foreach (DataTable table in dataSet.Tables)
            {
                Console.WriteLine($"=> {table.TableName} Таблица:");
                for (var ci = 0; ci < table.Columns.Count; ci++)
                    Console.Write($"{table.Columns[ci].ColumnName}\t");
                Console.WriteLine("\n------------------------------------------------");
                //for (var ri = 0; ri < table.Rows.Count; ri++)
                //{
                //    for (var ci = 0; ci < table.Columns.Count; ci++)
                //        Console.Write($"{table.Rows[ri][ci]}\t");
                //    Console.WriteLine();
                //}
                PrintTable(table);
            }
        }
        private static void PrintTable(DataTable table)
        {
            DataTableReader reader = table.CreateDataReader();
            while (reader.Read())
            {
                for (var ci = 0; ci < reader.FieldCount; ci++)
                    Console.Write($"{reader.GetValue(ci).ToString().Trim()}\t");
                Console.WriteLine();
            }
            reader.Close();
        }
        private static void SaveAndLoadAsXml(DataSet sample)
        {
            sample.WriteXml("sample.xml");
            sample.WriteXmlSchema("sample.xsd"); //файл схемы данных
            sample.Clear();
            sample.ReadXml("sample.xml");
        }
        private static void SaveAndLoadAsBinary(DataSet sample)
        {
            sample.RemotingFormat = SerializationFormat.Binary;
            var bFormat = new BinaryFormatter();
            using (var stream = new FileStream("binarysample.bin", FileMode.Create))
            {
                bFormat.Serialize(stream, sample);
            }
            sample.Clear();
            using (var stream = new FileStream("binarysample.bin", FileMode.Open))
            {
                sample = (DataSet)bFormat.Deserialize(stream);
            }
        }
    }
}
