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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ScoopSelector
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            lbSelected.Items.Add(((ListBoxItem)lbFlavour.SelectedItem).Content.ToString());
            
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            lbSelected.Items.Remove(lbSelected.SelectedItem);
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            lbSelected.Items.Clear();
        }
    }
}
