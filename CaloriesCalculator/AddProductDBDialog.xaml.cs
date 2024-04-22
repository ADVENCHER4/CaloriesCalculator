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
using System.Windows.Shapes;

namespace CaloriesCalculator
{
    /// <summary>
    /// Логика взаимодействия для AddProductDBDialog.xaml
    /// </summary>
    public partial class AddProductDBDialog : Window
    {
        public AddProductDBDialog()
        {
            InitializeComponent();
        }
        private void OK_Click(object sender, RoutedEventArgs e)
        {
            string productName = productNameTextBox.Text;
            uint calories, protein, fat, carbohydrates, fiber;

            if (!uint.TryParse(caloriesTextBox.Text, out calories) ||
                !uint.TryParse(proteinTextBox.Text, out protein) ||
                !uint.TryParse(fatTextBox.Text, out fat) ||
                !uint.TryParse(carbohydratesTextBox.Text, out carbohydrates) ||
                !uint.TryParse(fiberTextBox.Text, out fiber))
            {
                MessageBox.Show("Пожалуйста, введите корректные числовые значения.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DBController controller = new DBController();
            controller.AddProduct(productName, calories, protein, fat, carbohydrates, fiber);
            Close();
        }
    }
}
