using MySql.Data.MySqlClient;
using System.Data;

//Контроллер для работы с базой данных
//Используется MySql
//Локальный сервер поднимается с помощью MAMP
namespace CaloriesCalculator
{
    class DBController
    {
        //Установка соединения с базой данных 
        MySqlConnection _connection = new("server=localhost;port=3306;username=root;password=root;database=products");

        //Открытие соединения
        private void OpenConnection()
        {
            if (_connection.State == System.Data.ConnectionState.Closed)
                _connection.Open();
        }
        //Закрытия соединения
        private void CloseConnection()
        {
            if (_connection.State == System.Data.ConnectionState.Open)
                _connection.Close();
        }
        //Метод для получения продукта по id
        public Product GetProductById(uint id)
        {
            OpenConnection();
            // Создаем команду SQL для выборки продукта по его идентификатору
            var command = new MySqlCommand("SELECT * FROM `products` WHERE `id` = @id", _connection);
            // Добавляем параметр @id к команде и устанавливаем его значение
            command.Parameters.Add("@id", MySqlDbType.UInt64).Value = id;
            // Создаем адаптер данных для выполнения команды
            var dataAdapter = new MySqlDataAdapter();
            dataAdapter.SelectCommand = command;
            // Создаем объект DataTable для хранения результатов запроса
            var dataTable = new DataTable();
            // Заполняем DataTable данными, полученными из базы данных
            dataAdapter.Fill(dataTable);
            // Получаем первую строку результата (предполагается, что она существует)
            var row = dataTable.Rows[0];
            // Закрываем соединение с базой данных
            CloseConnection();
            // Создаем новый объект Product на основе данных из строки результата и возвращаем его
            return new Product((uint)row["id"], (string)row["name"], (uint)row["calories"], (uint)row["proteins"], (uint)row["fats"], (uint)row["carbohydrates"], (uint)row["fibers"]);
        }
        // Получает все продукты из базы данных
        public List<Product> GetAllProducts()
        {
            OpenConnection(); // Устанавливает соединение с базой данных
            var command = new MySqlCommand("SELECT * FROM `products`", _connection); // SQL-команда для выбора всех продуктов
            var dataAdapter = new MySqlDataAdapter();
            dataAdapter.SelectCommand = command; // Присваивает команду адаптеру данных
            var dataTable = new DataTable(); // Создает новую таблицу данных для хранения результатов
            dataAdapter.Fill(dataTable); // Заполняет таблицу данными из команды
            var products = new List<Product>(); // Инициализирует список для хранения объектов Product
            foreach (DataRow row in dataTable.Rows) // Перебирает каждую строку в таблице данных
            {
                // Создает новый объект Product из каждой строки и добавляет его в список
                products.Add(new Product((uint)row["id"], (string)row["name"], (uint)row["calories"], (uint)row["proteins"], (uint)row["fats"], (uint)row["carbohydrates"], (uint)row["fibers"]));
            }
            CloseConnection(); // Закрывает соединение с базой данных
            return products;
        }

        // Добавляет новый продукт в базу данных
        public void AddProduct(string name, uint calories, uint proteins, uint fats, uint carbohydrates, uint fibers)
        {
            OpenConnection(); 
            // SQL-команда для вставки нового продукта
            var command = new MySqlCommand("INSERT INTO `products`(`name`, `calories`, `proteins`, `fats`, `carbohydrates`, `fibers`) VALUES(@name, @calories, @proteins, @fats, @carbohydrates, @fibers)", _connection); 
            // Добавляет параметры к команде для каждого столбца                                                                                                                                                                                              // Добавляет параметры к команде для каждого столбца
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@calories", MySqlDbType.UInt64).Value = calories;
            command.Parameters.Add("@proteins", MySqlDbType.UInt64).Value = proteins;
            command.Parameters.Add("@fats", MySqlDbType.UInt64).Value = fats;
            command.Parameters.Add("@carbohydrates", MySqlDbType.UInt64).Value = carbohydrates;
            command.Parameters.Add("@fibers", MySqlDbType.UInt64).Value = fibers;
            command.ExecuteNonQuery(); // Выполняет команду
            CloseConnection(); 
        }

        // Удаляет продукт из базы данных по его ID
        public void RemoveProduct(uint id)
        {
            OpenConnection(); // Устанавливает соединение с базой данных
            var command = new MySqlCommand("DELETE FROM `products` WHERE `id` = @id", _connection); // SQL-команда для удаления продукта по ID
            command.Parameters.Add("@id", MySqlDbType.UInt64).Value = id; // Добавляет параметр для ID
            command.ExecuteNonQuery();
            CloseConnection(); 
        }

        // Обновляет существующий продукт в базе данных
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
