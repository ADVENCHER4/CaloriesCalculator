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
            new Product { Id = 1, Name = "Apple", Calories = 52, Proteins = 0.26, Fats = 0.17, Carbohydrates = 13.81 },
            new Product { Id = 2, Name = "Banana", Calories = 89, Proteins = 1.09, Fats = 0.33, Carbohydrates = 22.84 },
            new Product { Id = 3, Name = "Orange", Calories = 47, Proteins = 0.94, Fats = 0.12, Carbohydrates = 11.75 }
        };
   
        //активность(сколько человек сжёг калорий скажем за бег)
        public Double Activity { get; set; } = 0;
        //количесвтво выпитой воды
        //вообще ещё можно будет подключить другие напитки
        //(кофе энергетики в которых есть углеводы)
        public Double Drink { get; set; } = 0;

        //калорий за день
        public Double Calories { get; set; } = 0;
        //углеводы
        public Double Carbohydrates { get; set; } = 0;
        //жиры
        public Double Fats { get; set; } = 0;
        //белки
        public Double Proteins { get; set; } = 0;
        //клетчка(волокно)
        public Double Fibers { get; set; } = 0;


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