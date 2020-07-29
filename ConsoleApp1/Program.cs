using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ClassLibrary1DAL;
using ClassLibrary1DAL.sampleDataSetTableAdapters;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var table = new sampleDataSet.PersonDataTable();
            var adapter = new PersonTableAdapter();
            adapter.Fill(table);
            PrintPerson(table);


            Console.WriteLine("Нажмите любую кнопку ...");
            Console.ReadKey();
            #region Old
            //string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=sample;Integrated Security=True";
            //DataSet data = new DataSet("sample");
            ////SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Person", connectionString);
            //var adapter = ConfigureNewAdapter(connectionString);
            ////дружественные к пользователю имена колонок
            //DataTableMapping tableMapping = adapter.TableMappings.Add("Fam","Family");
            //tableMapping.ColumnMappings.Add("Name", "Person Name");
            //tableMapping.ColumnMappings.Add("Age", "Person Ages");
            ////int count = adapter.Fill(data, "Person");
            //data.Tables.Add(GetAllPerson(adapter, out int count));
            //Console.WriteLine($"Кол-во строк: {count}");
            //PrintDataSet(data);
            //DataRow row = data.Tables["Person"].Select("Id = 1").First();
            //row["Name"] = "test1"; //изменение
            //UpdatePerson(adapter, data.Tables["Person"]);
            //Console.WriteLine("Изменение данных:");
            //PrintDataSet(data);
            //Console.WriteLine("Нажмите любую кнопку ...");
            //Console.ReadKey();
            //DataSet dataSet = new DataSet("Sample");
            //dataSet.ExtendedProperties["TimeStamp"] = DateTime.Now; //время создания
            //dataSet.ExtendedProperties["DataSetId"] = Guid.NewGuid(); //уникальный идентификтор
            //dataSet.ExtendedProperties["Company"] = "Пример";
            //FillDataSet(dataSet);
            ////SaveAndLoadAsXml(dataSet);
            //var newdata = SaveAndLoadAsBinary(dataSet);
            //PrintDataSet(dataSet);
            //PrintDataSet(newdata);
            //Console.WriteLine("Нажмите любую кнопку ...");
            //Console.ReadKey();
            #endregion
        }
        static void PrintPerson(sampleDataSet.PersonDataTable table)
        {
            Console.WriteLine($"=> {table.TableName} Таблица:");
            for (var ci = 0; ci < table.Columns.Count; ci++)
                Console.Write($"{table.Columns[ci].ColumnName}\t");
            Console.WriteLine("\n------------------------------------------------");
            for (var ri = 0; ri < table.Rows.Count; ri++)
            {
                for (var ci = 0; ci < table.Columns.Count; ci++)
                    Console.Write($"{table.Rows[ri][ci]}\t");
                Console.WriteLine();
            }
        }

        ///// <summary> Создание нового адаптера со всеми командами </summary>
        //private static SqlDataAdapter ConfigureNewAdapter(string connectionString)
        //{
        //    var adapter = new SqlDataAdapter("SELECT * FROM Person", connectionString);
        //    var _ = new SqlCommandBuilder(adapter); //конфигурирование остальных команд
        //    return adapter;
        //}
        ///// <summary> Заполнение только одной таблицы адаптером данных </summary>
        //private static DataTable GetAllPerson(SqlDataAdapter adapter, out int count)
        //{
        //    DataTable table = new DataTable("Person");
        //    count = adapter.Fill(table); //заполнение таблицы данными
        //    return table;
        //}
        ///// <summary> Обновление данных в таблице </summary>
        //private static void UpdatePerson(SqlDataAdapter adapter, DataTable table)
        //{
        //    adapter.Update(table); //обновление хранилища по таблице
        //}
        //private static void FillDataSet(DataSet dataSet)
        //{
        //    var personIdColumn = new DataColumn("Id", typeof(int))
        //    {
        //        Caption = "Id №",
        //        ReadOnly = true,
        //        AllowDBNull = false,
        //        Unique = true,
        //        AutoIncrement = true, //автоинкремент
        //        AutoIncrementSeed = 1,
        //        AutoIncrementStep = 1,
        //    };
        //    var personFamColumn = new DataColumn("Fam", typeof(string));
        //    var personNameColumn = new DataColumn("Name", typeof(string));
        //    var personAgeColumn = new DataColumn("Age", typeof(int));
        //    var personTable = new DataTable("Person");
        //    personTable.Columns.AddRange(new[] {personIdColumn, personFamColumn, personNameColumn, personAgeColumn});
        //    DataRow person1 = personTable.NewRow();
        //    person1["Fam"] = "Иванов";
        //    person1["Name"] = "Иван";
        //    person1["Age"] = 18;
        //    personTable.Rows.Add(person1);
        //    person1 = personTable.NewRow();
        //    person1[1] = "Петров";
        //    person1[2] = "Петр";
        //    person1[3] = 28;
        //    personTable.Rows.Add(person1);
        //    //установка первичного ключа таблицы
        //    personTable.PrimaryKey = new[] { personTable.Columns[0] };
        //    dataSet.Tables.Add(personTable); //установка таблицы в контейнер
        //}
        //private static void PrintDataSet(DataSet dataSet)
        //{
        //    Console.WriteLine($"DataSet id named: {dataSet.DataSetName}");
        //    foreach (DictionaryEntry de in dataSet.ExtendedProperties)
        //        Console.WriteLine($"Ключ = {de.Key}, значение = {de.Value}");
        //    Console.WriteLine("*************************************************");
        //    foreach (DataTable table in dataSet.Tables)
        //    {
        //        Console.WriteLine($"=> {table.TableName} Таблица:");
        //        for (var ci = 0; ci < table.Columns.Count; ci++)
        //            Console.Write($"{table.Columns[ci].ColumnName}\t");
        //        Console.WriteLine("\n------------------------------------------------");
        //        for (var ri = 0; ri < table.Rows.Count; ri++)
        //        {
        //            for (var ci = 0; ci < table.Columns.Count; ci++)
        //                Console.Write($"{table.Rows[ri][ci]}\t");
        //            Console.WriteLine();
        //        }
        //        //PrintTable(table);
        //    }
        //}
        //private static void PrintTable(DataTable table)
        //{
        //    DataTableReader reader = table.CreateDataReader();
        //    while (reader.Read())
        //    {
        //        for (var ci = 0; ci < reader.FieldCount; ci++)
        //            Console.Write($"{reader.GetValue(ci).ToString().Trim()}\t");
        //        Console.WriteLine();
        //    }
        //    reader.Close();
        //}
        //private static void SaveAndLoadAsXml(DataSet sample)
        //{
        //    sample.WriteXml("sample.xml");
        //    sample.WriteXmlSchema("sample.xsd"); //файл схемы данных
        //    sample.Clear();
        //    sample.ReadXml("sample.xml");
        //}
        //private static DataSet SaveAndLoadAsBinary(DataSet sample)
        //{
        //    DataSet retMe;
        //    sample.RemotingFormat = SerializationFormat.Binary;
        //    var bFormat = new BinaryFormatter();
        //    using (var stream = new FileStream("binarysample.bin", FileMode.Create))
        //    {
        //        bFormat.Serialize(stream, sample);
        //    }
        //    using (var stream = new FileStream("binarysample.bin", FileMode.Open))
        //    {
        //        retMe = (DataSet)bFormat.Deserialize(stream);
        //    }
        //    return retMe;
        //}
    }
}
