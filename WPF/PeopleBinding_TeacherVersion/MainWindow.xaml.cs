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

namespace PeopleBinding_TeacherVersion
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Person> peopleList = new List<Person>();

        public MainWindow()
        {
            InitializeComponent();
            lvPeople.ItemsSource = peopleList;
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            string name = tbName.Text;
            string ageStr = tbAge.Text;
            int age;
            if (!int.TryParse(ageStr, out age))
            {
                MessageBox.Show("Age must be an integer");
                return;
            }
            try
            {
                Person p = new Person(name, age);
                peopleList.Add(p);
                lvPeople.Items.Refresh();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MenuItemDelete_Click(object sender, RoutedEventArgs e)
        {
            int index = lvPeople.SelectedIndex;
            if (index < 0)
            {
                return;
            }
            peopleList.RemoveAt(index);
            lvPeople.Items.Refresh();
        }

        private void lvPeople_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = lvPeople.SelectedIndex;
            if (index < 0)
            {
                lblId.Content = "...";
                return;
            }
            Person p = peopleList[index];
            lblId.Content = p.Id + "";
            tbName.Text = p.Name;
            tbAge.Text = p.Age + "";
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            int index = lvPeople.SelectedIndex;
            if (index < 0)
            {
                return;
            }
            string name = tbName.Text;
            string ageStr = tbAge.Text;
            int age;
            if (!int.TryParse(ageStr, out age))
            {
                MessageBox.Show("Age must be an integer");
                return;
            }
            try
            {
                Person p = peopleList[index];
                p.Age = age;
                p.Name = name;
                lvPeople.Items.Refresh();
            }
            catch (ArgumentException ex)
            {
                // a terrible fix for a partial update problem
                lvPeople.Items.Refresh();
                MessageBox.Show(ex.Message);
            }

        }
    }
}
