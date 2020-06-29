using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp1
{


    class Program
    {
        static void Main(string[] args)
        {
            string dataProvider = ConfigurationManager.AppSettings["provider"];
            string connectionString = ConfigurationManager.AppSettings["connectionString"];

            DbProviderFactory factory = DbProviderFactories.GetFactory(dataProvider);
            using (DbConnection connection = factory.CreateConnection())
            {
                if (connection == null)
                {
                    WriteLine("Ошибка создания объекта Connection");
                    ReadKey();
                    return;
                }
                connection.ConnectionString = connectionString;
                connection.Open();
                DbCommand command = factory.CreateCommand();
                if (command == null)
                {
                    WriteLine("Ошибка создания объекта Command");
                    ReadKey();
                    return;
                }
                command.Connection = connection;
                command.CommandText = "SELECT * FROM Inventory";
                using (DbDataReader dataReader = command.ExecuteReader())
                {
                    WriteLine("Таблица Inventory:");
                    while (dataReader.Read())
                        WriteLine($"-> Автомобиль {dataReader["CarId"]} это {dataReader["Make"]}.");
                }
            }
            ReadKey();
        }
    }
}
