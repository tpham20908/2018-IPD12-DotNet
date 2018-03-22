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

namespace TodoDBCustDlg
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            try
            {
                Global.db = new Database();
                InitializeComponent();
                refreshTodoList();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.StackTrace);
                MessageBox.Show("Error opening database connection: " + e.Message);
                Environment.Exit(1);
            }
        }

        private void refreshTodoList()
        {
            lvTodos.ItemsSource = Global.db.GetAllTodos();
            // Refresh not needed, when assigning ItemsSource Refresh is triggered
            // lbPeople.Items.Refresh();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddEditTodoDialog dlg = new AddEditTodoDialog(null);
            if (dlg.ShowDialog() == true)
            {
                lvTodos.ItemsSource = Global.db.GetAllTodos();
            }
        }

        private void lvTodos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Todo todo = (Todo)lvTodos.SelectedItem;
            if (todo == null)
            {
                return;
            }
            AddEditTodoDialog dlg = new AddEditTodoDialog(null);
            if (dlg.ShowDialog() == true)
            {
                lvTodos.ItemsSource = Global.db.GetAllTodos();
            }
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Todo: 
            List<Todo> todoList = Global.db.GetAllTodos();
            String word = tbSearch.Text;
            if (word != "")
            {
                var result = from t in todoList where t.Task.Contains(word) select t;
                todoList = result.ToList();
            }
            lvTodos.ItemsSource = todoList;
        }
    }
}
