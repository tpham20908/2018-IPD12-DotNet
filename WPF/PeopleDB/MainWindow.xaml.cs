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

namespace PeopleDB
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Database db = new Database();
        List<Person> peopleList = new List<Person>();

        public MainWindow()
        {
            peopleList = db.GetAllPeople();
            InitializeComponent();
            lvPeople.ItemsSource = peopleList;
        }

        private void btAdd_Click(object sender, RoutedEventArgs e)
        {
            string name = tbName.Text;
            string ageStr = tbAge.Text;
            string heightStr = tbHeight.Text;
            int age;
            double height;
            if (!int.TryParse(ageStr, out age))
            {
                MessageBox.Show("Age must be an integer");
                return;
            }
            if (!double.TryParse(heightStr, out height))
            {
                MessageBox.Show("Height must be a double");
                return;
            }
            try
            {
                Person p = new Person(0, name, age, height);
                db.AddPerson(p);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            peopleList = db.GetAllPeople();
            lvPeople.Items.Refresh();
            reset();
        }

        private void lvPeople_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Person p = (Person) lvPeople.SelectedItem;
            lblId.Content = p.Id;
            tbName.Text = p.Name;
            tbAge.Text = p.Age + "";
            slHeight.Value = p.Height;
        }

        private void MenuItemDelete_Click(object sender, RoutedEventArgs e)
        {
            Person p = (Person)lvPeople.SelectedItem;
            int id = p.Id;
            if (id < 0)
            {
                lblId.Content = "...";
                return;
            }
            db.DeletePerson(id);
            lvPeople.Items.Refresh();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(lblId.Content + "");
            string name = tbName.Text;
            string ageStr = tbAge.Text;
            string heightStr = tbHeight.Text;
            int age;
            double height;
            if (!int.TryParse(ageStr, out age))
            {
                MessageBox.Show("Age must be an integer");
                return;
            }
            if (!double.TryParse(heightStr, out height))
            {
                MessageBox.Show("Height must be a double");
                return;
            }
            try
            {
                Person p = new Person(id, name, age, height);
                db.UpdatePerson(p);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            peopleList = db.GetAllPeople();
            lvPeople.Items.Refresh();
            reset();
        }

        private void reset()
        {
            tbName.Text = "";
            tbAge.Text = "";
            slHeight.Value = 160;
        }
    }
}
