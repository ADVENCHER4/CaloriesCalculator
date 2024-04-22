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
    /// Логика взаимодействия для EditDBProductDialog.xaml
    /// </summary>
    public partial class EditDBProductDialog : Window
    {
        DBController controller;
        public Product editProduct { get; set; }
        public EditDBProductDialog(Product product)
        {
            InitializeComponent();
            editProduct = new Product(product.Id, product.Name, product.Calories, product.Proteins, product.Fats, product.Carbohydrates, product.Fibers);
            controller = new DBController();
            DataContext = editProduct;
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            editProduct.Name = NameTextBox.Text;
            editProduct.Calories = Convert.ToUInt32(CaloriesTextBox.Text);
            editProduct.Proteins = Convert.ToUInt32(ProteinsTextBox.Text);
            editProduct.Fats = Convert.ToUInt32(FatsTextBox.Text);
            editProduct.Carbohydrates = Convert.ToUInt32(CarbohydratesTextBox.Text);
            editProduct.Fibers = Convert.ToUInt32(FibersTextBox.Text);
            controller.UpdateProduct(editProduct.Id, editProduct.Name, editProduct.Calories, editProduct.Proteins, editProduct.Fats, editProduct.Carbohydrates, editProduct.Fibers);
            Close();
        }
    }
}
