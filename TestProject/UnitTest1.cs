using CaloriesCalculator;
using Newtonsoft.Json.Linq;


namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        List<Product> products = new()
        {
            new Product(0, "Product 1", 100, 200, 300, 400, 500),
            new Product(1, "Product 2", 150, 250, 350, 450, 550),
            new Product(2, "Product 3", 155, 255, 355, 455, 555),
        };
        MainController controller;
        [TestCleanup]
        public void testClean()
        {
            controller = null;
        }
        [TestInitialize]
        public void testInit()
        {
            controller = new(null);
        }

        [TestMethod]
        public void TestCalculate()
        {
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
        public void TestAddProduct()
        {

        }
        [TestMethod]
        public void TestRemoveProduct()
        {

        }
    }
}