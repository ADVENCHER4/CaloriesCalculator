using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaloriesCalculator
{
    class DBController
    {
        MySqlConnection _connection = new("server=localhost;port=3306;username=root;password=root;database=products");

        private void OpenConnection()
        {
            if(_connection.State == System.Data.ConnectionState.Closed)
                _connection.Open();
        }

        private void CloseConnection()
        {
            if (_connection.State == System.Data.ConnectionState.Open)
                _connection.Close();
        }
        public Product GetProductById(int id)
        {
            OpenConnection();
            var dataTable = new DataTable();
            var dataAdapter = new MySqlDataAdapter();
            var command = new MySqlCommand("SELECT * FROM `products` WHERE `id` = @pId");
            command.Parameters.Add("@pId", MySqlDbType.UInt64).Value = id;
            dataAdapter.SelectCommand = command;
            command.Connection = _connection;
            dataAdapter.Fill(dataTable);
            var row = dataTable.Rows[0];
            Debug.WriteLine(dataTable.Rows);
            CloseConnection();
            return new Product((uint)row["id"], (string)row["name"], (uint)row["calories"], (uint)row["proteins"], (uint)row["fats"], (uint)row["carbohydrates"]);
        }
    }
}
