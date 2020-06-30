using System;
using System.Data.SqlClient;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnectionStringBuilder sqlStringBuilder = new SqlConnectionStringBuilder
            {
                InitialCatalog = "autolot",
                DataSource = @"PNZASUTP\SQLEXPRESS",
                ConnectTimeout = 30,
                IntegratedSecurity = true,
            };
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = sqlStringBuilder.ConnectionString;
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Inventory", connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("Запись:");
                        for (int i = 0; i < reader.FieldCount; i++)
                            Console.WriteLine($"{reader.GetName(i)} = {reader.GetValue(i)}");
                        Console.WriteLine();
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
