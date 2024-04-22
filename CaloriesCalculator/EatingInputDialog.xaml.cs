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
    /// Логика взаимодействия для EatingInputDialog.xaml
    /// </summary>
    public partial class EatingInputDialog : Window
    {
        DBController dbController = new DBController();
        List<Product> products = new List<Product>();
        public uint SelectedNumber { get; private set; }
        private void SetSelectedNumber(uint number)
        {
            SelectedNumber = number;
        }
        public EatingInputDialog()
        {
            InitializeComponent();
            UpdatePage();
        }
        private void UpdatePage()
        {
            dataGrid.Items.Clear();
            products = dbController.GetAllProducts();
            foreach (var product in products)
            {
                dataGrid.Items.Add(product);
            }

        }

        public void ChooseButton_Click(object sender, RoutedEventArgs e)
        {

            Product selectedItem = (Product)dataGrid.SelectedItem;
            SetSelectedNumber(selectedItem.Id);
            DialogResult = true;
            Close();
        }
        public void Add_Click(object sender, RoutedEventArgs e)
        {
            AddProductDBDialog addProductDBDialog = new AddProductDBDialog();
            addProductDBDialog.ShowDialog();
            UpdatePage();
        }
        public void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Product selectedItem = (Product)dataGrid.SelectedItem;
            dbController.RemoveProduct(selectedItem.Id);
            products.Remove(selectedItem);
            UpdatePage();
        }
        public void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Product selectedItem = (Product)dataGrid.SelectedItem;
            uint id = (uint)selectedItem.Id;
            EditDBProductDialog editDBProductDialog = new EditDBProductDialog(selectedItem);
            editDBProductDialog.ShowDialog();
            UpdatePage();
        }
    }

}
