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
        public InventoryDAL() : this(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AutoLot;Integrated Security=True") { }
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
        /// <summary> Все автомобили </summary>
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
                        Make = (string)reader["Make"],
                        Color = (string)reader["Color"],
                        Name = (string)reader["Name"],
                    });
                }
                reader.Close();
            }
            return inventory;
        }
        /// <summary> Один автомобиль </summary>
        public Car GetCar(int id)
        {
            OpenConnection();
            Car car = null;
            string sql = $"SELECT * FROM Inventory WHERE CarId = @id";
            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.Parameters.Add("@id", SqlDbType.Int, -1).Value = id;
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    car = new Car
                    {
                        CarId = (int)reader["CarId"],
                        Make = (string)reader["Make"],
                        Color = (string)reader["Color"],
                        Name = (string)reader["Name"],
                    };
                }
                reader.Close();
            }
            return car;
        }
        /// <summary> Добавление автомобиля </summary>
        public void InsertCar(string make, string color, string name)
        {
            OpenConnection();
            string sql = $"INSERT INTO Inventory (Make, Color, Name) VALUES (@Make, @Color, @Name)";
            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.Parameters.Add("@Make", SqlDbType.NVarChar, 50).Value = make;
                command.Parameters.Add("@Color", SqlDbType.NVarChar, 50).Value = color;
                command.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = name;
                command.ExecuteNonQuery();
            }
            CloseConnection();
        }
        /// <summary> Добавление автомобиля </summary>
        public void InsertCar(Car car)
        {
            OpenConnection();
            string sql = $"INSERT INTO Inventory (Make, Color, Name) VALUES (@Make, @Color, @Name)";
            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.Parameters.Add("@Make", SqlDbType.NVarChar, 50).Value = car.Make;
                command.Parameters.Add("@Color", SqlDbType.NVarChar, 50).Value = car.Color;
                command.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = car.Name;
                command.ExecuteNonQuery();
            }
            CloseConnection();
        }
        /// <summary> Обновление имени автомобиля </summary>
        /// <param name="id"></param>
        public void UpdateCarName(int id, string newName)
        {
            OpenConnection();
            string sql = $"UPDATE Inventory SET Name = @Name WHERE CarId = @id";
            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = newName;
                command.Parameters.Add("@id", SqlDbType.Int, -1).Value = id;
                command.ExecuteNonQuery();
            }
            CloseConnection();
        }
        /// <summary> Удаление автомобиля </summary>
        public int DeleteCar(int id)
        {
            int retMe;
            OpenConnection();
            string sql = $"DELETE FROM Inventory WHERE CarId = @id";
            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.Parameters.Add("@id", SqlDbType.Int, -1).Value = id;
                try
                {
                    retMe = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Этот автомобиль уже заказан!", ex);
                }
            }
            CloseConnection();
            return retMe;
        }
        /// <summary> Получение имени автомобиля </summary>
        public string GetCarName(int carId)
        {
            OpenConnection();
            string carName = default;
            using (SqlCommand command = new SqlCommand("GetPetsName", _sqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter
                {
                    ParameterName = "@carID",
                    SqlDbType = SqlDbType.Int,
                    Value = carId,
                    Direction = ParameterDirection.Input,
                };
                command.Parameters.Add(parameter);
                parameter = new SqlParameter
                {
                    ParameterName = "@name",
                    SqlDbType = SqlDbType.Char,
                    Size = 10,
                    Direction = ParameterDirection.Output,
                };
                command.Parameters.Add(parameter);
                command.ExecuteNonQuery();
                carName = (string)command.Parameters["@name"].Value;
                CloseConnection();
            }
            return carName;
        }

        public void ProcessCreditRisk(int custId)
        {
            OpenConnection();
            string fName;
            string lName;
            var cmdSelect = new SqlCommand($"SELECT * FROM Customers WHERE CustId = @id", _sqlConnection);
            cmdSelect.Parameters.Add("@id", SqlDbType.Int, -1).Value = custId;
            using (var reader = cmdSelect.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    fName = (string) reader["FirstName"];
                    lName = (string) reader["LastName"];
                }
                else
                {
                    CloseConnection();
                    return;
                }
            }
            var cmdRemove = new SqlCommand($"DELETE FROM Customers WHERE CustId = @id", _sqlConnection);
            cmdRemove.Parameters.Add("@id", SqlDbType.Int, -1).Value = custId;
            var cmdInsert = new SqlCommand($"INSERT INTO CreditRisks (FirstName,LastName) VALUES (@fname, @lname)", _sqlConnection);
            cmdInsert.Parameters.Add("@fname", SqlDbType.NVarChar, -1).Value = fName;
            cmdInsert.Parameters.Add("@lname", SqlDbType.NVarChar, -1).Value = lName;
            SqlTransaction tx = null;
            try
            {
                tx = _sqlConnection.BeginTransaction();
                cmdInsert.Transaction = tx;
                cmdRemove.Transaction = tx;
                cmdInsert.ExecuteNonQuery();
                cmdRemove.ExecuteNonQuery();
                tx.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                tx?.Rollback();
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
