using MySql.Data.MySqlClient;
using System.Data;


namespace CaloriesCalculator
{
    class DBController
    {
        MySqlConnection _connection = new("server=localhost;port=3306;username=root;password=root;database=products");

        private void OpenConnection()
        {
            if (_connection.State == System.Data.ConnectionState.Closed)
                _connection.Open();
        }

        private void CloseConnection()
        {
            if (_connection.State == System.Data.ConnectionState.Open)
                _connection.Close();
        }
        public Product GetProductById(uint id)
        {
            OpenConnection();
            var command = new MySqlCommand("SELECT * FROM `products` WHERE `id` = @id", _connection);
            command.Parameters.Add("@id", MySqlDbType.UInt64).Value = id;
            var dataAdapter = new MySqlDataAdapter();
            dataAdapter.SelectCommand = command;
            var dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            var row = dataTable.Rows[0];
            CloseConnection();
            return new Product((uint)row["id"], (string)row["name"], (uint)row["calories"], (uint)row["proteins"], (uint)row["fats"], (uint)row["carbohydrates"], (uint)row["fibers"]);
        }
        public List<Product> GetAllProducts()
        {
            OpenConnection();
            var command = new MySqlCommand("SELECT * FROM `products`", _connection);
            var dataAdapter = new MySqlDataAdapter();
            dataAdapter.SelectCommand = command;
            var dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            var products = new List<Product>();
            foreach (DataRow row in dataTable.Rows)
            {
                products.Add(new Product((uint)row["id"], (string)row["name"], (uint)row["calories"], (uint)row["proteins"], (uint)row["fats"], (uint)row["carbohydrates"], (uint)row["fibers"]));
            }
            CloseConnection();
            return products;
        }
        public void AddProduct(string name, uint calories, uint proteins, uint fats, uint carbohydrates, uint fibers)
        {
            // TODO: validate data (not in this class)
            OpenConnection();
            var command = new MySqlCommand("INSERT INTO `products`(`name`, `calories`, `proteins`, `fats`, `carbohydrates`, `fibers`) VALUES(@name, @calories, @proteins, @fats, @carbohydrates, @fibers)", _connection);
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@calories", MySqlDbType.UInt64).Value = calories;
            command.Parameters.Add("@proteins", MySqlDbType.UInt64).Value = proteins;
            command.Parameters.Add("@fats", MySqlDbType.UInt64).Value = fats;
            command.Parameters.Add("@carbohydrates", MySqlDbType.UInt64).Value = carbohydrates;
            command.Parameters.Add("@fibers", MySqlDbType.UInt64).Value = fibers;
            command.ExecuteNonQuery();
            CloseConnection();
        }

        public void RemoveProduct(uint id)
        {
            OpenConnection();
            var command = new MySqlCommand("DELETE FROM `products`WHERE `id` = @id", _connection);
            command.Parameters.Add("@id", MySqlDbType.UInt64).Value = id;
            command.ExecuteNonQuery();
            CloseConnection();
        }

        public void UpdateProduct(uint id, string name, uint calories, uint proteins, uint fats, uint carbohydrates, uint fibers)
        {
            OpenConnection();
            var command = new MySqlCommand("UPDATE `products` SET `name` = @name, `calories` = @calories, `proteins` = @proteins, `fats` = @fats, `carbohydrates` = @carbohydrates, `fibers` = @fibers WHERE `id` = @id", _connection);
            command.Parameters.Add("@id", MySqlDbType.UInt64).Value = id;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@calories", MySqlDbType.UInt64).Value = calories;
            command.Parameters.Add("@proteins", MySqlDbType.UInt64).Value = proteins;
            command.Parameters.Add("@fats", MySqlDbType.UInt64).Value = fats;
            command.Parameters.Add("@carbohydrates", MySqlDbType.UInt64).Value = carbohydrates;
            command.Parameters.Add("@fibers", MySqlDbType.UInt64).Value = fibers;
            command.ExecuteNonQuery();
            CloseConnection();
        }
    }
}
