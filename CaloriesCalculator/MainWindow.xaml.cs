using MySql.Data.MySqlClient;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CaloriesCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Apple", Calories = 52, Proteins = 0, Fats = 1, Carbohydrates = 14, Fibers=1 },
            new Product { Id = 2, Name = "Banana", Calories = 89, Proteins = 1, Fats =1, Carbohydrates = 13, Fibers = 1},
            new Product { Id = 3, Name = "Orange", Calories = 47, Proteins = 1, Fats = 1, Carbohydrates = 12, Fibers = 1}
        };
   
        //активность(сколько человек сжёг калорий скажем за бег)
        public double Activity { get; set; } = 0;
        //количесвтво выпитой воды
        //вообще ещё можно будет подключить другие напитки
        //(кофе энергетики в которых есть углеводы)
        public Double Drink { get; set; } = 0;

        //калорий за день
        public uint Calories { get; set; } = 0;
        //углеводы
        public uint Carbohydrates { get; set; } = 0;
        //жиры
        public uint Fats { get; set; } = 0;
        //белки
        public uint Proteins { get; set; } = 0;
        //клетчка(волокно)
        public uint Fibers { get; set; } = 0;


        public MainWindow()
        {
            InitializeComponent();
            UpdatePage();
            DataContext = this;
        }
        private void UpdatePage()
        {
            dataGrid.Items.Clear();
            foreach (var product in products)
            {
                dataGrid.Items.Add(product);
                Calories += product.Calories;
                Carbohydrates += product.Carbohydrates;
                Fats += product.Fats;
                Proteins += product.Proteins;
                Fibers += product.Fibers;
            }

        }

        private void Eating_Click(object sender, RoutedEventArgs e)
        {
            EatingInputDialog eatingInputDialog = new EatingInputDialog();

            UpdatePage();
        }
        private void Drinking_Сlick(object sender, RoutedEventArgs e)
        {
            DrinkingInputDialog drinkingInput = new DrinkingInputDialog();
            if (drinkingInput.ShowDialog() == true)
            {
                Drink += drinkingInput.Drink;
            }
        }

        private void Activity_Click(object sender, RoutedEventArgs e)
        {
            ActivityInputDialog activityInputDialog = new ActivityInputDialog();
            if (activityInputDialog.ShowDialog() == true)
            {
                Activity += activityInputDialog.Activity;
            }
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.SelectedItem != null)
            {
                Product selectedProduct = (Product)dataGrid.SelectedItem;
                products.Remove(selectedProduct);
                dataGrid.Items.Remove(selectedProduct);
            }
        }
    }
}