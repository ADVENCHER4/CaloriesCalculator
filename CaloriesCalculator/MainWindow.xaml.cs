using MySql.Data.MySqlClient;
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
        //масса тела
        private float Weight { get; set; } = 0;
        //активность(сколько человек сжёг калорий скажем за бег)
        private float Activity { get; set; } = 0;
        //количесвтво выпитой воды
        //вообще ещё можно будет подключить другие напитки
        //(кофе энергетики в которых есть углеводы)
        private float Drink { get; set; } = 0;

        //калорий за день
        private float Calories { get; set; } = 0;
        //углеводы
        private float Carbs { get; set; } = 0;
        //жиры
        private float Fats { get; set; } = 0;
        //белки
        private float Proteins { get; set; } = 0;
        //клетчка(волокно)
        private float Fibers { get; set; } = 0;


        private DateTime currentDate = DateTime.Today;
        public MainWindow()
        {
            InitializeComponent();
            UpdatePage();

        }
        private void UpdatePage()
        {
            //тут мы получаем данные из бд для это дня
            DateTextBlock.Text = currentDate.ToString("dd.MM");
        }

        private void PrevDay_Click(object sender, RoutedEventArgs e)
        {
            currentDate = currentDate.AddDays(-1);
            UpdatePage();
        }

        private void NextDay_Click(object sender, RoutedEventArgs e)
        {
            currentDate = currentDate.AddDays(1);
            UpdatePage();
        }
        private void Eating_Click(object sender, RoutedEventArgs e)
        {
            EatingInputDialog eatingInputDialog = new EatingInputDialog();
            MessageBox.Show("eat");
        }
        private void Drinking_Сlick(object sender, RoutedEventArgs e)
        {
            DrinkingInputDialog drinkingInput = new DrinkingInputDialog();
            if (drinkingInput.ShowDialog() == true)
            {
                Drink = drinkingInput.Drink;
            }
            MessageBox.Show("drink");
        }

        private void Weight_Click(object sender, RoutedEventArgs e)
        {
            WeightInputDialog weightInput = new WeightInputDialog();
            if (weightInput.ShowDialog() == true)
            {
                Weight = weightInput.Weight;
            }
        }

        private void Activity_Click(object sender, RoutedEventArgs e)
        {
            ActivityInputDialog activityInputDialog = new ActivityInputDialog();
            if (activityInputDialog.ShowDialog() == true)
            {
                Activity = activityInputDialog.Activity;
            }
            MessageBox.Show("activity");
        }
    }
}