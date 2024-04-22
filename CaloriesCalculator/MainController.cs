using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaloriesCalculator
{
    public class MainController
    {
        public delegate void SetSummarize(uint calories, uint proteins, uint fats, uint carbohydrates, uint fibers);
        // здесь будем обновлять данные, вызывать подсчет и т.д.
        private List<Product> _products = new();
        private readonly Calculator _calculator = new();
        private readonly DBController _dbController = new();

        private event SetSummarize _summarizeEvent;

        public MainController(SetSummarize setSummarize)
        {
            _summarizeEvent = setSummarize;
        }
        public void Summarize()
        {
            // функция считает сумму
            // надо вызывать после каждого изменения списка(добавление, удаление, изменение)
            var sum = _calculator.Calculate(_products);
            _summarizeEvent(sum["Calorites"], sum["Proteins"], sum["Fats"], sum["Carbohydrates"], sum["Fibers"]);
        }
        public void AddProduct(uint id)
        {
            _products.Add(_dbController.GetProductById(id));
        }
        public void CreateProduct(string name, uint calories, uint proteins, uint fats, uint carbohydrates, uint fibers)
        {
            _dbController.AddProduct(name, calories, proteins, fats, carbohydrates, fibers);
        }
        public void DeleteProduct(uint id)
        {
            _dbController.RemoveProduct(id);
            RemoveProduct(id);
        }
        public void UpdateProduct(uint id, string name, uint calories, uint proteins, uint fats, uint carbohydrates, uint fibers)
        {
            _dbController.UpdateProduct(id, name, calories, proteins, fats, carbohydrates, fibers);
            var product = _products.Find(x => x.Id == id)!;
            product.Name = name;
            product.Calories = calories;
            product.Proteins = proteins;
            product.Fats = fats;
            product.Carbohydrates = carbohydrates;
            product.Fibers = fibers;
            _products[_products.FindIndex(x => x.Id == id)] = product;
        }
        public void RemoveProduct(uint id)
        {
            _products = _products.Where(product => product.Id != id).ToList();
        }
    }
}
