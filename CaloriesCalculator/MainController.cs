using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaloriesCalculator
{
    internal class MainController
    {
        // Делегат для установки суммарной информации о пищевой ценности
        public delegate void SetSummarize(uint calories, uint proteins, uint fats, uint carbohydrates, uint fibers);

        // Список продуктов
        private List<Product> _products = new();
        private readonly Calculator _calculator = new();
        // Инициализация контроллера базы данных
        private readonly DBController _dbController = new();

        // Событие для установки суммарной информации
        private event SetSummarize _summarizeEvent;

        // Метод для получения списка продуктов
        public List<Product> GetProducts()
        {
            return _products;
        }

        // Конструктор класса, принимающий делегат для установки суммарной информации
        public MainController(SetSummarize setSummarize)
        {
            _summarizeEvent = setSummarize; 
        }

        // Метод для расчета и установки суммарной информации
        public void Summarize()
        {   // Расчет суммарной информации
            var sum = _calculator.Calculate(_products);
            // Установка суммарной информации через событие
            _summarizeEvent(sum["Calories"], sum["Proteins"], sum["Fats"], sum["Carbohydrates"], sum["Fibers"]); 
        }

        // Метод для добавления продукта в список
        public void AddProduct(uint id)
        {
            _products.Add(_dbController.GetProductById(id)); // Получение продукта из базы данных и добавление его в список
        }

        // Метод для создания нового продукта в базе данных
        public void CreateProduct(string name, uint calories, uint proteins, uint fats, uint carbohydrates, uint fibers)
        {
            _dbController.AddProduct(name, calories, proteins, fats, carbohydrates, fibers);
        }

        // Метод для удаления продукта из списка
        public void DeleteProduct(uint id)
        {
            _dbController.RemoveProduct(id);
            RemoveProduct(id);
        }

        // Метод для обновления информации о продукте в базе данных и списке
        public void UpdateProduct(uint id, string name, uint calories, uint proteins, uint fats, uint carbohydrates, uint fibers)
        {
            _dbController.UpdateProduct(id, name, calories, proteins, fats, carbohydrates, fibers); // Обновление информации о продукте в базе данных
            var product = _products.Find(x => x.Id == id)!; // Поиск продукта в списке
            product.Name = name; // Обновление информации о продукте
            product.Calories = calories;
            product.Proteins = proteins;
            product.Fats = fats;
            product.Carbohydrates = carbohydrates;
            product.Fibers = fibers;
            _products[_products.FindIndex(x => x.Id == id)] = product; // Обновление продукта в списке
        }

        // Метод для удаления продукта из списка
        public void RemoveProduct(uint id)
        {
            _products = _products.Where(product => product.Id != id).ToList(); // Удаление продукта из списка
        }
    }
}
