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

namespace CustomSanwich
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

        private void btnMake_Click(object sender, RoutedEventArgs e)
        {
            Window1 Dialog = new Window1();
            if (Dialog.ShowDialog() == true)
            {
                lblBread.Content = Dialog.Bread;
                lblMeat.Content = Dialog.Meat;
                lblVegies.Content = Dialog.Vegies;
            }
        }
    }
}
