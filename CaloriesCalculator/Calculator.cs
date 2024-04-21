namespace CaloriesCalculator
{
    internal class Calculator
    {
        // тут будет вся логика типо рассчета и т.д.
        public Dictionary<string, uint> Calculate(List<Product> products)
        {
            var calculations = new Dictionary<string, uint>()
            {
                {"Calories", 0 },
                {"Proteins", 0 },
                {"Fats", 0 },
                {"Carbohydrates", 0 },
                {"Fibers", 0 },
            };
            foreach (var product in products)
            {
                calculations["Calorites"] += product.Calories;
                calculations["Proteins"] += product.Proteins; 
                calculations["Fats"] += product.Fats; 
                calculations["Carbohydrates"] += product.Carbohydrates;
                calculations["Fibers"] += product.Fibers;
            }
            return calculations;
        }
    }
}
