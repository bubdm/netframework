using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoLotDAL.Modes;

namespace AutoLotDAL.DataOperations
{
    public class InventoryDAL
    {
        private readonly string _connectionString;
        public InventoryDAL() : this(@"Data Source=PNZASUTP\SQLEXPRESS;Initial Catalog=AutoLot;Integrated Security=True") { }
        public InventoryDAL(string connectionString)
        {
            _connectionString = connectionString;
        }
        private SqlConnection _sqlConnection = null;
        private void OpenConnection()
        {
            _sqlConnection = new SqlConnection { ConnectionString = _connectionString };
            _sqlConnection.Open();
        }
        private void CloseConnection()
        {
            if (_sqlConnection?.State != ConnectionState.Closed)
                _sqlConnection.Close();
        }
        public List<Car> GetAllInventory()
        {
            OpenConnection();
            List<Car> inventory = new List<Car>();
            string str = "SELECT * FROM Inventory";
            using (SqlCommand command = new SqlCommand(str, _sqlConnection))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    inventory.Add(new Car
                    {
                        CarId = (int)reader["CarId"],


                    });
                }
            }
            return inventory;
        }

    }
}
