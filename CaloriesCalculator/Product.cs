namespace CaloriesCalculator
{
    public class Product
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public double Calories { get; set; }
        public double Proteins { get; set; }
        public double Fats { get; set; }
        public double Carbohydrates { get; set; }

        public Product(uint id, string name, double calories, double proteins, double fats, double carbohydrates)
        {
            Id = id;
            Name = name;
            Calories = calories;
            Proteins = proteins;
            Fats = fats;
            Carbohydrates = carbohydrates;
        }
        public Product() { }   
    }
}
