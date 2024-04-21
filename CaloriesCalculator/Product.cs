namespace CaloriesCalculator
{
    internal class Product(uint id, string name, uint calories, uint proteins, uint fats, uint carbohydrates)
    {
        public uint Id { get; set; } = id;
        public string Name { get; set; } = name;
        public uint Calories { get; set; } = calories;
        public uint Proteins { get; set; } = proteins;
        public uint Fats { get; set; } = fats;
        public uint Carbohydrates { get; set; } = carbohydrates;
    }
}
