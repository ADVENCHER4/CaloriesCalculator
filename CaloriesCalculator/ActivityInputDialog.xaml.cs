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
    /// Логика взаимодействия для ActivityInputDialog.xaml
    /// </summary>
    public partial class ActivityInputDialog : Window
    {
        //в этом классе пользователь вводит то сколько калорий он сжёг
        public int Activity {  get; set; }
        public ActivityInputDialog()
        {
            InitializeComponent();
        }
        private void OK_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtActivity.Text, out int activity) && activity >= 0)
            {
                Activity = activity;
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Введите некорректное.");
            }
        }
    }
}
