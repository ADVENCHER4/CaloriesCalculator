namespace CaloriesCalculator
{
    public class Product
    {

        public uint Id { get; set; }
        public string Name { get; set; }
        public uint Calories { get; set; }
        public uint Proteins { get; set; }
        public uint Fats { get; set; }
        public uint Carbohydrates { get; set; }
        public uint Fibers { get; set; }
        public Product(uint id, string name, uint calories, uint proteins, uint fats, uint carbohydrates, uint fibers)
        {
            Id = id;
            Name = name;
            Calories = calories;
            Proteins = proteins;
            Fats = fats;
            Carbohydrates = carbohydrates;
            Fibers = fibers;
        }
    }
}
