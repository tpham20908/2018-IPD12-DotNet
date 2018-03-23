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

namespace Quiz2Passengers
{
    /// <summary>
    /// Interaction logic for Sort.xaml
    /// </summary>
    public partial class Sort : Window
    {
        public Sort()
        {
            InitializeComponent();
        }

        private void sortBtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void sortBtnApply_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        public string SortBy
        {
            get
            {
                if (rbtnName.IsChecked == true) return "Name";
                else if (rbtnPassport.IsChecked == true) return "Passport";
                else if (rbtnDestination.IsChecked == true) return "Destination";
                else return "DepartureDateTime";
            }
        }
    }
}
