using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace CaloriesCalculator
{
    /// <summary>
    /// Логика взаимодействия для DrinkingInputDialog.xaml
    /// </summary>
    public partial class DrinkingInputDialog : Window
    {
        public float Drink { get; set; } = 0;
        public DrinkingInputDialog()
        {
            InitializeComponent();
        }
        private void OK_Click(object sender, RoutedEventArgs e)
        {
            if (float.TryParse(txtDrink.Text, out float drink) && drink >= 0)
            {
                Drink = drink;
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Введите некорректное значение объёма воды.");
            }
        }
    }
}
