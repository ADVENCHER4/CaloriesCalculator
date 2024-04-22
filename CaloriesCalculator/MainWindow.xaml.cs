using MySql.Data.MySqlClient;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        MainController controller;
        private double activity = 0;
        public double Activity
        {
            get { return activity; }
            set { activity = value; OnPropertyChanged(); }
        }

        private double drink = 0;
        public double Drink
        {
            get { return drink; }
            set { drink = value; OnPropertyChanged(); }
        }

        private uint calories = 0;
        public uint Calories
        {
            get { return calories; }
            set { calories = value; OnPropertyChanged(); }
        }

        private uint carbohydrates = 0;
        public uint Carbohydrates
        {
            get { return carbohydrates; }
            set { carbohydrates = value; OnPropertyChanged(); }
        }

        private uint fats = 0;
        public uint Fats
        {
            get { return fats; }
            set { fats = value; OnPropertyChanged(); }
        }

        private uint proteins = 0;
        public uint Proteins
        {
            get { return proteins; }
            set { proteins = value; OnPropertyChanged(); }
        }

        private uint fibers = 0;
        public uint Fibers
        {
            get { return fibers; }
            set { fibers = value; OnPropertyChanged(); }
        }


        public MainWindow()
        {
            InitializeComponent();
            controller = new MainController(UpdateSummary);
            DataContext = this;
            UpdatePage();
        }
        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private void UpdatePage()
        {
            dataGrid.Items.Clear();
            controller.Summarize();
            foreach (var product in controller.GetProducts())
            {
                dataGrid.Items.Add(product);
            }
        }
        private void UpdateSummary(uint calories, uint proteins, uint fats, uint carbohydrates, uint fibers)
        {
            Calories = calories;
            Proteins = proteins;
            Fats = fats;
            Carbohydrates = carbohydrates;
            Fibers = fibers;
        }
        private void Eating_Click(object sender, RoutedEventArgs e)
        {
            EatingInputDialog eatingInputDialog = new EatingInputDialog();
            if (eatingInputDialog.ShowDialog() == true)
            {
                uint selectedNumber = eatingInputDialog.SelectedNumber;
                controller.AddProduct(selectedNumber);
            }
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
                controller.RemoveProduct(selectedProduct.Id);
                dataGrid.Items.Remove(selectedProduct);
                UpdatePage();
            }
        }
    }
}