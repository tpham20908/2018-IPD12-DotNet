using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace Quiz2Passengers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Passenger> cachedAllPassengers;
        public MainWindow()
        {
            try
            {
                Global.db = new Database();
                InitializeComponent();
                refreshPList();                
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.StackTrace);
                MessageBox.Show("Error opening database connection: " + e.Message);
                Environment.Exit(1);
            }
        }

        public void refreshPList()
        {
            cachedAllPassengers = Global.db.GetAllPassengers();
            lvPassengers.ItemsSource = cachedAllPassengers;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            InputDialog dlg = new InputDialog(null);
            if (dlg.ShowDialog() == true)
            {
                refreshPList();
            }
        }

        private void lvPassengers_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Passenger p = (Passenger)lvPassengers.SelectedItem;
            if (p == null)
            {
                return;
            }
            InputDialog dlg = new InputDialog(p);
            if (dlg.ShowDialog() == true)
            {
                refreshPList();
            }
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<Passenger> pList = cachedAllPassengers;
            string word = tbSearch.Text;
            if (word != "")
            {
                var result = from p in pList
                             where p.Name.Contains(word) || p.Destination.Contains(word)
                             select p;
                pList = result.ToList();
            }
            lvPassengers.ItemsSource = pList;
        }

        private void btnSort_Click(object sender, RoutedEventArgs e)
        {
            Sort sort = new Sort();
            List<Passenger> pList = cachedAllPassengers;
            if (sort.ShowDialog() == true)
            {
                string sortBy = sort.SortBy;
                switch (sortBy)
                {
                    case "Name":
                        var result = from p in pList
                                     orderby p.Name
                                     select p;
                        pList = result.ToList();
                        break;
                    case "Passport":
                        result = from p in pList
                                    orderby p.Passport
                                    select p;
                        pList = result.ToList();
                        break;
                    case "Destination":
                        result = from p in pList
                                     orderby p.Destination
                                     select p;
                        pList = result.ToList();
                        break;
                    case "DepartureDateTime":
                        result = from p in pList
                                     orderby p.DepartureDateTime
                                     select p;
                        pList = result.ToList();
                        break;
                }
            }
            lvPassengers.ItemsSource = pList;
        }
    }
}
