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

namespace ScoopSelector_TeacherVersion
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

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            ListViewItem item = (ListViewItem)lvAvailable.SelectedItem;
            if (item == null)
            {
                return;
            }
            String value = (string)item.Content;
            Console.WriteLine("Selected: " + value);
            ListViewItem lvItem = new ListViewItem();
            lvItem.Content = value;
            lvSelected.Items.Add(lvItem);
            // lvSelected.Items.Add(value);
        }

        private void btDeleteScoop_Click(object sender, RoutedEventArgs e)
        {
            int index = lvSelected.SelectedIndex;
            if (index < 0)
            {
                return;
            }
            lvSelected.Items.RemoveAt(index);
        }

        private void btClearAll_Click(object sender, RoutedEventArgs e)
        {
            lvSelected.Items.Clear();
        }
    }
}
