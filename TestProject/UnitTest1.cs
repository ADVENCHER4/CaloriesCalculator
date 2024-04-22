using CaloriesCalculator;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        MainController controller;
        DBController dbController = new();
        [TestCleanup]
        public void TestClean()
        {
            controller = null;                      // после каждого теста удаляем контроллер
        }
        [TestInitialize]
        public void TestInit()
        {
            controller = new(null);                 // перед каждым тестом созадем новый главный контроллер
        }

        [TestMethod]
        public void TestCalculate()                 // тест правильности расчетов кбжу
        {
            var products = new List<Product>()
            {
                new Product(0, "Product 1", 100, 200, 300, 400, 500),
                new Product(1, "Product 2", 150, 250, 350, 450, 550),
                new Product(2, "Product 3", 155, 255, 355, 455, 555),
            };
            var calculator = new Calculator();
            var expectedResult = new Dictionary<string, uint>()
            {
                {"Calories", 405 },
                {"Proteins", 705 },
                {"Fats", 1005 },
                {"Carbohydrates", 1305 },
                {"Fibers", 1605 },
            };
            var result = calculator.Calculate(products);
            foreach (var item in result)
            {
                Assert.AreEqual(expectedResult[item.Key], item.Value);
            }
        }
        [TestMethod]
        public void TestGetProduct()                // тест работоспособности получения продукта из бд
        {
            var product = dbController.GetProductById(1);
            Assert.IsNotNull(product);
        }
        [TestMethod]
        public void TestUpdateProduct()             // тест работоспособности изменения продутка в бд
        {
            dbController.UpdateProduct(1, "Updated Product", 100, 100, 100, 100, 100);
            var product = dbController.GetProductById(1);
            Assert.AreEqual(product.Name, "Updated Product");
        }
        [TestMethod]
        public void TestAddProduct()                // тест работоспособности добавления продукта в список для расчета
        {
            var oldCount = controller.GetProducts().Count;
            controller.CreateProduct("Product 1", 100, 200, 300, 400, 500);
            controller.AddProduct(8);
            var newCount = controller.GetProducts().Count;
            Assert.AreNotEqual(newCount, oldCount);
        }
        [TestMethod]
        public void TestRemoveProduct()             // тест работоспособности удаления продукта из списка для расчета
        {
            controller.AddProduct(9);
            var oldCount = controller.GetProducts().Count;
            controller.RemoveProduct(9);
            var newCount = controller.GetProducts().Count;
            Assert.AreNotEqual(newCount, oldCount);
        }
        [TestMethod]
        public void TestDeleteProduct()             // тест работоспособности удаления продукта из бд
        {
            var oldCount = dbController.GetAllProducts().Count;
            dbController.RemoveProduct(8);
            var newCount = dbController.GetAllProducts().Count;
            Assert.AreNotEqual(newCount, oldCount);
        }
    }
}