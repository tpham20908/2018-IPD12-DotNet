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

namespace PeopleDB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Database db;
        //List<Person> peopleList = new List<Person>();

        public MainWindow()
        {
            try
            {
                db = new Database();
                InitializeComponent();
                refreshPeopleList();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("Error opening database connection: " + ex.Message);
                Environment.Exit(1);
            }
        }

        private void refreshPeopleList()
        {
            lvPeople.ItemsSource = db.GetAllPeople();
            // Refresh not needed, when assigning ItemsSource Refresh is triggered
            // lbPeople.Items.Refresh();
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = tbName.Text;
                int age = int.Parse(tbAge.Text);
                double height = slHeight.Value;
                Person p = new Person(0, name, age, height);
                db.AddPerson(p);
                refreshPeopleList();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("Database query error " + ex.Message);
            }
            resetInputFields();
        }

        private void lvPeople_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = lvPeople.SelectedIndex;
            if (index < 0)
            {
                return;
            }
            Person p = (Person)lvPeople.Items[index];
            lblId.Content = p.Id + "";
            tbName.Text = p.Name;
            tbAge.Text = p.Age + "";
        }

        private void MenuItemDelete_Click(object sender, RoutedEventArgs e)
        {
            int index = lvPeople.SelectedIndex;
            if (index < 0)
            {
                return;
            }
            Person p = (Person)lvPeople.Items[index];
            try
            {
                db.DeletePerson(p.Id);
                refreshPeopleList();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("Database query error " + ex.Message);
            }
            resetInputFields();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int index = lvPeople.SelectedIndex;
            if (index < 0)
            {
                return;
            }
            Person p = (Person)lvPeople.Items[index];
            try
            {
                p.Name = tbName.Text;
                p.Age = int.Parse(tbAge.Text);
                p.Height = slHeight.Value;
                db.UpdatePerson(p);
                refreshPeopleList();
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.StackTrace);
                MessageBox.Show("Database query error " + ex.Message);
            }
            resetInputFields();
        }

        private void resetInputFields()
        {
            tbName.Text = "";
            tbAge.Text = "";
            slHeight.Value = 160;
        }
    }
}
