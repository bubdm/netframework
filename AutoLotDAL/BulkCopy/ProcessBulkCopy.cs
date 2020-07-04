using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLotDAL.BulkCopy
{
    public static class ProcessBulkCopy
    {
        private static readonly string _connectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AutoLot;Integrated Security=True";
        private static SqlConnection _sqlConnection = null;
        private static void OpenConnection()
        {
            _sqlConnection = new SqlConnection { ConnectionString = _connectionString };
            _sqlConnection.Open();
        }
        private static void CloseConnection()
        {
            if (_sqlConnection?.State != ConnectionState.Closed)
                _sqlConnection.Close();
        }
        public static void ExecuteBulkCopy<T>(IEnumerable<T> records, string tableName)
        {
            OpenConnection();
            using (SqlConnection conn = _sqlConnection)
            {
                SqlBulkCopy bc = new SqlBulkCopy(conn)
                {
                    DestinationTableName = tableName
                };
                var reader = new MyDataReader<T> {Records = records.ToList()};
                try
                {
                    bc.WriteToServer(reader);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка!\n" + ex.Message);
                }
                finally
                {
                    CloseConnection();
                }
            }
        }
    }
}
