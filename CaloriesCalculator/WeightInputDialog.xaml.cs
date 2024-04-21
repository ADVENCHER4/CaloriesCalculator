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
    /// Логика взаимодействия для WeightInputDialog.xaml
    /// </summary>
    public partial class WeightInputDialog : Window
    {
        public float Weight {  get; set; }
        public WeightInputDialog()
        {
            InitializeComponent();
        }
        private void OK_Click(object sender, RoutedEventArgs e)
        {
            if (float.TryParse(txtWeight.Text, out float weight) && weight >=0)
            {
                Weight = weight;
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Введите некорректное значение веса.");
            }
        }
    }
}
